using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    bool ActivePanel=false;
    void Start()
    {
        // Panel=GameObject.FindWithTag ("Panel");
        Panel.SetActive(ActivePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick () {
        //Output this to console when Button1 or Button3 is clicked
        ActivePanel=!ActivePanel;
        Panel.SetActive(ActivePanel);
        // Debug.Log (GameObject.FindWithTag ("Canvas").GetComponent<CanvasScripts> ().ActivePanel);
    }
}
