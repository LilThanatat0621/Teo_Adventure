using UnityEngine;
using System.Collections;

public class Firez : SimpleInscructionBlock {
    
    override public void Run(){
        Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
        Player.Firez();
        if(Next!=null)Next.Run();
    }
}
