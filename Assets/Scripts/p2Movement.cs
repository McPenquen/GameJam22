using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Movement : MonoBehaviour
{
    //This script is for the movement of the 2nd player. detached from cam. no collision. arrow keys from movement
    //Edit -> Project Settings -> Input Manager

    // Start is called before the first frame update

    public float movementSpeed = 5.0f; 
    void Start()
    {
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

        inputVel = inputVel * movementSpeed * Time.deltaTime;

        transform.Translate(inputVel); 
    }
}
