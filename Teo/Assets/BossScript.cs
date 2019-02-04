using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
    // Start is called before the first frame update
    public float jumpSpeed = 9f;
    public float jumpPower = 20f;
    private Rigidbody2D rigidbody2d;
    void Start () {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void Jump () {
        rigidbody2d.AddForce ((Vector2.up * jumpPower) * jumpSpeed);
    }

}