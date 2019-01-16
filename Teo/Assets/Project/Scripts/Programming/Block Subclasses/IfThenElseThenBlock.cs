using System.Collections;
using UnityEngine;

public class IfThenElseThenBlock : Block {
	override public void Run () {
		Debug.Log ("ifThenElse\n");
		if (If != null) {
			if (If.CheckCond ()) {
				if (Inside1 != null) Inside1.Run ();
			} else {
				if (Inside2 != null) Inside2.Run ();
			}
		}
		if (Next != null) Next.Run ();
		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}
	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (35, 83), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (35, 3), Connection.ConnectionType.Next);
		Connection thenConnection = new Connection (this, new Vector2 (107, 43), Connection.ConnectionType.Inside1);
		Connection elseConnection = new Connection (this, new Vector2 (189, 43), Connection.ConnectionType.Inside2);
		Connection conditionConnection = new Connection (this, new Vector2 (72, 67), Connection.ConnectionType.If);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		thenConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		elseConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		conditionConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);

		this.connections.Add (previousConnection);

		this.connections.Add (thenConnection);
		this.connections.Add (elseConnection);
		this.connections.Add (conditionConnection);

		this.connections.Add (nextConnection);
	}
}