using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFloor1Script : MonoBehaviour {
    // Start is called before the first frame update\
    bool show = false;
    Transform ThisPos, PlayerPos;
    int distance;
    string temp;
    TextMesh textMesh;
    void Start () {
        textMesh = this.gameObject.GetComponent<TextMesh> ();
        temp = textMesh.text;
        ThisPos = this.gameObject.GetComponent<Transform> ();
        PlayerPos = GameObject.FindWithTag ("Player").transform;
        this.gameObject.GetComponent<MeshRenderer> ().sortingOrder = 5;
    }
    public int getDistance () {
        distance = (int) (PlayerPos.position.x - ThisPos.position.x);
        if (distance <= 0) distance *= -1;
        return distance ;

    }
    public int getDistanceY () {
        int dis = (int) (PlayerPos.position.y - ThisPos.position.y);
        if (dis <= 0) dis *= -1;
        return dis ;

    }
    // Update is called once per frame
    void Update () {

        if (show) textMesh.text = ("x" + temp + " = " + (getDistance ()).ToString ("0") + "\n" + "y" + temp + " = " + (getDistanceY ()).ToString ("0"));
        else textMesh.text = "";
        // show=false; 
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