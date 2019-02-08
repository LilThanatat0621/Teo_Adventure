using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip DragSound,DropSound,Command;
    void Start()
    {
        Command=Resources.Load<AudioClip>("Sound/command");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
