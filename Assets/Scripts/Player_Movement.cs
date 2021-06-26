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
    public float crouch_speed = 6f;
    public float gravity = -9.81f;
    public float GDistance = 0.4f;
    public float WDistance = 2f;
    public float Jump_Height = 3f;
    public float noraml_State = -2f;
    public float slippery = 0f;
    //public float originalHeight = 3.8f;
    //public float originalHeight = controller.height;
    public float crouchingHeight = 1.9f;
    
    public int MouseHoldButton = 1; // can be 0,1,2
    
    public bool alwaysRun = true;
    public bool MouseCST = true;
    //private bool isCrouching = false;
    
    public string HoldButton = "left ctrl";
    public string PlayerTag = "Player";
    public string RunButton = "left shift";

    //public Vector3 originalCenter = new Vector3(0f, 0f, 0f);
    //public Vector3 originalCenter = controller.center;
    public Vector3 crouchingCenter = new Vector3(0f, -0.5f, 0f);
    
    public LayerMask groundMask;
    public LayerMask WallMask;
    
    float x;
    float z;
    float current_speed;
    float originalHeight;
    //float costumeMode = 0f;
    
    bool isGCfeelsGrounded;
    bool isGCfeelsWalled;
    bool isWCfeelsWalled;
    bool isHoldingWall;
    bool onTheGround;
    bool canIjump;
    bool isThereAnObjectnNear;
    bool isCrouching;
    
    Vector3 velocity;
    Vector3 originalCenter;
    


    

    // Start is called before the first frame update
    void Start()
    {
        SetPlayer();
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
        //isHoldTheWallButtonPressed();
        //isHoldTheWallMouseButtonPressed();
        HoldButtonPressed();
        
        
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
        if(Input.GetKey(RunButton))
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
        //Debug.Log("++++++++++++++++++++++++++++++");
    }
    
    
    private void isHoldTheWallMouseButtonPressed()
    {
        if((Input.GetMouseButton(MouseHoldButton) && isWCfeelsWalled ) && !onTheGround) // TODO change Input.GetKey("left ctrl") to Input.GetKeyDown("left ctrl")
        {
            HoldForWall();
        }
        else
        {
            LetTheWallGo();
        }
        
        isPlayerHoldingTheWall();
        //Debug.Log("||||||||||||||||||||||||||||||");
    }
    
    
    private void HoldButtonPressed()
    {
        if(MouseCST)
        {
            isHoldTheWallMouseButtonPressed();
        }
        else
        {
            isHoldTheWallButtonPressed();
        }
    }
    
    
    private void isOnTheGround()
    {
        onTheGround = isGCfeelsGrounded || isGCfeelsWalled;
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
        
        canIjump = isThereAnyObjectnNear();
    }
    
    
    public bool isThereAnyObjectnNear()
    {
        return onTheGround || isWCfeelsWalled;
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
    
    
    private void SetPlayer()
    {
        transform.tag = PlayerTag;
        controller = GetComponent<CharacterController>();   
        originalCenter = controller.center;
        originalHeight = controller.height;
        current_speed = walk_speed;  
    }
    
    
    private void CheckCrouchingButton()
    {
        if(Input.GetButtonDown("Crouch")) {
            Crouching();
        }
        else if(!Input.GetButton("Crouch") && isCrouching)
        {
            StopCrouching();
        }
    }
    
    
    private void Crouching()
    {
        controller.height = crouchingHeight;
        controller.center = crouchingCenter;
        current_speed = crouch_speed;
        isCrouching = true;
    }
    
    
    private void StopCrouching()
    {
        Vector3 point0 = transform.position + originalCenter - new Vector3(0.0f, originalHeight, 0.0f);           
        Vector3 point1 = transform.position + originalCenter + new Vector3(0.0f, originalHeight, 0.0f);
        
        if (Physics.OverlapCapsule(point0, point1, controller.radius).Length == 0) 
        {
           controller.height = originalHeight;
           controller.center = originalCenter;
           current_speed = walk_speed;
           isCrouching = false;
        }
    }
    
    
    private void DebugBug()
    {
        Debug.Log("-----------------------------------");
        //Debug.Log(Input.GetKey("left ctrl"));
        //Debug.Log(isGCfeelsGrounded);
        //Debug.Log(isGCfeelsWalled);
        //Debug.Log(isWCfeelsWalled);
        //Debug.Log(current_speed);
        //Debug.Log(velocity.y); 
        Debug.Log(isCrouching);        
    }
    
    
}

