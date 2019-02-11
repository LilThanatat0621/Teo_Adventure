using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rec : MonoBehaviour {
    // Start is called before the first frame update
    // private coordinatesX,coordinatesY;
    RectTransform rect;
    void Start () {
        this.transform.localPosition = new Vector3 (0, 0, 0);
        rect=this.gameObject.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update () {
        this.transform.localPosition = new Vector3 (0, 0, 0);
        rect.sizeDelta=new Vector2(GetWidht(this.transform.parent.gameObject.GetComponent<TextMesh>())+2.5f,rect.sizeDelta.y);
        this.gameObject.GetComponent<SpriteRenderer>().size=rect.sizeDelta;
    }

     public static float GetWidht(TextMesh mesh)
 {
     float width = 0;
     foreach( char symbol in mesh.text)
     {
         CharacterInfo info;
         if (mesh.font.GetCharacterInfo(symbol, out info))
         {
             width += info.width;
         }
     }
     return width * mesh.characterSize * 0.1f   ;
 }
}