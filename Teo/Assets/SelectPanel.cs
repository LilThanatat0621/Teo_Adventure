using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOn = false;

    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn && rect.sizeDelta.x<460)rect.sizeDelta=new Vector2(rect.sizeDelta.x+20,rect.sizeDelta.y);
        if (!isOn && rect.sizeDelta.x>0)rect.sizeDelta=new Vector2(rect.sizeDelta.x-20,rect.sizeDelta.y);
    }
}
