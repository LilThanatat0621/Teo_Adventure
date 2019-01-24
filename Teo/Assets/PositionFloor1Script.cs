using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFloor1Script : MonoBehaviour {
    // Start is called before the first frame update\
    public Transform ThisPos, PlayerPos;
    double distance;
    public double posBlock;
    string temp;
    public TextMesh textMesh;
    void Start () {
        temp = textMesh.text;
         this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 5; 
    }
    public double getDistance () {
        if (distance <= 0) distance *= -1;
        return distance * 10;

    }
    // Update is called once per frame
    void Update () {
        distance = PlayerPos.position.x - posBlock;
        textMesh.text = (temp + " = " + (getDistance ()).ToString ("0.00"));
    }
}