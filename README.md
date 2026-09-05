# The Phyllosopher

The blog of [The Phyllosopher](https://thephyllosopher.com) — writing, podcasts and
published work by Bethany Mostert.

It is a static site: markdown files in `content/` are built into plain HTML by
[Eleventy](https://www.11ty.dev/) and published to GitHub Pages. There is no CMS,
no database and no server to maintain.

---

## Adding content

Every entry is one markdown file. The folder it goes in decides which section of
the site it appears in, and the filename becomes the URL — so use lowercase words
separated by hyphens (`foraging-for-morels.md` becomes `/podcasts/foraging-for-morels/`).

Each file starts with a small block between `---` lines. That block is the only
part with a fixed shape; everything below it is ordinary markdown.

### A blog post — `content/blogposts/`

```markdown
---
title: "What I Learned Dancing to Bomba Music"
author: "Bethany Mostert"
date: 2024-02-12
---

Write the post here. Leave a blank line between paragraphs.
```

### A podcast episode — `content/podcasts/`

```markdown
---
title: "Foraging for Morels"
author: "Bethany Mostert"
date: 2023-01-09
soundcloud: "https://w.soundcloud.com/player/?url=...&visual=true"
---

An optional description of the episode.
```

To get the `soundcloud:` value: open the track on SoundCloud, choose **Share →
Embed**, and copy the `src="..."` address out of the code it shows you. Keep the
quotes around it.

### An article — `content/articles/`

```markdown
---
title: "The title of the paper"
author: "Bethany Mostert"
date: 2024-06-01
venue: "Journal name, volume(issue), year"
pdf: "the-file-name.pdf"
---

A short plain-language summary of the work. This is what appears on the
Articles page.
```

Put the PDF itself in `content/articles/pdfs/`, and give its filename in the
`pdf:` field. `content/articles/example-article.md` is a working template you can
copy.

### Optional extras

| Field | What it does |
|---|---|
| `description:` | Overrides the summary shown on list pages. Without it, the opening lines of the entry are used. |
| `draft: true` | Keeps the entry off the published site. It still shows up locally, so you can preview unfinished work. |

---

## Working on the site locally

Two ways in. Both produce the same result — use whichever is convenient.

### With Docker (nothing to install)

```sh
docker compose up dev
```

Then open <http://localhost:8080>. Editing a file under `content/` or `src/`
reloads the browser automatically. Press Ctrl-C to stop.

To check the site exactly as GitHub Pages will serve it:

```sh
docker compose run --rm build     # build into ./_site
docker compose up preview         # serve it on http://localhost:8081
```

The `preview` step is worth doing before publishing anything structural: it
catches broken links and missing files that the dev server is lenient about.

### With Nix

```sh
nix develop     # drops you into a shell with the right Node version
npm install     # first time only
npm start       # http://localhost:8080
```

`nix develop` supplies Node, npm and the Docker client, so the repo does not
depend on what happens to be installed on your machine. `flake.lock` pins the
exact versions, so a checkout on another machine gets the same toolchain.

---

## Publishing

Pushing to `main` triggers `.github/workflows/deploy.yml`, which builds the site
and deploys it to GitHub Pages. There is nothing to do by hand.

The custom domain is configured by `src/CNAME`, which is copied to the root of
the built site. Changing the domain means editing that file **and** updating the
DNS records at the registrar — the file alone is not enough.

> **Note on the Node version.** It is pinned in three places that must agree:
> `flake.nix` (`nodejs_22`), `devops/Dockerfile` (`node:22-alpine`) and
> `.github/workflows/deploy.yml` (`node-version: '22'`). If you upgrade, change
> all three together, or the site will build locally and fail in CI.

---

## How it is put together

```
content/          the markdown, one folder per section
  blogposts/
  podcasts/
  articles/
    pdfs/         article PDFs
src/
  _layouts/       page templates - one per kind of page
  _includes/      shared fragments (header, footer, entry card, icons)
  _data/site.json site title, navigation, social links
  pages/          the home page, the three section pages, the 404 page
  assets/         stylesheet and script
  CNAME           the custom domain
devops/           Dockerfile and the nginx config used by `preview`
misc/             the original ZenBlog theme, kept as a design reference only
eleventy.config.js
```

Each folder in `content/` has a small `*.11tydata.json` file next to the markdown.
That is what tells Eleventy which template to use and what the URLs should look
like for everything in that folder — you only touch it if you add a new section.

The design takes its cues from the [ZenBlog](https://bootstrapmade.com/demo/ZenBlog/)
theme in `misc/` — the same typefaces, palette and spacing — but the stylesheet is
written from scratch. The built site loads no third-party CSS or JavaScript
beyond two Google fonts.
