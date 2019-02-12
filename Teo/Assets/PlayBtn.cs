using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Text child;
    public SelectPanel toggle;
    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 54);
        // child.fontSize = 48;
        child.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // GetComponent<RectTransform>().sizeDelta = new Vector2(145f, 54);
        // child.fontSize = 36;
        child.color = Color.white;
    }


    public void Press()
    {
        toggle.isOn = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
