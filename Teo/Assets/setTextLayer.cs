using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTextLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer> ().sortingOrder = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
