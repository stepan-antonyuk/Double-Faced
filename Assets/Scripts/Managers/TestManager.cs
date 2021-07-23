using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

    GameObject[] objs;
    private Animator my_animation_controller;
    
    //public float Delay = 3f;
    
    public bool Fstate = false; // state of first cube on or off
    
    string SecondCube = "SecondCube";
    string FirstCube = "FirstCube";
    string ChangePhase = "r";
    string FadeIn = "FadeIn";
    string FadeOut = "FadeOut";
    
    bool WTF;

    // Start is called before the first frame update
    void Start()
    {
        StateTheState();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(ChangePhase))
        {
            PlaySound("ChangeColor");
            ChangeUpdate();
        }
        */
        
        ChangePhaseFunction();
    }
    
    
    private void changeStageFirstCube()
    {
         objs = GameObject.FindGameObjectsWithTag(FirstCube);
         foreach(GameObject lightuser in objs) 
         {
            SetAnimationController(lightuser);
         
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
            
            AnimationCgangeFirstCube();
         }

    }
    
    
    private void changeStageSecondCube()
    {
         objs = GameObject.FindGameObjectsWithTag(SecondCube);
         foreach(GameObject lightuser in objs) 
         {  
            SetAnimationController(lightuser);   
                   
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
            
            AnimationCgangeSecondCube();
         }

    }  
    
    
    private void AnimationCgangeFirstCube()
    {
        my_animation_controller.SetBool(FadeIn, WTF);
        my_animation_controller.SetBool(FadeOut, !WTF);
    }
    
    
    private void AnimationCgangeSecondCube()
    {
        my_animation_controller.SetBool(FadeIn, !WTF);
        my_animation_controller.SetBool(FadeOut, WTF);
    }
    
    
    private void RevWTF()
    {
        WTF = !WTF;
    }
    
    
    private void ChangeUpdate()
    {
       changeStageFirstCube();
       changeStageSecondCube();
       RevWTF();
    }
    
    
    private void StateTheState()
    {
        SetFirstCube();
        SetSecondCube();  
        SetWTF(); 
    }
    
    
    private void SetFirstCube()
    {
        objs = GameObject.FindGameObjectsWithTag(FirstCube);
        foreach(GameObject lightuser in objs) 
        {
            SetAnimationController(lightuser);
        
            lightuser.gameObject.GetComponent<Collider>().enabled = Fstate;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = Fstate;
            
            SetAnimationFirstCube();
        }
    }
    
    
    private void SetSecondCube()
    {
        objs = GameObject.FindGameObjectsWithTag(SecondCube);
        foreach(GameObject lightuser in objs) 
        {
            SetAnimationController(lightuser);
        
            lightuser.gameObject.GetComponent<Collider>().enabled = !Fstate;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = !Fstate;
            
            SetAnimationSecondCube(); 
        }
    }
    
    
    private void SetAnimationFirstCube()
    {
        if(Fstate)
        {
            my_animation_controller.SetBool(FadeIn, false);
            my_animation_controller.SetBool(FadeOut, false);
        }
        else
        {
            my_animation_controller.SetBool(FadeIn, true);
            my_animation_controller.SetBool(FadeOut, false);
        }
    }
    
    
    private void SetAnimationSecondCube()
    {
        if(Fstate)
        {
            my_animation_controller.SetBool(FadeIn, true);
            my_animation_controller.SetBool(FadeOut, false);
        }
        else
        {
            my_animation_controller.SetBool(FadeIn, false);
            my_animation_controller.SetBool(FadeOut, false);
        }
    }
    
    
    private void SetWTF()
    {
        WTF = Fstate;
    }
    
    
    private void SetAnimationController(GameObject lightuser)
    {
        my_animation_controller = lightuser.GetComponent<Animator> ();
    }
    
    
    private void PlayCubeSound(string clip)
    {
        //Debug.Log("PlayingSound   " + clip);
        SoundManager.PlayCubeSound(clip);
    }     
    
    
    private void ChangePhaseFunction()
    {
        if(Input.GetKeyDown(ChangePhase))
        {
            PlayCubeSound("ChangeColor");
            ChangeUpdate();
        }
    }
}

