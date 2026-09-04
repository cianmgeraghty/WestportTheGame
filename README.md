# WestportTheGame

WestportTheGame is a personal Unity project exploring a geographically accurate, stylised 3D recreation of central Westport, Co. Mayo.

## v0.1 goal

Build a playable central-Westport prototype with:

- real-world street and building layout as the geographic foundation
- third-person walking and running
- one drivable car with enter/exit interaction
- mobile-friendly camera and controls

The first slice will focus on the Octagon, Bridge Street, Shop Street, James Street, The Mall, and their immediate surroundings. Initial buildings may be simple blocks while the map and movement are validated.

## Later expansion

Future milestones may add recognisable businesses, selected interiors, pedestrians and traffic, missions, shops and other interactions, money, and a fictional Garda response/wanted system. Real businesses and people will not be portrayed as endorsing or engaging in fictional wrongdoing.

## Repository layout

```text
Assets/          Unity scenes, scripts, prefabs, materials, and imported content
Packages/        Unity package manifest and lock file
ProjectSettings/ Unity project settings
docs/            Planning notes, mapping/licensing notes, and design documentation
```

This repository contains project scaffolding and planning material only; geographic source data and imagery will be added with appropriate attribution and licensing.

## The long-term vision

Westport: The Game is intended to become a shareable, stylised open-world mobile game set in the real Westport, County Mayo. The town itself is the main character: streets, landmarks, bridges, businesses and the surrounding landscape should feel recognisably Westport even when the art style is deliberately game-like rather than photorealistic.

The geographic foundation should use appropriately licensed map data, satellite references and town imagery. The first playable district is central Westport, expanding over time toward the Quay, Castlebar Road, Newport Road and other surrounding areas. Roads and building footprints should be faithful; individual facades, interiors and decorative detail can be added in priority order.

The player should eventually be able to:

- walk, run and drive around the town, with simple mobile touch controls
- enter and leave a small number of drivable vehicles
- recognise and visit real-world pubs, shops, hotels, restaurants and other points of interest
- enter selected businesses with bespoke interiors and interactions
- meet fictional NPCs and follow missions, jobs and local storylines
- earn and spend money, discover places and build a personal story in town
- trigger a fictional Garda response or wanted system when causing trouble, clearly presented as game fiction

Real businesses and real people must not be portrayed as endorsing, committing or being associated with fictional wrongdoing. Businesses can be represented neutrally, and fictional businesses, characters and story events can be added wherever the game needs them.

The target feel is a warm, recognisable, stylised Irish town sandbox: geographically accurate enough to spark the joy of knowing Westport, but playful enough to support exploration, missions and emergent moments with friends. The mobile app and its game-specific website are the intended way to access and share the finished project.

## Prototype setup

For the current desktop 3D test, open `godot/project.godot` with Godot 4.7.2 and run the project. The Godot scene generates a small 3D central-Westport greybox at runtime, including roads, the Octagon, a stylised Clock Tower landmark, buildings, a player character and a car placeholder. This is the first proper 3D foundation; geographic data and authored landmark assets are the next quality pass.

The original Unity scaffolding remains under `Assets/` for reference, but Godot is now the active engine path because it avoids the Unity Hub authentication and installer problems on this machine.

For a phone test, serve the `web/` folder from an HTTPS static host and open its URL on your phone. It is an installable PWA with touch controls; the landing page offers installation when supported. The app icon is `web/assets/westport-logo.png`.
