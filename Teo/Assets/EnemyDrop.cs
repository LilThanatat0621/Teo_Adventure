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
    GameObject Child;
    public double hangY;
    AudioSource audio;
    void Start () {
        GameObject Rhombus = Resources.Load<GameObject> ("Rhombus");
        Child = Instantiate (Rhombus) as GameObject;
        Child.transform.SetParent (textMesh.gameObject.transform);
        hangY = Child.GetComponent<SpriteRenderer> ().sprite.bounds.size.y/2;
        player = GameObject.FindWithTag ("Player").transform;
        temp = textMesh.text;
        textMesh.font = Resources.Load<Font> ("SuperMario256");
        textMesh.characterSize = 0.3f;
        textMesh.color = Color.red;
        MeshRenderer rend = gameObject.GetComponentInChildren<MeshRenderer> ();
        rend.material = textMesh.font.material;
        // ThisPos = this.gameObject.GetComponent<Transform> ();
        ThisPos.gameObject.GetComponent<MeshRenderer> ().sortingOrder = 5;
        ThisPos.gameObject.transform.localPosition = new Vector2 (ThisPos.gameObject.transform.localPosition.x, ThisPos.gameObject.transform.localPosition.y + (float) hangY);
        PlayerPos = player;
        audio = GetComponent<AudioSource> ();
    }
    public int getDistance () {
        if (distance <= 0) distance *= -1;
        return (int) (distance * 10);

    }
    public int getDistanceY () {
        double dis = (PlayerPos.position.y - ThisPos.position.y);
        if (dis <= 0) dis *= -1;
        dis -= hangY;
        if (dis <= 0) dis *= -1;
        return (int) (dis * 10);

    }

    // Update is called once per frame
    void Update () {
        distance = PlayerPos.position.x - ThisPos.position.x;
        if (show) textMesh.text = (temp + " = " + (getDistance ()).ToString ("0"));
        else textMesh.text = "";
        Child.SetActive (show);
        if (player.position.x - transform.position.x >= -0.2) {
            this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            if (audio != null) { audio.Play (); audio = null; }
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