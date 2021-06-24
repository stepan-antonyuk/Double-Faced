using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    GameObject[] objs;
    public float Delay = 3000f;
    public bool Rstate = false;

    // Start is called before the first frame update
    void Start()
    {
        StateTheState();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("r"))
        {
            StartCoroutine(waiter());
        }
    }
    
    
    private void changeStageR()
    {
         objs = GameObject.FindGameObjectsWithTag("RCube");
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
         }

    }
    
    
    private void changeStageW()
    {
         objs = GameObject.FindGameObjectsWithTag("WCube");
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = !lightuser.gameObject.GetComponent<Collider>().enabled;
            lightuser.gameObject.GetComponent<Renderer>().enabled = !lightuser.gameObject.GetComponent<Renderer>().enabled;
         }

    }
    
    
    private void StateTheState()
    {
        objs = GameObject.FindGameObjectsWithTag("RCube");
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = Rstate;
            lightuser.gameObject.GetComponent<Renderer>().enabled = Rstate;
         }
         objs = GameObject.FindGameObjectsWithTag("WCube");
         foreach(GameObject lightuser in objs) 
         {
            lightuser.gameObject.GetComponent<Collider>().enabled = !Rstate;
            lightuser.gameObject.GetComponent<Renderer>().enabled = !Rstate;
         }
    }
    
    
    IEnumerator waiter() // TODO
    {
        yield return new WaitForSeconds(Delay);
        changeStageR();
        changeStageW();
    }
}

