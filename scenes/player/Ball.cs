using Godot;
using System;

public partial class Ball : CharacterBody3D
{
	private Vector3 _direction = new Vector3(0f, 0f, 10f);

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = _direction;

		var collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null)
		{
			_direction = Velocity.Bounce(collision.GetNormal());
			
			var hitPoint = collision.GetPosition();
			if (collision.GetCollider() is Player player)
			{
				var playerMesh = player.GetChild<MeshInstance3D>(0);
				var hitPosition = (collision.GetPosition().X - player.GlobalPosition.X) / playerMesh.GetAabb().Size.X / 2;
				_direction = new Vector3(hitPosition * 50f, 0f, -10f);
			}
		}
	}
}
