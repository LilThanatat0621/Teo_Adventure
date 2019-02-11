using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 6f;
	public float SecondsUntilDestroy = 0.16f;
	float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
		if (Time.time - startTime >= SecondsUntilDestroy) {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D other) {
		// Debug.Log("On trigger enter activated!"+other.gameObject.name);
		if (other.gameObject != this.gameObject&&other.gameObject.name!="Redar"&&other.gameObject.name!="Model")
			Destroy (this.gameObject);

	}
}