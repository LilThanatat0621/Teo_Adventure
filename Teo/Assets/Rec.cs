using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rec : MonoBehaviour {
    // Start is called before the first frame update
    // private coordinatesX,coordinatesY;
    void Start () {
        this.transform.localPosition = new Vector3 (0, 0, 0);
        // this.transform.localScale=new Vector3(this.transform.localScale.x*this.transform.parent.localScale.x,this.transform.localScale.y*this.transform.parent.localScale.y,this.transform.localScale.z*this.transform.parent.localScale.z);
    }

    // Update is called once per frame
    void Update () {
        this.transform.localPosition = new Vector3 (0, 0, 0);
        // Debug.Log(transform.position);
    }
}