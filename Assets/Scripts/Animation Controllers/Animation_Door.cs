using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Door : MonoBehaviour
{
    [SerializeField] private Animator my_animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {   
            //PlaySound("DoorOpen");
            my_animator.SetBool("Triggered", true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //PlaySound("DoorClose");
            my_animator.SetBool("Triggered", false);
        }
    }
    
    private void PlaySound(string clip)
    {
        //Debug.Log("PlayingSound   " + clip);
        SoundManager.PlaySound(clip);
    }
    
}

