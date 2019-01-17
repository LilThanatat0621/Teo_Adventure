using System.Collections;
using UnityEngine;

public class IfThenBlock : Block {
	public PositionFloor1Script getx1;
	override public void Run () {
		if (If != null) {
			if (If.CheckCond()) {
			// if(getx1.getDistance()<=0.1)
				if(Inside1!=null)Inside1.Run ();
			}
		}
		if (Next != null) Next.Run ();
		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}
	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (35, 83), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (35, 3), Connection.ConnectionType.Next);
		Connection thenConnection = new Connection (this, new Vector2 (45, 60), Connection.ConnectionType.Inside1);
		Connection conditionConnection = new Connection (this, new Vector2 (35, 75), Connection.ConnectionType.If);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		thenConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		conditionConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);

		this.connections.Add (previousConnection);

		this.connections.Add (thenConnection);
		this.connections.Add (conditionConnection);

		this.connections.Add (nextConnection);
	}
}