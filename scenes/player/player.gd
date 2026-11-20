class_name Player
extends CharacterBody3D

var speed : float = 10.0


func _ready() -> void:
	pass # Replace with function body.


func _process(delta: float) -> void:
	var direction : int = 0
	if (Input.is_action_pressed("ui_left")):
		direction = -1
	if (Input.is_action_pressed("ui_right")):
		direction = 1
			
	velocity = Vector3(direction * speed, 0.0, 0.0)
	position += velocity * delta
	position.y = 0
	position.z = 0
	move_and_slide()
