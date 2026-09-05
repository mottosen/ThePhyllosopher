---
title: "Example: replace this with a real article"
author: "Bethany Mostert"
date: 2024-01-01
venue: "Journal name, volume(issue), year"
pdf: "example-article.pdf"
draft: true
---

This file is a template, not a real publication. It is marked `draft: true`, so it
is visible with `npm start` / `docker compose up dev` but never appears on the
published site.

To add a real article:

1. Copy this file to `content/articles/your-article-slug.md`.
2. Put the PDF in `content/articles/pdfs/` and name it in the `pdf:` field.
3. Fill in `title`, `date` and `venue`, and write a short plain-language summary
   here in the body — this is what appears on the Articles list page.
4. Delete the `draft: true` line to publish it.
