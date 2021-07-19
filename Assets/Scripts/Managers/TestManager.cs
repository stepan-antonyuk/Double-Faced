using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

    GameObject[] objs;
    private Animator my_animation_controller;
    
    //public float Delay = 3f;
    
    public bool Fstate = false;
    
    string WhiteCube = "SecondCube";
    string RedCube = "FirstCube";
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
    
    
    private void changeStageR()
    {
         objs = GameObject.FindGameObjectsWithTag(RedCube);
         foreach(GameObject lightuser in objs) 
         {
            SetAnimationController(lightuser);
         
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
            
            AnimationCgangeRed();
         }

    }
    
    
    private void changeStageW()
    {
         objs = GameObject.FindGameObjectsWithTag(WhiteCube);
         foreach(GameObject lightuser in objs) 
         {  
            SetAnimationController(lightuser);   
                   
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
            
            AnimationCgangeWhite();
         }

    }  
    
    
    private void AnimationCgangeRed()
    {
        my_animation_controller.SetBool(FadeIn, WTF);
        my_animation_controller.SetBool(FadeOut, !WTF);
    }
    
    
    private void AnimationCgangeWhite()
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
       changeStageR();
       changeStageW();
       RevWTF();
    }
    
    
    private void StateTheState()
    {
        SetRedCube();
        SetWhiteCube();  
        SetWTF(); 
    }
    
    
    private void SetRedCube()
    {
        objs = GameObject.FindGameObjectsWithTag(RedCube);
        foreach(GameObject lightuser in objs) 
        {
            SetAnimationController(lightuser);
        
            lightuser.gameObject.GetComponent<Collider>().enabled = Fstate;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = Fstate;
            
            SetAnimationRed();
        }
    }
    
    
    private void SetWhiteCube()
    {
        objs = GameObject.FindGameObjectsWithTag(WhiteCube);
        foreach(GameObject lightuser in objs) 
        {
            SetAnimationController(lightuser);
        
            lightuser.gameObject.GetComponent<Collider>().enabled = !Fstate;
            //lightuser.gameObject.GetComponent<Renderer>().enabled = !Fstate;
            
            SetAnimationWhite(); 
        }
    }
    
    
    private void SetAnimationRed()
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
    
    
    private void SetAnimationWhite()
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
    
    
    private void PlaySound(string clip)
    {
        //Debug.Log("PlayingSound   " + clip);
        SoundManager.PlaySound(clip);
    }     
    
    
    private void ChangePhaseFunction()
    {
        if(Input.GetKeyDown(ChangePhase))
        {
            PlaySound("ChangeColor");
            ChangeUpdate();
        }
    }
}

