using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip DoorOpen, ChangeColor, StairOpen, Dirt_Jogging, Dirt_Running, Dirt_Walking;
    static AudioSource audioSrc;
    static AudioSource playerSrc;
    static AudioSource cubeSrc;

    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = Resources.Load<AudioClip> ("DoorOpen");
        StairOpen = Resources.Load<AudioClip> ("StairOpen");
        ChangeColor = Resources.Load<AudioClip> ("ChangeColor");
        Dirt_Jogging = Resources.Load<AudioClip> ("Dirt_Jogging");
        Dirt_Running = Resources.Load<AudioClip> ("Dirt_Running");
        Dirt_Walking = Resources.Load<AudioClip> ("Dirt_Walking");        
        
        audioSrc = GetComponent<AudioSource> ();
        playerSrc = GetComponent<AudioSource> ();
        cubeSrc = GetComponent<AudioSource> ();
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
            case "Jogging":
                audioSrc.PlayOneShot(Dirt_Jogging);
                break;
            case "Running":
                audioSrc.PlayOneShot(Dirt_Running);
                break;
            case "Walking":
                audioSrc.PlayOneShot(Dirt_Walking);
                break;
        }
    }
    
    
    public static void PlayPlayerSound (string clip)
    {
        switch (clip)
        {
            case "Jogging":
                playerSrc.PlayOneShot(Dirt_Jogging);
                break;
            case "Running":
                playerSrc.PlayOneShot(Dirt_Running);
                break;
            case "Walking":
                playerSrc.PlayOneShot(Dirt_Walking);
                break;
        }
    }
    
    
    public static void PlayCubeSound (string clip)
    {
        switch (clip)
        {
            case "ChangeColor":
                cubeSrc.PlayOneShot(ChangeColor);
                break;
        }
    }
    
    
    // TODO fix all below
    public static bool AlreadyPlayingX(AudioSource x)
    {
        if (x.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    public static bool AlreadyPlaying()
    {
        if (audioSrc.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    public static bool PlayerSrcAlreadyPlaying()
    {
        if (playerSrc.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    public static void StopPlaying()
    {
        audioSrc.Stop();
    }
    
    
    public static void StopPlayingPlayerSrc()
    {
        playerSrc.Stop();
    }
}
