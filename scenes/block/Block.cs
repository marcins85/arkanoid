using Godot;
using System;

public partial class Block : StaticBody3D
{
	public override void _Ready()
	{
				
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Hit()
	{
		QueueFree();
	}
}
