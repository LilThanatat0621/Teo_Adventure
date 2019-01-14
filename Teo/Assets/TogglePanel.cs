using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TogglePannel : MonoBehaviour {
    // Start is called before the first frame update
    GameObject Panel;
    bool ActivePanel=false;
    void Start () {
        // this.GetComponent<Button> ().onClick.AddListener (TaskOnClick);
        Panel=GameObject.FindWithTag ("Panel");
    }

    // Update is called once per frame
    void Update () {

    }

    public void TaskOnClick () {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("Toggle");
        Panel.SetActive(ActivePanel);
        // Debug.Log (GameObject.FindWithTag ("Canvas").GetComponent<CanvasScripts> ().ActivePanel);
    }
}