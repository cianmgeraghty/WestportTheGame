extends Control
signal vector_changed(value: Vector2)

var finger := -1
var value := Vector2.ZERO

func _ready() -> void:
	custom_minimum_size = Vector2(160, 160)
	mouse_filter = Control.MOUSE_FILTER_STOP
	queue_redraw()

func _draw() -> void:
	var centre := size * 0.5
	draw_circle(centre, 70.0, Color(0.02, 0.1, 0.15, 0.62))
	draw_arc(centre, 70.0, 0, TAU, 48, Color(0.94, 0.72, 0.29, 0.6), 2.0)
	draw_circle(centre + value * 42.0, 25.0, Color(0.94, 0.72, 0.29, 0.95))

func update_from_position(position: Vector2) -> void:
	var centre := size * 0.5
	value = (position - centre) / 55.0
	if value.length() > 1.0:
		value = value.normalized()
	vector_changed.emit(value)
	queue_redraw()

func _gui_input(event: InputEvent) -> void:
	if event is InputEventScreenTouch:
		if event.pressed and finger == -1:
			finger = event.index
			update_from_position(event.position)
		elif not event.pressed and event.index == finger:
			finger = -1
			value = Vector2.ZERO
			vector_changed.emit(value)
			queue_redraw()
	elif event is InputEventScreenDrag and event.index == finger:
		update_from_position(event.position)
