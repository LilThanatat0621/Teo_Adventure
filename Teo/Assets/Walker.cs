using System.Collections;
using UnityEngine;

public class Walker : MonoBehaviour {
	public float walkSpeed = 3.0f;
	bool show = false;
	public float walkTime, length;
	public Transform ThisPos, PlayerPos;
	double distance;
	private float walkingDirection = 1.0f;
	public bool facing = true;
	Vector3 walkAmount;
	public string temp;
	public TextMesh textMesh;
	public int hp = 5;

	void Start () {
		temp = textMesh.text;
		// ThisPos = this.gameObject.GetComponent<Transform> ();
		ThisPos.gameObject.GetComponent<MeshRenderer> ().sortingOrder = 5;
	}

	public double getDistance () {
		if (distance <= 0) distance *= -1;
		return distance * 10;

	}
	void Update () {
		distance = PlayerPos.position.x - ThisPos.position.x;
		if (show) textMesh.text = (temp + " = " + (getDistance ()).ToString ("0.00"));
		else textMesh.text = "";

		if (hp <= 0) Destroy (this.gameObject);
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		walkTime += Time.deltaTime;
		if (walkTime >= length) {
			//  walkingDirection *= -1.0f;
			walkTime = 0;
			facing = !facing;
		}
		if (!facing) {
			transform.eulerAngles = new Vector2 (0, 180);
			ThisPos.eulerAngles = new Vector2 (0, 180);

		}
		if (facing) {
			transform.eulerAngles = new Vector2 (0, 0);
			ThisPos.eulerAngles = new Vector2 (0, 180);
		}

		//  else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
		// 	 walkingDirection = 1.0f;

		transform.Translate (walkAmount);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name == "Redar")
			show = true;

	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name == "Redar")
			show = false;

	}
	void OnTriggerEnter2D (Collider2D other) {
		// Debug.Log(other.tag);
		if (other.tag == "bullet") {
			Destroy (other.gameObject);
			// Instantiate(Explode, transform.position, transform.rotation);
			hp--;
		}
		if (other.tag == "Player") {
			other.gameObject.GetComponent<Player> ().Die ();
			// Instantiate(Explode, transform.position, transform.rotation);

		}
	}
}