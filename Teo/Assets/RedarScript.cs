using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedarScript : MonoBehaviour {
    public bool RedarOn = false;
    Transform Player;
    Transform Redar;
    public float maxScale = 150;
    // Start is called before the first frame update
    void Start () {
        Player = GameObject.FindWithTag ("Player").transform;
        Redar = transform;
    }

    // Update is called once per frame
    void Update () {
        Redar.localPosition = Player.localPosition;
        if (RedarOn && Redar.localScale.x <= maxScale) {
            Redar.localScale = Redar.localScale + new Vector3 (Mathf.Max (Redar.localScale.x / 10, 1), Mathf.Max (Redar.localScale.x / 10, 1));
            // this.GetComponent<CircleCollider2D> ().radius=Redar.localScale.x/1600;
        } else if (!RedarOn && Redar.localScale.x >= 0) {
            Redar.localScale = Redar.localScale - new Vector3 (Mathf.Max (Redar.localScale.x / 5, 1), Mathf.Max (Redar.localScale.x / 5, 1));
            // this.GetComponent<CircleCollider2D> ().radius=Redar.localScale.x/1600;
        }
        if (Redar.localScale.x <= 0) {
            Redar.localScale = Vector3.zero;
            // this.GetComponent<CircleCollider2D> ().radius=Redar.localScale.x/1600;
        }
        this.GetComponent<CircleCollider2D> ().radius = this.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x;

    }
    public void Toggle () {
        RedarOn = !RedarOn;
    }
    public void Restart () {
        Application.LoadLevel (Application.loadedLevel);
    }
}