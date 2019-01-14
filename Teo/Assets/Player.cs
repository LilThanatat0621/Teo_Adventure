using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 1f;
	public float jumpSpeed = 9f;
	public float maxSpeed = 10f;
	public float jumpPower = 20f;
	public bool grounded;

	public float jumpRate = 1f;
	public float nextJumpPress = 0.0f;
	public float fireRate = 0.3f;
	private float nextFire = 0.0f;

	private Rigidbody2D rigidbody2d;
	private Physics2D physics2d;
	private Animator anim;

	public GameLogic control;
	public GameObject HitArea;

	public int healthBar = 100;

	void Start () {
		rigidbody2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		anim.SetBool ("Grounded", true);
		anim.SetBool ("Jump", false);
		anim.SetBool ("Attack", false);
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		} else if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		}
		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

		if (Input.GetKey (KeyCode.P) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			anim.SetBool ("Attack", true);
			Fire ();
		}
	}
	public void Jump () {
		if (Time.time > nextJumpPress) {
			anim.SetBool ("Jump", true);
			nextJumpPress = Time.time + jumpRate;
			rigidbody2d.AddForce ((Vector2.up * jumpPower) * jumpSpeed);
		}
	}
	public void Walk () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
	}

	void Fire () {
		Instantiate (HitArea, transform.position, transform.rotation);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "coin(Clone)") {
			//+Health,score
			Debug.Log ("coin");
			control.GetItems ();
			Destroy (other.gameObject);
		} else if (other.gameObject.name == "Enemy(Clone)") {
			//-Health
			control.CrashFire ();

			healthBar -= 20;

			if (healthBar <= 0) {
				healthBar = 0;
				StartCoroutine (WaitDeath ());
			}
		} else if (other.gameObject.name == "danger") {
			StartCoroutine (WaitDeath ());
		}

	}
	IEnumerator WaitDeath () {
		yield return new WaitForSeconds (2);
		anim.SetTrigger ("Death");
		RectTransform rectTransform = GetComponent<RectTransform> ();
		rectTransform.Rotate (new Vector3 (0, 0, 90));
		control.isGameOver = true;
	}
	void OnGUI () {
		GUI.backgroundColor = Color.red;
		GUI.Button (new Rect (Screen.width - (Screen.width - 65),
				12, (healthBar / 2),
				20),
			"");
	}
}