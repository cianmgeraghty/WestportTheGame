extends Node3D

const ROAD := Color("#303d43")
const GROUND := Color("#9ab7a7")
const HOUSE := [Color("#c67b5a"), Color("#d1a35d"), Color("#6f9b9d"), Color("#b96a57")]
var player: CharacterBody3D
var camera: Camera3D

func material(color: Color) -> StandardMaterial3D:
	var m := StandardMaterial3D.new()
	m.albedo_color = color
	m.roughness = 0.88
	return m

func box(parent: Node3D, pos: Vector3, size: Vector3, color: Color, label: String) -> void:
	var node := MeshInstance3D.new()
	node.name = label
	var mesh := BoxMesh.new()
	mesh.size = size
	node.mesh = mesh
	node.material_override = material(color)
	node.position = pos
	parent.add_child(node)

func cylinder(parent: Node3D, pos: Vector3, radius: float, height: float, color: Color, label: String) -> void:
	var node := MeshInstance3D.new()
	node.name = label
	var mesh := CylinderMesh.new()
	mesh.top_radius = radius
	mesh.bottom_radius = radius
	mesh.height = height
	node.mesh = mesh
	node.material_override = material(color)
	node.position = pos
	parent.add_child(node)

func _ready() -> void:
	build_world()
	build_player()

func build_world() -> void:
	var world := Node3D.new()
	world.name = "CentralWestport"
	add_child(world)
	var environment := WorldEnvironment.new()
	var sky := Environment.new()
	sky.background_mode = Environment.BG_COLOR
	sky.background_color = Color("#173b50")
	sky.ambient_light_source = Environment.AMBIENT_SOURCE_COLOR
	sky.ambient_light_color = Color("#b7d4d0")
	sky.ambient_light_energy = 0.7
	environment.environment = sky
	world.add_child(environment)
	var sun := DirectionalLight3D.new()
	sun.rotation_degrees = Vector3(-52, -28, 0)
	sun.light_color = Color("#ffe1ad")
	sun.light_energy = 1.2
	sun.shadow_enabled = true
	world.add_child(sun)
	box(world, Vector3(0, -0.2, 0), Vector3(150, 0.4, 150), GROUND, "TownGround")
	box(world, Vector3(0, 0, 0), Vector3(14, 0.12, 150), ROAD, "BridgeStreet")
	box(world, Vector3(0, 0.02, 0), Vector3(150, 0.14, 14), ROAD, "ShopStreet")
	box(world, Vector3(0, 0.05, 0), Vector3(34, 0.2, 34), Color("#455158"), "TheOctagon")
	for i in range(-6, 7):
		box(world, Vector3(i * 10.0, 0.14, 0), Vector3(4, 0.03, 0.18), Color("#e5b84c"), "RoadMark")
		box(world, Vector3(0, 0.14, i * 10.0), Vector3(0.18, 0.03, 4), Color("#e5b84c"), "RoadMark")
	var positions := [Vector3(-34, 5, -38), Vector3(34, 7, -38), Vector3(-38, 4, 35), Vector3(38, 6, 35), Vector3(-52, 4, -5), Vector3(52, 5, 5)]
	for i in positions.size():
		var p: Vector3 = positions[i]
		var size := Vector3(22, p.y * 2.0, 28) if abs(p.x) < 45 else Vector3(18, p.y * 2.0, 22)
		box(world, Vector3(p.x, size.y / 2.0, p.z), size, HOUSE[i % HOUSE.size()], "Building_%02d" % i)
	# Stylised Clock Tower landmark at the Octagon.
	box(world, Vector3(0, 5, -7), Vector3(4.5, 10, 4.5), Color("#a8a59a"), "WestportClockTower")
	cylinder(world, Vector3(0, 11.5, -7), 2.5, 3, Color("#343f43"), "ClockTowerRoof")
	box(world, Vector3(0, 8.2, -4.72), Vector3(2.2, 2.2, 0.12), Color("#f2d28a"), "ClockFace")
	box(world, Vector3(0, 8.2, -4.8), Vector3(0.12, 1.4, 0.14), Color("#273237"), "ClockHand")
	box(world, Vector3(0, 14, -7), Vector3(0.25, 2.2, 0.25), Color("#efb84b"), "ClockSpire")
	box(world, Vector3(10, 1, 10), Vector3(3.6, 1.4, 7), Color("#c94b43"), "DrivableCar")
	box(world, Vector3(10, 1.9, 10), Vector3(2.7, 0.8, 3.2), Color("#9bc2c4"), "CarCabin")

func build_player() -> void:
	player = CharacterBody3D.new()
	player.name = "Player"
	player.position = Vector3(0, 1.1, 24)
	add_child(player)
	var body := MeshInstance3D.new()
	var mesh := CapsuleMesh.new()
	mesh.radius = 0.45
	mesh.height = 1.8
	body.mesh = mesh
	body.material_override = material(Color("#efb84b"))
	player.add_child(body)
	var collision := CollisionShape3D.new()
	var capsule := CapsuleShape3D.new()
	capsule.radius = 0.45
	capsule.height = 1.8
	collision.shape = capsule
	player.add_child(collision)
	camera = Camera3D.new()
	camera.position = Vector3(0, 5.5, 8.5)
	camera.current = true
	player.add_child(camera)
	camera.look_at(player.position + Vector3(0, 1, -8))

func _physics_process(_delta: float) -> void:
	if not player:
		return
	var input := Input.get_vector("move_left", "move_right", "move_forward", "move_back")
	var direction := Vector3(input.x, 0, input.y)
	player.velocity = direction * 5.0
	player.move_and_slide()
	player.position.y = 1.1
	if direction.length() > 0.1:
		player.rotation.y = lerp_angle(player.rotation.y, atan2(direction.x, direction.z), 0.18)
		camera.look_at(player.position + Vector3(0, 1, 0))
