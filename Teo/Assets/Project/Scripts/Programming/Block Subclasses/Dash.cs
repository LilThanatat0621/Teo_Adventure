using UnityEngine;
using System.Collections;

public class Dash : SimpleInscructionBlock {
    
    override public void Run(){
        Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
        Player.Dash();
        if(Next!=null)Next.Run();
    }
}
