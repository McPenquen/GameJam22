using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Movement : MonoBehaviour
{
    //This script is for the movement of the 2nd player. detached from cam. no collision. arrow keys from movement
    //Edit -> Project Settings -> Input Manager

    // Start is called before the first frame update
    // Global Variables
    public float movementSpeed = 10.0f; 
    public float movementScalarAdder = 0.2f;
    float movementScalar = 0.0f; 
    private Vector2 screenBounds = new Vector2();
    public GameObject player;
    private SpriteRenderer playerSprite;

    void Start()
    {
        //Gets boundaries of main camera
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 

        //Cursor Stuffs
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Set playerSprite to be the sprite of the game object player. 
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Remember to change  the inputs in unity
        //Player movement
        Vector2 inputVel = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")); 

        //Player sprite size
        Vector2 playerSize = new Vector2(playerSprite.size.x, playerSprite.size.y);

        if(movementScalar >= 1.0f){
            movementScalar += movementScalarAdder; 
            movementSpeed = movementSpeed * movementScalar;
        }

        //Calc input veocity
        inputVel = inputVel * movementSpeed * Time.deltaTime;
        
        //Transform the player object (Movement)
        transform.Translate(inputVel); 

        //Keep the player object in the bounds of the main camera. https://www.youtube.com/watch?v=ailbszpt_AI
        Vector3 viewPos = new Vector3();
        viewPos = transform.position; 
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + (playerSize.x/2), screenBounds.x - (playerSize.x/2));
        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1) + (playerSize.y/2), screenBounds.y - (playerSize.y/2));

        transform.position = viewPos; 
    
        
    }
}

//Author Olav J. Digranes