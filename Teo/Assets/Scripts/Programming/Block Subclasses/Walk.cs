using UnityEngine;
using System.Collections;

public class Walk : SimpleInscructionBlock {
    
    override public void Run(){
        Debug.Log("Walk\n");
        Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
        Player.Walk();
        if(Next!=null)Next.Run();
    }
}
