using Godot;
using System;

public partial class Ball : CharacterBody3D
{
	private Vector3 _direction = new Vector3(0f, 0f, 10f);
	private float _angleStrength = 10f;

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
				var playerMesh = player.mesh;
				var halfWidth = playerMesh.GetAabb().Size.X / 2f;

				var hitPosition =
					(hitPoint.X - player.GlobalPosition.X)
					/ halfWidth;

				_direction = new Vector3(hitPosition * _angleStrength, 0f, -10f).Normalized() * 10f;
			}

			if (collision.GetCollider() is Block block)
			{
				block.Hit();
			}
		}
	}
}
