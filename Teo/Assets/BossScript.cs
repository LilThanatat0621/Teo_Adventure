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
    public int live = 5;
    bool isDie = false;
    void Start () {
        fireRate = 10;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (temp >= fireRate && !isDie) {
            temp = 0;
            Instantiate (HitArea, new Vector3 (transform.position.x - 1.5f, transform.position.y + 0.25f, transform.position.z), Quaternion.Euler (0, 180, 0));
        }
        if (live <= 0) {
            if (!isDie) Die ();
            isDie = true;
        }

    }
    void Die () {
        rigidbody2d.AddForce ((Vector2.up * jumpPower) * jumpSpeed * 3);
        this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
    }
    public void Fire () {
        temp++;

    }
    public void Jump () {
        if (!isDie) rigidbody2d.AddForce ((Vector2.up * jumpPower) * jumpSpeed);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "bullet") {
            live--;
            this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
            StartCoroutine (WaitRestore ());
        }
    }

    IEnumerator WaitRestore () {
        yield return new WaitForSeconds (0.1f);
        this.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
    }
    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.name == "danger") {
            Destroy (this.gameObject);
        }
    }

}