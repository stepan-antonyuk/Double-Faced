using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{

    public float Mouse_Sensitivity = 100f;
    public float x_Rotation = 0f;
    public Transform Player_Body;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Mouse_Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Mouse_Sensitivity * Time.deltaTime;
        
        x_Rotation -= mouseY;
        x_Rotation = Mathf.Clamp(x_Rotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(x_Rotation, 0f, 0f);
        Player_Body.Rotate(Vector3.up * mouseX);
        
        //Debug.Log("mouse X:  " + mouseX);
        //Debug.Log("mouse Y:  " + mouseY);
        //Debug.Log("x_Rotation:   " + x_Rotation); // TODO mouse sensetivity is effected by amount of object in the crean or FPS
    }
}

