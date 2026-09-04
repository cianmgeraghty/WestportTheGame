# v0.1 roadmap

1. Define and document the central-Westport boundary.
2. Import attributed road, path, building-footprint, water, and landmark data.
3. Convert geographic coordinates to a Unity metre-based world.
4. Generate terrain, roads, bridges, and placeholder building masses.
5. Add third-person walking and mobile controls.
6. Add one drivable car with enter/exit interaction.
7. Replace priority placeholders with recognisable Westport landmarks and facades.

## Current implementation

The repository now includes the first reusable gameplay scripts: `GeoReference` for WGS84-to-Unity coordinates, `ThirdPersonWalker` for third-person movement, and `SimpleCarController`/`VehicleInteractor` for the first drivable-car loop.

## Out of scope for v0.1

Missions, combat, police/Garda systems, traffic AI, NPC schedules, business interiors, and photorealistic assets.
