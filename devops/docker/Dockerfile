# Node version is pinned here, in flake.nix, and in .github/workflows/deploy.yml.
# All three must agree - see the README.
FROM node:22-alpine

# Run as the image's built-in `node` user (uid 1000) rather than root, so that
# files written into the bind-mounted ./_site stay owned by the person running
# docker, not by root.
WORKDIR /app
RUN chown node:node /app
USER node

# Install dependencies as their own layer so editing content does not
# invalidate the npm cache.
COPY --chown=node:node package.json package-lock.json ./
RUN npm ci

COPY --chown=node:node . .

# Owned by `node` so the named volume and the output dir inherit that owner.
RUN mkdir -p /app/_site

EXPOSE 8080
CMD ["npm", "start"]
