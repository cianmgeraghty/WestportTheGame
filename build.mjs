import { cp, mkdir, readFile, writeFile } from "node:fs/promises";

const files = ["index.html", "styles.css", "app.js", "interaction-fix.js", "manifest.webmanifest", "sw.js"];
await mkdir("dist/server", { recursive: true });
await mkdir("dist/assets", { recursive: true });
for (const file of files) await cp(file, `dist/${file}`);
await cp("assets/westport-logo.png", "dist/assets/westport-logo.png");
const html = JSON.stringify(await readFile("index.html", "utf8"));
const css = JSON.stringify(await readFile("styles.css", "utf8"));
const js = JSON.stringify((await readFile("app.js", "utf8")) + "\n" + (await readFile("three-layer.js", "utf8")));
const manifest = JSON.stringify(await readFile("manifest.webmanifest", "utf8"));
const sw = JSON.stringify(await readFile("sw.js", "utf8"));
const fix = JSON.stringify(await readFile("interaction-fix.js", "utf8"));
const logo = (await readFile("assets/westport-logo.png")).toString("base64");
await writeFile("dist/server/index.js", `const files={"/":{body:${html},type:"text/html; charset=utf-8"},"/index.html":{body:${html},type:"text/html; charset=utf-8"},"/styles.css":{body:${css},type:"text/css; charset=utf-8"},"/app.js":{body:${js},type:"text/javascript; charset=utf-8"},"/interaction-fix.js":{body:${fix},type:"text/javascript; charset=utf-8"},"/manifest.webmanifest":{body:${manifest},type:"application/manifest+json"},"/sw.js":{body:${sw},type:"text/javascript; charset=utf-8"},"/assets/westport-logo.png":{body:Uint8Array.from(atob("${logo}"),c=>c.charCodeAt(0)),type:"image/png"}}; export default {async fetch(request){const file=files[new URL(request.url).pathname]; return file?new Response(file.body,{headers:{"content-type":file.type,"cache-control":"no-cache, no-store, must-revalidate"}}):new Response("Not found",{status:404});}};\n`);
