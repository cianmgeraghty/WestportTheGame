// Lightweight Three.js view layered over the existing interaction shell.
if (document.querySelector('#scene')) import('https://unpkg.com/three@0.160.0/build/three.module.js').then(THREE => {
  const host=document.querySelector('#scene'), scene=new THREE.Scene(); scene.background=new THREE.Color(0x173b50);
  const camera=new THREE.PerspectiveCamera(55,innerWidth/innerHeight,.1,500), renderer=new THREE.WebGLRenderer({antialias:true});
  renderer.setPixelRatio(Math.min(devicePixelRatio,1.5)); renderer.setSize(innerWidth,innerHeight); renderer.shadowMap.enabled=true; host.appendChild(renderer.domElement);
  scene.add(new THREE.HemisphereLight(0xb7d4d0,0x20333b,1.8)); const sun=new THREE.DirectionalLight(0xffe1ad,2.2); sun.position.set(-40,70,30); sun.castShadow=true; scene.add(sun);
  const mat=c=>new THREE.MeshStandardMaterial({color:c,roughness:.88}); const add=(p,s,c)=>{const m=new THREE.Mesh(new THREE.BoxGeometry(...s),mat(c));m.position.set(...p);m.castShadow=true;scene.add(m);};
  add([0,-.25,0],[150,.5,150],0x9ab7a7); add([0,0,0],[14,.16,150],0x303d43); add([0,.02,0],[150,.18,14],0x303d43); add([0,.07,0],[34,.24,34],0x455158);
  [[-34,-38,10,0xc67b5a],[34,-38,14,0xd1a35d],[-38,35,8,0x6f9b9d],[38,35,12,0xb96a57],[-52,-5,8,0xc67b5a],[52,5,10,0xd1a35d]].forEach(b=>add([b[0],b[2]/2,b[1]],[b[0]*b[0]>2000?18:22,b[2],b[0]*b[0]>2000?22:28],b[3]));
  add([0,5,-7],[4.5,10,4.5],0xa8a59a); const roof=new THREE.Mesh(new THREE.ConeGeometry(3,4,4),mat(0x343f43));roof.position.set(0,12,-7);scene.add(roof); add([0,8.2,-4.72],[2.2,2.2,.12],0xf2d28a); add([0,8.2,-4.8],[.12,1.4,.14],0x273237); add([10,1,10],[3.6,1.4,7],0xc94b43); add([10,1.9,10],[2.7,.8,3.2],0x9bc2c4);
  const avatar=new THREE.Mesh(new THREE.CapsuleGeometry(.55,1.2,6,12),mat(0xefb84b));avatar.position.set(0,1.1,24);avatar.castShadow=true;scene.add(avatar); camera.position.set(0,7,10); const clock=new THREE.Clock();
  const animate=()=>{requestAnimationFrame(animate);const dt=Math.min(clock.getDelta(),.05),dx=(keys.ArrowRight||keys.d?1:0)-(keys.ArrowLeft||keys.a?1:0),dz=(keys.ArrowDown||keys.s?1:0)-(keys.ArrowUp||keys.w?1:0);avatar.position.x+=dx*dt*8;avatar.position.z+=dz*dt*8;camera.position.lerp(new THREE.Vector3(avatar.position.x,7,avatar.position.z+10),.12);camera.lookAt(avatar.position.x,1.5,avatar.position.z-4);renderer.render(scene,camera);}; animate(); addEventListener('resize',()=>{camera.aspect=innerWidth/innerHeight;camera.updateProjectionMatrix();renderer.setSize(innerWidth,innerHeight);});
}).catch(()=>{});
