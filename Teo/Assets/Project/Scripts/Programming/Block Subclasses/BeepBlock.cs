using UnityEngine;
using System.Collections;

public class BeepBlock : SimpleInscructionBlock {
    
    override public void Run(){
        Debug.Log("Beep\n");
        if(Next!=null)Next.Run();
    }
}
