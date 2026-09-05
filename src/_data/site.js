/**
 * Loads the author-facing settings from `content/site.yaml`.
 *
 * Everything a non-developer needs to change lives in that file, under
 * `content/` with the rest of the writing. This module reads it, fills in
 * the fallbacks, and fails with a readable message when it is malformed -
 * a YAML typo should say what is wrong, not produce a half-broken page.
 */
import fs from "node:fs";
import { load } from "js-yaml";

const CONFIG = "content/site.yaml";
const CNAME = "src/CNAME";

/** The published domain, so canonical URLs cannot drift from the CNAME. */
function siteUrl() {
  try {
    const host = fs.readFileSync(CNAME, "utf8").trim();
    if (host) return `https://${host}`;
  } catch {
    /* no custom domain configured */
  }
  return "";
}

export default function () {
  let raw;
  try {
    raw = fs.readFileSync(CONFIG, "utf8");
  } catch {
    throw new Error(`Cannot find ${CONFIG}. The site needs it to build.`);
  }

  let data;
  try {
    data = load(raw);
  } catch (error) {
    throw new Error(
      `${CONFIG} is not valid YAML, so the site cannot build.\n\n` +
        `${error.message}\n\n` +
        `Check the indentation (spaces, not tabs) and put "quotes" around ` +
        `any value containing a colon.`
    );
  }

  // YAML's ">" folding leaves a trailing newline, which would otherwise end
  // up inside a <meta content="..."> attribute.
  const text = (value) => (typeof value === "string" ? value.trim() : value);

  for (const key of ["title", "welcome"]) {
    if (!data?.[key]) throw new Error(`${CONFIG} is missing "${key}".`);
  }

  // A blank `footerText:` or `metaDescription:` falls back to the welcome
  // text, so the common case needs only one paragraph written once.
  const welcome = text(data.welcome);

  return {
    ...data,
    title: text(data.title),
    tagline: text(data.tagline),
    author: text(data.author),
    welcome,
    nav: data.nav ?? [],
    social: data.social ?? [],
    footerText: text(data.footerText) || welcome,
    metaDescription: text(data.metaDescription) || welcome,
    copyright: text(data.copyright) || "All rights reserved.",
    year: new Date().getFullYear(),

    // Developer settings - not in content/site.yaml, since they are not
    // things the author needs to think about. Both can still be overridden
    // there if the need ever arises.
    lang: data.lang || "en",
    url: data.url || siteUrl(),
  };
}
