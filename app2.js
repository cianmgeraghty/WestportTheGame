const landing = document.querySelector('#landing');
const game = document.querySelector('#game');
const scene = document.querySelector('#scene');
function showGame() {
  landing.hidden = true;
  game.hidden = false;
  game.setAttribute('aria-hidden', 'false');
  document.body.dataset.screen = 'game';
  scene.innerHTML = '<iframe title="Westport 3D Godot prototype" src="https://cianmgeraghty.github.io/WestportTheGame/godot-live/index.html" allow="fullscreen; gamepad" loading="eager"></iframe>';
  ['#joystick', '#drive', '.legend', '.location', '#map'].forEach((s) => { const el = document.querySelector(s); if (el) el.hidden = true; });
}
function showLanding() { game.hidden = true; game.setAttribute('aria-hidden', 'true'); landing.hidden = false; document.body.dataset.screen = 'landing'; scene.replaceChildren(); }
document.querySelector('#launch').addEventListener('click', (e) => { e.preventDefault(); history.replaceState({}, '', '#prototype'); showGame(); });
document.querySelector('#back').addEventListener('click', showLanding);
let promptEvent;
addEventListener('beforeinstallprompt', (e) => { e.preventDefault(); promptEvent = e; document.querySelector('#install').hidden = false; });
document.querySelector('#install').addEventListener('click', async () => { if (promptEvent) { promptEvent.prompt(); promptEvent = null; } });
if ('serviceWorker' in navigator) navigator.serviceWorker.register('sw.js?v=13').catch(() => {});
if (location.search.includes('play=1') || location.hash === '#prototype') showGame();
