using System.Collections;
using UnityEngine;

public class While : Block {
	
	bool canRun = false, canNext = false;
	override public void Run () {

		if(If!=null)canRun = If.CheckCond();
		// for (int i=0;i<10;i++) {
		// 	// if (If.CheckCond()) {
		// 		if(Inside1!=null)Inside1.Run ();
		// 	// }
		// }

		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}

	private void FixedUpdate () {
		if (canRun) {
			canNext = true;
			if (Inside1 != null) Inside1.Run ();
		} else if (canNext) {
			canNext = false;
			if (Next != null) Next.Run ();
		}
	}

	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (35, 80), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (32, 23), Connection.ConnectionType.Next);
		Connection thenConnection = new Connection (this, new Vector2 (58.5f, 50), Connection.ConnectionType.Inside1);
		// Connection conditionConnection = new Connection (this, new Vector2 (35, 75), Connection.ConnectionType.If);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		thenConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		// conditionConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);

		this.connections.Add (previousConnection);

		this.connections.Add (thenConnection);
		// this.connections.Add (conditionConnection);

		this.connections.Add (nextConnection);
	}
}