using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
    // Start is called before the first frame update
    public float jumpSpeed = 9f;
    public int fireRate = 10;
    int temp = 0;
    public GameObject HitArea;
    public float jumpPower = 20f;
    private Rigidbody2D rigidbody2d;
    void Start () {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (temp >= fireRate) {
            temp = 0;
            Instantiate (HitArea, new Vector3 (transform.position.x - 1.5f, transform.position.y + 0.25f, transform.position.z), Quaternion.Euler (0, 180, 0));
        }
    }

    public void Fire () {
        temp++;

    }
    public void Jump () {
        rigidbody2d.AddForce ((Vector2.up * jumpPower) * jumpSpeed);
    }

}