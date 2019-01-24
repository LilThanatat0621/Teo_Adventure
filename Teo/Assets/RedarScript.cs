using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedarScript : MonoBehaviour
{
    public bool RedarOn=false;
    public Transform Redar;
    public float maxScale=150;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(RedarOn&&Redar.localScale.x<=maxScale){
            Redar.localScale=Redar.localScale+new Vector3(Mathf.Max(Redar.localScale.x/10,1),Mathf.Max(Redar.localScale.x/10,1));
        }
        else if(!RedarOn&&Redar.localScale.x>=0){
            Redar.localScale=Redar.localScale-new Vector3(Mathf.Max(Redar.localScale.x/5,1),Mathf.Max(Redar.localScale.x/5,1));
        }
        if(Redar.localScale.x<=0)
        {
            Redar.localScale=Vector3.zero;
        }
    }
    public void Toggle(){
        RedarOn=!RedarOn;
    }
}
