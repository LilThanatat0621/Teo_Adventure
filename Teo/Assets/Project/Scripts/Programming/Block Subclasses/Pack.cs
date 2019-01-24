using UnityEngine;
using System.Collections;

public class Pack : SimpleInscructionBlock {
    
    override public void Run(){
        Block[] allChildren =this.transform.GetComponentsInChildren<Block>();
        // Code.GetComponent<BeepBlock>().Run();
        // Debug.Log(Code);
        foreach (Block child in allChildren) {
            // Debug.Log (child.gameObject);
            if(child.isStartBlock)child.Run();
        }
        if(Next!=null)Next.Run();
    }
}
