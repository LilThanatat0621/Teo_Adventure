using UnityEngine;
 using System.Collections;
 
 public class Position : MonoBehaviour {
 
     public Vector3 pos;

     // Use this for initialization
     void Start () {
        transform.position = new Vector3(0,0,0);
     }
     void Update() {
         pos=transform.position;
     }
     void OnGUI() {
         GUI.Label(new Rect(pos.x,pos.y,1000,1000),"Positon"+(pos.x.ToString()+(pos.y.ToString())));
        
     }
 }
 