using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    GameObject[] objs;
    //public float Delay = 3f;
    public bool Rstate = false;
    string WhiteCube = "WhiteCube";
    string RedCube = "RedCube";
    string ChangePhase = "r";

    // Start is called before the first frame update
    void Start()
    {
        StateTheState();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(ChangePhase))
        {
            ChangeUpdate();
        }
    }
    
    
    private void changeStageR()
    {
         objs = GameObject.FindGameObjectsWithTag(RedCube);
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
         }

    }
    
    
    private void changeStageW()
    {
         objs = GameObject.FindGameObjectsWithTag(WhiteCube);
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
         }

    }
    
    
    private void StateTheState()
    {
        objs = GameObject.FindGameObjectsWithTag(RedCube);
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = Rstate;
            lightuser.gameObject.GetComponent<Renderer>().enabled = Rstate;
         }
         objs = GameObject.FindGameObjectsWithTag(WhiteCube);
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = !Rstate;
            lightuser.gameObject.GetComponent<Renderer>().enabled = !Rstate;
         }
    }
    
    
    private void ChangeUpdate()
    {
       changeStageR();
       changeStageW();;
    }
}

