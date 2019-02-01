using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {
    // Start is called before the first frame update
    public Transform player;
    bool show = false;
    public Transform ThisPos, PlayerPos;
    double distance;
    Vector3 walkAmount;
    public string temp;
    public TextMesh textMesh;

    void Start () {
        temp = textMesh.text;
        // ThisPos = this.gameObject.GetComponent<Transform> ();
        ThisPos.gameObject.GetComponent<MeshRenderer> ().sortingOrder = 5;
        PlayerPos=player;
    }
    public double getDistance () {
        if (distance <= 0) distance *= -1;
        return distance * 10;

    }

    // Update is called once per frame
    void Update () {
        distance = PlayerPos.position.x - ThisPos.position.x;
        if (show) textMesh.text = (temp + " = " + (getDistance ()).ToString ("0.00"));
        else textMesh.text = "";

        if (player.position.x - transform.position.x >= -0.2) {
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