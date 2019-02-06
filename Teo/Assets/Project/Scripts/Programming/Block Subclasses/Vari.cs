﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Vari : Block {
	public string var;
	public Walker get;
	public EnemyDrop get2;
	public Text childText;
	public PositionFloor1Script get3;
	public bool isY;
	override public double GetValue () {
		// Debug.Log(get.getDistance());
		// Debug.Log(get.getDistance());
		if (get != null) return get.getDistance ();
		if (get2 != null) return get2.getDistance ();
		if (get3 != null) {
			if (!isY) {
				// Debug.Log(get3.getDistance ());
				// if(get3.getDistance ()==0)Debug.Break();
				return get3.getDistance ();
			} else return get3.getDistanceY ();
		}

		return 1000;
	}
	// private void Start() {
	// 	childText.text=name;
	// }

	private void Update () {
		if (get == null && get2 == null && get3 == null) {
			if (GameObject.FindWithTag ("DangerBullet") != null) get3 = GameObject.FindWithTag ("DangerBullet").GetComponent<PositionFloor1Script> ();
		}
	}
	override protected void CreateConnections () {
		var = childText.text;
		this.blockType = BlockType.BlockTypeNumeric;
		Connection previousConnection = new Connection (this, new Vector2 (50, 50), Connection.ConnectionType.Previous);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);

		this.connections.Add (previousConnection);

	}
}