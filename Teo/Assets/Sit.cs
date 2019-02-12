using UnityEngine;
using System.Collections;

public class Sit : SimpleInscructionBlock {
    
    override public void Run(){
        // Debug.Log("Walk\n");
        Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
        Player.Sit();
        if(Next!=null)Next.Run();
    }
}
