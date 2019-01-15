using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFloor1Script : MonoBehaviour {
    // Start is called before the first frame update\
    public Transform ThisPos, PlayerPos;
    double distance;
    public TextMesh textMesh;
    void Start () {

    }
    public double getDistance () {
        if(distance<=0)distance*=-1;
        return distance;

    }
    // Update is called once per frame
    void Update () {
        distance = PlayerPos.position.x + 0.878;
        textMesh.text = getDistance ().ToString ();
    }
}