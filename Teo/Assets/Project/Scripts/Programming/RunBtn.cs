using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RunBtn : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        this.GetComponent<Button> ().onClick.AddListener (Run);
    }

    // Update is called once per frame
    void Update () {

    }
    void Run () {
        // Block Code = GameObject.FindWithTag ("CodeContent").GetComponentInChildren<Block> ();
        Block[] allChildren = GameObject.FindWithTag("CodeContent").transform.GetComponentsInChildren<Block>();
        // Code.GetComponent<BeepBlock>().Run();
        // Debug.Log(Code);
        foreach (Block child in allChildren) {
            Debug.Log (child.gameObject);
        }
    }
}