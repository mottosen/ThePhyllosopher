/* Progressive enhancement only - every page works with this file absent. */
(function () {
  "use strict";

  // Mobile navigation.
  var toggle = document.querySelector(".nav-toggle");
  var menu = document.getElementById("navmenu");

  if (toggle && menu) {
    toggle.addEventListener("click", function () {
      var open = toggle.getAttribute("aria-expanded") === "true";
      toggle.setAttribute("aria-expanded", String(!open));
      toggle.setAttribute("aria-label", open ? "Open menu" : "Close menu");
      menu.classList.toggle("is-open", !open);
    });

    menu.addEventListener("click", function (event) {
      if (event.target.closest("a")) {
        toggle.setAttribute("aria-expanded", "false");
        toggle.setAttribute("aria-label", "Open menu");
        menu.classList.remove("is-open");
      }
    });
  }

  // Back-to-top button, shown once the reader has scrolled a screenful.
  var scrollTop = document.querySelector(".scroll-top");

  if (scrollTop) {
    var update = function () {
      scrollTop.classList.toggle("is-visible", window.scrollY > 300);
    };
    update();
    window.addEventListener("scroll", update, { passive: true });
  }
})();
