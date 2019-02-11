using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFloor1Script : MonoBehaviour {
    // Start is called before the first frame update\
    bool show = false;
    Transform ThisPos, PlayerPos;
    double distance;
    string temp;
    TextMesh textMesh;
    GameObject Child;
    public double hangY;
    void Start () {

        GameObject Rhombus = Resources.Load<GameObject> ("Rhombus");
        Child = Instantiate (Rhombus) as GameObject;
        Child.transform.SetParent (this.transform);
        hangY = Child.GetComponent<SpriteRenderer> ().sprite.bounds.size.y/10;
        textMesh = this.gameObject.GetComponent<TextMesh> ();
        temp = textMesh.text;
        textMesh.font = Resources.Load<Font> ("SuperMario256");
        textMesh.characterSize = 0.05f;
        textMesh.color = Color.red;
        MeshRenderer rend = gameObject.GetComponentInChildren<MeshRenderer> ();
        rend.material = textMesh.font.material;
        ThisPos = this.gameObject.GetComponent<Transform> ();
        PlayerPos = GameObject.FindWithTag ("Player").transform;
        this.gameObject.GetComponent<MeshRenderer> ().sortingOrder = 5;
        transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y + (float) hangY);
    }
    public int getDistance () {
        distance = (PlayerPos.position.x - ThisPos.position.x);
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

        if (show) textMesh.text = ("x" + temp + " = " + (getDistance ()).ToString ("0") + "\n" + "y" + temp + " = " + (getDistanceY ()).ToString ("0"));
        else textMesh.text = "";
        // show=false; 
        Child.SetActive (show);
    }
    void OnTriggerEnter2D (Collider2D other) {
        // Debug.Log("On trigger enter activated!"+other.gameObject.name);
        if (other.gameObject.name == "Redar")
            show = true;

    }
    void OnTriggerStay2D (Collider2D other) {
        // Debug.Log("On trigger stay activated!"+other.gameObject.name);
        if (other.gameObject.name == "Redar")
            show = true;

    }
    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.name == "Redar")
            show = false;

    }
}