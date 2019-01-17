using System.Collections;
using UnityEngine;

public class IfThenElseThenBlock : Block {
	public PositionFloor1Script getx1;
	override public void Run () {
		if (If != null) {
			if (If.CheckCond ()) {

				if (Inside1 != null) Inside1.Run ();
				else {
					if (Inside2 != null) Inside2.Run ();
				}
			}
		}
		if (Next != null) Next.Run ();
		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}
	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (36, 105), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (58, 100), Connection.ConnectionType.Next);
		Connection thenConnection = new Connection (this, new Vector2 (58.5f, 50), Connection.ConnectionType.Inside1);
		Connection conditionConnection = new Connection (this, new Vector2 (87, 103), Connection.ConnectionType.If);

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