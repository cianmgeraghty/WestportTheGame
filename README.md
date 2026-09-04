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

## Prototype setup

Open the repository as a Unity 2022.3 LTS project and open `Assets/Scenes/WestportPrototype.unity`. Press Play: the scene builds a small greybox automatically. Use `WASD`/arrow keys to move, `Shift` to run, and `E` near the car to enter or exit. This is intentionally art-free scaffolding; the next pass will replace the generated roads and building blocks with imported geographic data.
