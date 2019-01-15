using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashspeed;
    private float dashtime;
    public float startDashtime;
    private int direction;
    // public GameObject dasheffect;
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     dashtime = startDashtime;   
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                // Instantiate(dasheffect, transform.position, Quaternion.identity);
                direction = 1;
            }else if(Input.GetKeyDown(KeyCode.RightArrow)){
                // Instantiate(dasheffect, transform.position, Quaternion.identity);
                direction = 2;
            }else if(Input.GetKeyDown(KeyCode.UpArrow)){
                // Instantiate(dasheffect, transform.position, Quaternion.identity);
                direction = 3;
            }else if(Input.GetKeyDown(KeyCode.DownArrow)){
                // Instantiate(dasheffect, transform.position, Quaternion.identity);
                direction = 4;
            } 
            
        }else {
            if(dashtime <= 0){
                direction = 0;
                dashtime = startDashtime;
                rb.velocity = Vector2.zero;
            }else {
                dashtime -= Time.deltaTime;
               
                if(direction == 1){
                    rb.velocity = Vector2.left * dashspeed;
                } else if(direction == 2){
                    rb.velocity = Vector2.right * dashspeed;
                } else if(direction == 3){
                    rb.velocity = Vector2.up * dashspeed;
                } else if(direction == 4){
                    rb.velocity = Vector2.down * dashspeed;
                } 
            }
        }
    }
}
