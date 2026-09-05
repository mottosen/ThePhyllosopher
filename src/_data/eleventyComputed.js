/**
 * A section's list page names only which section it is; its heading comes from
 * content/site.yaml. The <title> tag lives in the base layout, and a child
 * template cannot pass a variable up the layout chain, so it is resolved here.
 */
export default {
  title: (data) => {
    if (data.title) return data.title;
    const section = data.site?.sections?.[data.section];
    return section ? section.title : undefined;
  },
};
