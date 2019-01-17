using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Vari : Block {
	public string var;
	public PositionFloor1Script get;
	public Text childText;
	override public double GetValue () {
		Debug.Log(get.getDistance());
		return get.getDistance();
	}
	// private void Start() {
	// 	childText.text=name;
	// }
	override protected void CreateConnections () {
		var=childText.text;
		this.blockType = BlockType.BlockTypeNumeric;
		Connection previousConnection = new Connection (this, new Vector2 (26.82f/2, 16.62f/2), Connection.ConnectionType.Previous);
	

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);


		this.connections.Add (previousConnection);


	}
}