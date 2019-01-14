// using UnityEngine;
// using System.Collections;

// public class Walker : MonoBehaviour {
// public float walkSpeed = 3.0f;
// 	public float wallLeft = 0.0f;
// 	public float wallRight = 5.0f;
// 	public float walkingDirection = 1.0f;
// 	public Explode;
// 	Vector3 walkAmount;
// 	void Update () {
// 		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
// 		 if (walkingDirection > 0.0f && transform.position.x >= wallRight)
// 			 walkingDirection = -1.0f;
// 		 else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
// 			 walkingDirection = 1.0f;
//         transform.Translate(walkAmount);
// 	}
// 	void OnTriggerEnter2D(Collider2D other)
// 	{
// 		if(other.gameObject.name == "Bullet(Clone)")
// 		{
// 			Destroy(other.gameObject);
// 			Instantiate(Explode, transform.position, transform.rotation);
// 			Destroy(this.gameObject);
// 		}
// 	}
// }
