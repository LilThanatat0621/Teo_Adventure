using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenColor : MonoBehaviour
{
    SpriteRenderer _this;
    bool increase = true;
    // Start is called before the first frame update
    void Start()
    {
        _this = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_this.color.r >= 1f) increase = false;
        if (_this.color.r <= 0) increase = true;
        if (increase) _this.color = new Vector4(_this.color.r + 0.05f, 1, 1, 1);
        else _this.color = new Vector4(_this.color.r - 0.05f, 1, 1, 1);
    }
}
