using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {
    // Start is called before the first frame update
    public Transform player;
    bool show = false;
    void Start () {

    }
    public double getDistance () {
        double distance = 0;
        distance = player.position.x - transform.position.x;
        if (distance <= 0) distance *= -1;
        return distance * 10;

    }

    // Update is called once per frame
    void Update () {
        if (player.position.x - transform.position.x>=-0.2) {
            this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
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

        if (other.tag == "Player") {
            other.gameObject.GetComponent<Player> ().Die ();

        }
    }
}