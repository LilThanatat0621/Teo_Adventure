using UnityEngine;
using System.Collections;

public class Jump : SimpleInscructionBlock {
    
    override public void Run(){
        Debug.Log("Jump\n");
        Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
        Player.Jump();
        if(Next!=null)Next.Run();
    }
}
