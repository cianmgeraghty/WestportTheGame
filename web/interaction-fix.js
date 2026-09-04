const launchButton=document.querySelector('#launch');launchButton?.addEventListener('pointerup',()=>{const gameScreen=document.querySelector('#game');if(gameScreen?.hidden)launchButton.click()});
