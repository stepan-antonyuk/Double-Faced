using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCube : MonoBehaviour
{

    [SerializeField] private Animator my_animation_controller;
    
    string ChangePhase = "r";
    
    bool WTF = false;
    
        
    // Start is called before the first frame update
    void Start()
    {
        my_animation_controller.SetBool("FadeIn", false);
        my_animation_controller.SetBool("FadeOut", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(ChangePhase))
        {
            my_animation_controller.SetBool("FadeIn", !WTF);
            my_animation_controller.SetBool("FadeOut", WTF);
            WTF = !WTF;
        }
    }
}

