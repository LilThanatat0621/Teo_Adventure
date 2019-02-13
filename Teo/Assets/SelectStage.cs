using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectStage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    // Start is called before the first frame update
    public string stage;
    public Text child;
    Color temp;

    private AudioSource aSource;
    void Start () {
        DestroyAllDontDestroyOnLoadObjects ();
        temp = child.color;
        aSource = gameObject.AddComponent<AudioSource> ();
        aSource.clip = Resources.Load<AudioClip> ("Sound/command");
    }
    public void DestroyAllDontDestroyOnLoadObjects () {

        var go = new GameObject ("Sacrificial Lamb");
        DontDestroyOnLoad (go);

        foreach (var root in go.scene.GetRootGameObjects ())
            Destroy (root);

    }
    public void OnPointerEnter (PointerEventData eventData) {
        // GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 54);
        // child.fontSize = 48;
        if (!aSource.isPlaying) {
            aSource.Play ();
        }
        child.color = Color.white;
    }

    public void OnPointerExit (PointerEventData eventData) {
        // GetComponent<RectTransform>().sizeDelta = new Vector2(145f, 54);
        // child.fontSize = 36;
        child.color = temp;
    }

    public void Press () {
        SceneManager.LoadScene (stage);
    }
    // Update is called once per frame
    void Update () {

    }
}