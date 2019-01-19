using System.Collections;
using UnityEngine;

public class StartBlock : Block {
	override public void Run () {
		if(Next!=null)Next.Run();
	}

	override protected void CreateConnections () {
		this.isStartBlock=true;
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (35, 42), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (12, 1), Connection.ConnectionType.Next);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeStart);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);

		this.connections.Add (previousConnection);

		this.connections.Add (nextConnection);
	}
}