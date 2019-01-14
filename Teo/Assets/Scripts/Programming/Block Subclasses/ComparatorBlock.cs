using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ComparatorBlock : Block {
	public InputField Field1,Field2;
	public enum ComparatorType {
		ComparatorTypeNone,
		ComparatorTypeLessThan,
		ComparatorTypeLessThanOrEqual,
		ComparatorTypeEqual,
		ComparatorTypeGreaterThan,
		ComparatorTypeGreaterThanOrEqual,
		ComparatorTypeDifferent
	};
	override public void Run(){
        Debug.Log("Compare\n");
        // if(this.nextConnection.cone!=null)Log("Beep2\n")
    }
	override public bool CheckCond(){
        Debug.Log("Compare\n");
		double value1,value2;
		if(Inside1!=null){
			value1=Inside1.GetValue();
		}else{
			if(Field1.text=="")Field1.text="0";
			value1=double.Parse(Field1.text);
		}
		if(Inside2!=null){
			
			value2=Inside2.GetValue();
		}else{
			if(Field2.text=="")Field2.text="0";
			value2=double.Parse(Field2.text);
		}

		return value1==value2;
        
    }
	public ComparatorType comparatorType;

	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeLogic;
		Connection previousConnection 	= new Connection(this, new Vector2(2, 20), Connection.ConnectionType.Previous);
		Connection nextConnection 		= new Connection(this, new Vector2(199, 20), Connection.ConnectionType.ConnectionTypeMale);
		
		previousConnection.SetAcceptableBlockType(BlockType.BlockTypeInscrution | BlockType.BlockTypeConditionJoint);
		nextConnection.SetAcceptableBlockType(BlockType.BlockTypeConditionJoint);

		this.connections.Add(previousConnection);
		
		this.connections.Add(nextConnection);
	}
}
