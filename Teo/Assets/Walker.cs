using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour {
public float walkSpeed = 3.0f;
	
	public float walkTime;
	private float walkingDirection = -1.0f;
	public bool facing = true;
	Vector3 walkAmount;
	void Update () {
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		walkTime+=Time.deltaTime;
		 if ( walkTime >=6 ){
			 walkingDirection *= -1.0f;
			 walkTime=0;
			facing = !facing;
		 }
		  if(!facing){
				  transform.eulerAngles = new Vector2 (0, 180);
				  
			 }
			 if(facing){
				  transform.eulerAngles = new Vector2 (0, 0);
				  
			 }

		
		//  else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
		// 	 walkingDirection = 1.0f;
        transform.Translate(walkAmount);
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Bullet(Clone)")
		{
			Destroy(other.gameObject);
			// Instantiate(Explode, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
