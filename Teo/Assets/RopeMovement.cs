using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour


{
    // Start is called before the first frame update
     public GameObject RopeShooter;
    private SpringJoint2D Rope;
    public int maxRopeFrameCount;
    private int ropeFrameCount;
    public LineRenderer lineRenderer;   
    // Start is called before the first frame update
    // Update is called once per frame
    void Update() 
    {
        if(Input.GetMouseButtonDown(0)){
            Swing();
        }
    }
    void LateUpdate(){
        if(Rope!=null){
            lineRenderer.enabled = true;
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0,RopeShooter.transform.position);
            lineRenderer.SetPosition(1,Rope.connectedAnchor);
        }else{
            lineRenderer.enabled = false;
        }
    }
    void FixedUpdate() {
        if(Rope != null){
            ropeFrameCount++;
            if(ropeFrameCount > maxRopeFrameCount){
                GameObject.DestroyImmediate(Rope);
                ropeFrameCount = 0;
            }
        }
    }
     void Swing(){
        Vector3 mousePosition = Input.mousePosition;
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = RopeShooter.transform.position;
        Vector3 direction = mousePosition - position;
        RaycastHit2D hit = Physics2D.Raycast (position,direction, Mathf.Infinity);
        if(hit.collider != null){
            SpringJoint2D newRope = RopeShooter.AddComponent<SpringJoint2D>();
            newRope.enableCollision = false;
            newRope.frequency = .2f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;
               GameObject.DestroyImmediate(Rope);
               Rope = newRope;
               ropeFrameCount = 0;
        }
        }   
}

