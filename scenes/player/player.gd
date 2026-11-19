class_name Player
extends CharacterBody2D

var speed : float = 5.0


func _ready() -> void:
	pass # Replace with function body.


func _process(delta: float) -> void:
	var direction : int = 0
	if (Input.is_action_just_pressed("ui_left")):
		direction = -1
	if (Input.is_action_just_pressed("ui_right")):
		direction = 1
			
	velocity = Vector2(direction * speed, 0.0)
	position += velocity * delta
	move_and_slide()
