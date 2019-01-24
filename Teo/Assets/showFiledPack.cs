using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showFiledPack : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup canvasGroup;
    public bool ActivePanel=false;
    void Start()
    {
        // Panel=GameObject.FindWithTag ("Panel");

    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.blocksRaycasts=ActivePanel;
        if(ActivePanel&&canvasGroup.alpha<=1f){
            canvasGroup.alpha+=0.1f;
        }
        if(!ActivePanel&&canvasGroup.alpha>=0){
            canvasGroup.alpha-=0.1f;
        }
        
    }

    public void TaskOnClick () {
        //Output this to console when Button1 or Button3 is clicked
        ActivePanel=!ActivePanel;
        
        // Debug.Log (GameObject.FindWithTag ("Canvas").GetComponent<CanvasScripts> ().ActivePanel);
    }
}
