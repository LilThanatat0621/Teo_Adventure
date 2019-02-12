using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectStage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public string stage;
    public Text child;
    Color temp;
    void Start()
    {
        temp = child.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 54);
        // child.fontSize = 48;
        child.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // GetComponent<RectTransform>().sizeDelta = new Vector2(145f, 54);
        // child.fontSize = 36;
        child.color = temp;
    }


    public void Press()
    {
        SceneManager.LoadScene(stage);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
