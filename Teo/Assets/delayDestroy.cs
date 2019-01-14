using UnityEngine;
using System.Collections;

public class delayDestroy : MonoBehaviour {
	float SecondsUntilDestroy = 5f;
	float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= SecondsUntilDestroy) {
			Destroy(this.gameObject);
		}
	}
}
