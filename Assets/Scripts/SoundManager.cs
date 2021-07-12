using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip DoorOpen, ChangeColor, StairOpen;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = Resources.Load<AudioClip> ("DoorOpen");
        StairOpen = Resources.Load<AudioClip> ("StairOpen");
        ChangeColor = Resources.Load<AudioClip> ("ChangeColor");        
        
        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "DoorOpen":
                audioSrc.PlayOneShot(DoorOpen);
                break;
            case "DoorClose":
                audioSrc.PlayOneShot(DoorOpen);
                break;
            case "StairOpen":
                audioSrc.PlayOneShot(StairOpen);
                break;
            case "StairClose":
                audioSrc.PlayOneShot(StairOpen);
                break;
            case "ChangeColor":
                audioSrc.PlayOneShot(ChangeColor);
                break;
        }
    }
}
