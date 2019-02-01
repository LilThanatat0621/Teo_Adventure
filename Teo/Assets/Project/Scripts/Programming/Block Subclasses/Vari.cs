using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Vari : Block {
	public string var;
	public Walker get;
	public EnemyDrop get2;
	public Text childText;
	override public double GetValue () {
		// Debug.Log(get.getDistance());
		// Debug.Log(get.getDistance());
		if(get!=null) return get.getDistance();
		if(get2!=null) return get2.getDistance();
		
		return 1000;
	}
	// private void Start() {
	// 	childText.text=name;
	// }
	override protected void CreateConnections () {
		var=childText.text;
		this.blockType = BlockType.BlockTypeNumeric;
		Connection previousConnection = new Connection (this, new Vector2 (50, 50), Connection.ConnectionType.Previous);
	

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);


		this.connections.Add (previousConnection);


	}
}