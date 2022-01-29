using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Movement : MonoBehaviour
{
    //This script is for the movement of the 2nd player. detached from cam. no collision. arrow keys from movement
    //Edit -> Project Settings -> Input Manager

    // Start is called before the first frame update

    public float movementSpeed = 5.0f; 
    float halfScreenHeight = 4.5f;
    float halfScreenWidth = 10.0f; 
    //private Vector2 screenBounds = new Vector2();

    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Remember to change  the inputs in unity
        //float horizontalInput = Input.GetAxis("Horizontal2");
        //float verticalInput = Input.GetAxis("Vertical2");

        Vector2 inputVel = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")); 
        //Vector2 inputVel = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")); 

        Vector2 inputVelTemp = new Vector2(); 
         
        inputVelTemp = inputVel; 

        inputVel = inputVel * movementSpeed * Time.deltaTime;

        if(transform.position.x >= halfScreenWidth)
        {
            //transform.position.x -= 0.5f;
            inputVel.x = 0.0f; 
            inputVel.x -= 0.5f;            
        }

        if(transform.position.x <= -halfScreenWidth)
        {
            //transform.position.x += 0.5f;
            inputVel.x = 0.0f;
            inputVel.x += 0.5f;            
        }

        if(transform.position.y >= halfScreenHeight)
        {
            //transform.position.y -= 0.5f;
            inputVel.y = 0.0f;
            inputVel.y -= 0.5f;            
        }

        if(transform.position.y <= -halfScreenHeight)
        {
            //transform.position.y += 0.5f;
            inputVel.y = 0.0f;
            inputVel.y += 0.5f;            
        }

        transform.Translate(inputVel); 
        
        /*
        Vector3 viewPos = new Vector3();
        viewPos = transform.position; 
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);

        transform.position = viewPos; 
        */
    }
}
