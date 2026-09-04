import { cp, mkdir, writeFile } from "node:fs/promises";

const files = ["index.html", "styles.css", "app.js", "manifest.webmanifest", "sw.js"];
await mkdir("dist/server", { recursive: true });
await mkdir("dist/assets", { recursive: true });
for (const file of files) await cp(file, `dist/${file}`);
await cp("assets/westport-logo.png", "dist/assets/westport-logo.png");
await writeFile("dist/server/index.js", `export default { async fetch(request, env) { return env.ASSETS.fetch(request); } };\n`);
