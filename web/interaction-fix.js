(() => {
  const launch = document.querySelector('#launch');
  const landing = document.querySelector('#landing');
  const game = document.querySelector('#game');
  if (!launch || !landing || !game) return;
  const showGame = (event) => {
    event?.preventDefault();
    launch.classList.add('is-pressed');
    setTimeout(() => launch.classList.remove('is-pressed'), 160);
    document.body.dataset.screen = 'game';
    landing.hidden = true;
    game.hidden = false;
    game.setAttribute('aria-hidden', 'false');
    history.replaceState({}, '', '#prototype');
  };
  launch.addEventListener('click', showGame, { passive: false });
  launch.addEventListener('pointerup', () => {
    if (document.body.dataset.screen !== 'game') showGame();
  });
  if (location.search.includes('play=1') || location.hash === '#prototype') showGame();
})();
