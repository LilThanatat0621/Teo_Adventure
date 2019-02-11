using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class GameCamera : MonoBehaviour {
    public float dampTime = 0.15f;
    public newToggle panelBtn;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public bool pressed = true;
    Vector3 lastMousePos = Vector3.zero;
    void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag (this.gameObject.tag);

        if (objs.Length > 1) {
            Destroy (this.gameObject);
        }

        DontDestroyOnLoad (this.gameObject);
    }
    void Update () {
        if(target==null)target = GameObject.FindWithTag ("Player").transform;
        Vector3 point = GetComponent<Camera> ().WorldToViewportPoint (target.position);
        Vector3 delta = target.position - GetComponent<Camera> ().ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        pressed = Input.GetMouseButton (0);
        if (Input.GetMouseButtonDown (0)) {
            lastMousePos = Input.mousePosition;
        }
        if (pressed && !panelBtn.ActivePanel) {
            transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (-(Input.mousePosition.x - lastMousePos.x) / 100 + destination.x, -(Input.mousePosition.y - lastMousePos.y) / 100 + destination.y, -10), ref velocity, dampTime);
        } else if (target) {

            transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
        }

    }
}