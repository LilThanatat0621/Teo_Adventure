using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ComparatorBlock : Block {
	public InputField Field1, Field2;
	public enum ComparatorType {
		ComparatorTypeNone,
		ComparatorTypeLessThan,
		ComparatorTypeLessThanOrEqual,
		ComparatorTypeEqual,
		ComparatorTypeGreaterThan,
		ComparatorTypeGreaterThanOrEqual,
		ComparatorTypeDifferent
		};
		override public void Run () {
		// Debug.Log("Compare\n");
		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}
	override public bool CheckCond () {
		double value1, value2;
		if (Inside1 != null) {
			value1 = Inside1.GetValue ();
		} else {
			if (Field1.text == "") Field1.text = "0";
			value1 = double.Parse (Field1.text);
		}
		if (Inside2 != null) {

			value2 = Inside2.GetValue ();
		} else {
			if (Field2.text == "") Field2.text = "0";
			value2 = double.Parse (Field2.text);
		}
		if(comparator.value==0)return value1==value2;
		if(comparator.value==1)return value1>value2;
		if(comparator.value==2)return value1<value2;
		if(comparator.value==3)return value1>=value2;
		if(comparator.value==4)return value1<=value2;
		if(comparator.value==5)return value1!=value2;
		return false;

	}
	public ComparatorType comparatorType;
	public Dropdown comparator;
	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeLogic;
		Connection previousConnection = new Connection (this, new Vector2 (50, 11), Connection.ConnectionType.Previous);
		// Connection nextConnection = new Connection (this, new Vector2 (199, 20), Connection.ConnectionType.ConnectionTypeMale);
		Connection insi1 = new Connection (this, new Vector2 (11, 11), Connection.ConnectionType.ConnectionTypeMale);
		Connection insi2 = new Connection (this, new Vector2 (88, 11), Connection.ConnectionType.ConnectionTypeMale);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution | BlockType.BlockTypeConditionJoint);
		// nextConnection.SetAcceptableBlockType (BlockType.BlockTypeConditionJoint);
		insi1.SetAcceptableBlockType(BlockType.BlockTypeNumeric);
		insi2.SetAcceptableBlockType(BlockType.BlockTypeNumeric);
		this.connections.Add (previousConnection);
		this.connections.Add(insi1);
		this.connections.Add(insi2);
		// this.connections.Add (nextConnection);
	}
}