using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Stairs : MonoBehaviour
{
    [SerializeField] private Animator my_animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            my_animator.SetBool("Triggered", true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            my_animator.SetBool("Triggered", false);
        }
    }
}

