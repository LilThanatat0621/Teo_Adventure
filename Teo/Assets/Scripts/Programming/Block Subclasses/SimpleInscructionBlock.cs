using System.Collections;
using UnityEngine;

public class SimpleInscructionBlock : Block {
	override public void Run () {
		Debug.Log ("Simple\n");
		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}

	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (35, 42), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (35, 4), Connection.ConnectionType.Next);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);

		this.connections.Add (previousConnection);

		this.connections.Add (nextConnection);
	}
}