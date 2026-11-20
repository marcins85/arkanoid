using Godot;
using System;

public partial class Player : CharacterBody3D
{
	private static float _speed = 10.0f;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		int direction = 0;

		if (Input.IsActionPressed("ui_left"))
		{
			direction = -1;
		}
		if (Input.IsActionPressed("ui_right"))
		{
			direction = 1;
		}

		Velocity = new Vector3(direction * _speed, 0.0f, 0.0f);
		var targetPosition = Position;
		targetPosition += Velocity * (float)delta;
		targetPosition.Y = 0.0f;
		targetPosition.Z = 9.0f;
		Position = targetPosition;
		MoveAndSlide();
	}
}
