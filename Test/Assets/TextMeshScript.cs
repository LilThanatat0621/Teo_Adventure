using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshScript : MonoBehaviour
{
    public GameObject parent;
    public TextMesh texts;
    // Start is called before the first frame update
    void Start()
    {
        texts=this.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        texts.text=(parent.transform.position.x.ToString()+parent.transform.position.y.ToString());
    }
}
