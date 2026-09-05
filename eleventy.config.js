/**
 * The Phyllosopher - Eleventy configuration.
 *
 * Input is the repo root so that `content/` can stay at the top level where
 * the author will look for it, while all the site machinery lives in `src/`.
 * `.eleventyignore` keeps the design reference and tooling out of the build.
 */

const CATEGORIES = ["blogposts", "podcasts", "articles"];

/** Strip markdown syntax down to plain prose, for card summaries and meta tags. */
function toPlainText(markdown) {
  return String(markdown)
    .replace(/```[\s\S]*?```/g, " ")        // fenced code
    .replace(/!\[[^\]]*\]\([^)]*\)/g, " ")  // images
    .replace(/\[([^\]]*)\]\([^)]*\)/g, "$1") // links -> their text
    .replace(/^\s{0,3}#{1,6}\s+/gm, "")     // headings
    .replace(/^\s{0,3}[-*+]\s+/gm, "")      // list markers
    .replace(/[*_`>]/g, "")                 // emphasis, quotes, code spans
    .replace(/\s+/g, " ")
    .trim();
}

export default function (eleventyConfig) {
  eleventyConfig.addPassthroughCopy({ "src/assets": "assets" });
  eleventyConfig.addPassthroughCopy({ "src/CNAME": "CNAME" });
  eleventyConfig.addPassthroughCopy({ "src/.nojekyll": ".nojekyll" });
  eleventyConfig.addPassthroughCopy({ "content/articles/pdfs": "articles/pdfs" });

  eleventyConfig.addWatchTarget("src/assets/");

  // 0.0.0.0 so the dev server is reachable from outside the container.
  eleventyConfig.setServerOptions({ host: "0.0.0.0", port: 8080 });

  // Drafts are previewable with `--serve` but never reach a production build.
  eleventyConfig.addPreprocessor("drafts", "md", (data) => {
    if (data.draft && process.env.ELEVENTY_RUN_MODE === "build") return false;
  });

  // One collection per category, newest first, drafts always excluded so an
  // unfinished entry can be previewed by URL without showing up in listings.
  for (const name of CATEGORIES) {
    eleventyConfig.addCollection(name, (collectionApi) =>
      collectionApi
        .getFilteredByTag(name.replace(/s$/, ""))
        .filter((item) => !item.data.draft)
        .sort((a, b) => b.date - a.date)
    );
  }

  // "23 February 2024" - forced to UTC so a date-only frontmatter value
  // cannot slip to the previous day in a western timezone.
  eleventyConfig.addFilter("readableDate", (value) =>
    new Intl.DateTimeFormat("en-GB", {
      day: "numeric", month: "long", year: "numeric", timeZone: "UTC",
    }).format(new Date(value))
  );

  eleventyConfig.addFilter("isoDate", (value) =>
    new Date(value).toISOString().slice(0, 10)
  );

  /** Card summary: the explicit `description:` if given, else the opening prose. */
  eleventyConfig.addFilter("summary", function (item, limit = 170) {
    if (item.data?.description) return item.data.description;
    const text = toPlainText(item.rawInput ?? "");
    if (!text) return "";
    if (text.length <= limit) return text;
    const cut = text.slice(0, limit);
    return cut.slice(0, cut.lastIndexOf(" ")).replace(/[,;:.]$/, "") + "…";
  });

  eleventyConfig.addFilter("plainText", toPlainText);

  return {
    dir: {
      input: ".",
      includes: "src/_includes",
      layouts: "src/_layouts",
      data: "src/_data",
      output: "_site",
    },
    markdownTemplateEngine: "njk",
    htmlTemplateEngine: "njk",
    templateFormats: ["md", "njk", "html"],
  };
}
