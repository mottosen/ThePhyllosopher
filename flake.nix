{
  description = "The Phyllosopher - a static blog built with Eleventy";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-25.05";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };
      in
      {
        devShells.default = pkgs.mkShell {
          name = "thephyllosopher";

          # Everything needed to work on the site, so nothing depends on what
          # happens to be installed on the host. Node is pinned here, in
          # devops/Dockerfile, and in .github/workflows/deploy.yml - all three
          # must agree.
          packages = with pkgs; [
            nodejs_22

            # So the container workflow does not rely on the host's PATH
            # either. The Docker daemon itself still has to come from the host.
            docker-client
            docker-compose

            git
            jq
          ];

          shellHook = ''
            echo "The Phyllosopher - node $(node --version)"
            echo
            echo "  npm install            install dependencies"
            echo "  npm start              dev server on http://localhost:8080"
            echo "  npm run build          build into ./_site"
            echo
            echo "  docker compose up dev  same dev server, no toolchain needed"
          '';
        };
      });
}
