using Godot;
using System;

public partial class BlockGenerator : Node3D
{
	private readonly static PackedScene Block =
		GD.Load<PackedScene>("res://scenes/block/block.tscn");

	private MeshInstance3D _mesh;

	private string[] _level =
	{
		"00111100",
		"01111110",
		"11100111",
		"11000011",
		"11111111"
	};

	public override void _Ready()
	{
		using Block blockRef = Block.Instantiate<Block>();
		_mesh = blockRef.GetNode<MeshInstance3D>("%MeshInstance3D");
		float blockWidth = _mesh.GetAabb().Size.X;
		float blockHeight = _mesh.GetAabb().Size.Z;
		float offset = 0.2f;
		float positionZ = 0;
		var targetBlocksPos = GlobalPosition;
		foreach(string l in _level)
		{
			float positionX = 0;

			for (int i = 0; i < l.Length; i++)
			{
				positionX += blockWidth + offset;
				if(l[i] == '1')
				{
					Block block = Block.Instantiate<Block>();
					block.Position = new Vector3(positionX, 0, positionZ);
					AddChild(block);
				}
			}

			positionZ += blockHeight + offset;
			targetBlocksPos.X = (-positionX / 2) - blockWidth / 2;
		}
		targetBlocksPos.Z = targetBlocksPos.Z + (-positionZ / 2) - blockHeight / 2;
		GlobalPosition = targetBlocksPos;
	}
}
