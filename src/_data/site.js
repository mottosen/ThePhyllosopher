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

/**
 * Structural facts about the three sections: which folder under content/ each
 * one lists, and the URL it lives at. These stay in code rather than in
 * site.yaml because changing a URL breaks every existing link to it, and
 * because adding a section also needs a content folder and its .11tydata.json.
 * All the *wording* comes from site.yaml.
 */
const SECTIONS = {
  blog: { collection: "blogposts", url: "/blog/" },
  podcasts: { collection: "podcasts", url: "/podcasts/" },
  articles: { collection: "articles", url: "/articles/" },
};

const titleCase = (s) => s.charAt(0).toUpperCase() + s.slice(1);

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

  // Merge the authored wording onto the structural definitions above. A
  // section missing from site.yaml still renders, using its key as the name,
  // so a mistake there degrades rather than breaking the build.
  const configured = data.sections ?? {};
  const sections = {};
  const order = Object.keys(SECTIONS).sort((a, b) => {
    const keys = Object.keys(configured);
    const ia = keys.indexOf(a);
    const ib = keys.indexOf(b);
    return (ia === -1 ? Infinity : ia) - (ib === -1 ? Infinity : ib);
  });

  for (const key of order) {
    const authored = configured[key] ?? {};
    sections[key] = {
      key,
      ...SECTIONS[key],
      label: text(authored.label) || titleCase(key),
      title: text(authored.title) || text(authored.label) || titleCase(key),
      intro: text(authored.intro) || "",
      empty: text(authored.empty) || "Nothing here just yet — check back soon.",
    };
  }

  for (const key of Object.keys(configured)) {
    if (!SECTIONS[key]) {
      throw new Error(
        `${CONFIG} has a section called "${key}", but the site only has ` +
          `${Object.keys(SECTIONS).join(", ")}. Check the spelling.`
      );
    }
  }

  // The top menu is the home link followed by the sections, in the order they
  // appear in site.yaml - so renaming a section renames its menu entry too.
  const nav = [
    { label: text(data.homeLabel) || "Home", url: "/" },
    ...order.map((key) => ({ label: sections[key].label, url: sections[key].url })),
  ];

  return {
    ...data,
    title: text(data.title),
    tagline: text(data.tagline),
    author: text(data.author),
    welcome,
    sections,
    sectionList: order.map((key) => sections[key]),
    nav,
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
