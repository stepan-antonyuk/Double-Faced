using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public CharacterController controller;
    
    public Transform GC;
    public Transform WC;
    
    public float walk_speed = 12f;
    public float run_speed = 24f;
    public float gravity = -9.81f;
    public float GDistance = 0.4f;
    public float WDistance = 2f;
    public float Jump_Height = 3f;
    public float noraml_State = -2f;
    public float slippery = 0f;
    
    public bool alwaysRun = true;
    
    public string HoldButton = "left ctrl";
    
    public LayerMask groundMask;
    public LayerMask WallMask;
    
    float x;
    float z;
    float current_speed;
    //float costumeMode = 0f;
    
    bool isGCfeelsGrounded;
    bool isGCfeelsWalled;
    bool isWCfeelsWalled;
    bool isHoldingWall;
    bool onTheGround;
    bool canIjump;
    bool isThereAnObjectnNear;
    
    Vector3 velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check section
        
        CheckHitBoxes();
        MoveUpdate();
        
        
        isPlayerJustHitTheGround();
        
        
        //check for left shift pressed. Players runs or not. Just currects player's speed.
        Move();
        
        
        // modificated added "&& onTheGround" make player unable to hold to the wall while standing on it or on the ground.
        // if holding wall STOP MOVING and slip or else just fall
        isHoldTheWallButtonPressed();
        
        
        //if on the ground and pressing space to jump
        isJumping();
        
        
        // Move character 
        MoveCharacter();
        
        
        //Debug section
        DebugBug();
               
    }
    
    
    private void Jump()
    {
        //Debug.Log("Check_Jump");
        velocity.y = Mathf.Sqrt(Jump_Height * -2f * gravity);
    }
    
    
    private void isJumping()
    {
        if(Input.GetButtonDown("Jump")) // TODO I need to fix jump so that ctrl will not effect unitl it pressed again.
        {
            PremissionToJump();
            
            if(canIjump)
            {
                Jump();
                LetTheWallGo();
            }
        }
    }
    
    
    private void CheckHitBoxes()
    {
        isGCfeelsGrounded = Physics.CheckSphere(GC.position, GDistance, groundMask);
        isGCfeelsWalled = Physics.CheckSphere(GC.position, GDistance, WallMask);
        isWCfeelsWalled = Physics.CheckSphere(WC.position, WDistance, WallMask);
    }
    
    
    private void MoveUpdate()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }
    
    
    private void Run()
    {
        current_speed = run_speed;
    }
    
    
    private void Walk()
    {
        current_speed = walk_speed;
    }
    
    
    private void isRunning()
    {
        if(Input.GetKey("left shift"))
        {
            Run();
        }
        else
        {
            Walk();
        }
    }
    
    
    private void isWalking()
    {
        if(Input.GetKey("left shift"))
        {
            Walk();
        }
        else
        {
            Run();
        }
    }
    
    
    private void Move()
    {
        if(alwaysRun)
        {
            isWalking();
        }
        else
        {
            isRunning();
        }
    }
    
    
    private void MoveCharacter()
    {  
        //Move player by x and z
        Vector3 move = transform.right * x + transform.forward * z;        
        controller.Move(move * current_speed * Time.deltaTime);
        //fall, move player by z
        controller.Move(velocity * Time.deltaTime);
    }
    
    
    private void HoldForWall()
    {  
        isHoldingWall = true;
    }
    
    
    private void LetTheWallGo()
    {
        isHoldingWall = false;
    }
    
    
    private void isPlayerHoldingTheWall()
    {
        if(isHoldingWall)
        {
            velocity.y = 0f;
            x = 0f;
            z = 0f;
            Slip();
        }
        else
        {
            Gravity();
        }
    }
    
    
    private void isHoldTheWallButtonPressed()
    {
        if((Input.GetKey(HoldButton) && isWCfeelsWalled ) && !onTheGround) // TODO change Input.GetKey("left ctrl") to Input.GetKeyDown("left ctrl")
        {
            HoldForWall();
        }
        else
        {
            LetTheWallGo();
        }
        
        isPlayerHoldingTheWall();
    }
    
    
    private void isOnTheGround()
    {
        if(isGCfeelsGrounded || isGCfeelsWalled)
        {
            onTheGround = true;
        }
        else
        {
            onTheGround = false;
        }
    }
    
    
    private void isPlayerJustHitTheGround()
    { 
        isOnTheGround();
        
        if(onTheGround && velocity.y < 0) // modificated added "onTheGround &&"
        {
            Stand();
        }
    }
    
    
    public void PremissionToJump()
    {
        // if player fells the wall with his wall chacker or on the ground. It make player able to jump from the wall without need of holding it
        
        isThereAnyObjectnNear();
        
        if(isThereAnObjectnNear)
        {
            canIjump = true;
        }
        else
        {
            canIjump = false;
        }
    }
    
    
    public void isThereAnyObjectnNear()
    {
        if(onTheGround || isWCfeelsWalled)
        {
            isThereAnObjectnNear = true;
        }
        else
        {
            isThereAnObjectnNear = false;
        }
    }
    
    
    private void Stand()
    {
        //Debug.Log("Check_fall");
        velocity.y = noraml_State;
    }
    
    
    private void Slip()
    {
        velocity.y += slippery * Time.deltaTime;
    }
    
    
    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }
    
    
    private void DebugBug()
    {
        Debug.Log("-----------------------------------");
        //Debug.Log(Input.GetKey("left ctrl"));
        Debug.Log(isGCfeelsGrounded);
        Debug.Log(isGCfeelsWalled);
        Debug.Log(isWCfeelsWalled);
        //Debug.Log(current_speed);
        Debug.Log(velocity.y);
    }
    
    
}

