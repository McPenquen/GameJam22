using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Movement : MonoBehaviour
{
    //This script is for the movement of the 2nd player. detached from cam. no collision. arrow keys from movement
    //Edit -> Project Settings -> Input Manager

    // Start is called before the first frame update

    public float movementSpeed = 5.0f; 
    public float halfScreenHeight = 4.5f;
    public float halfScreenWidth = 10.0f; 
    private Vector2 screenBounds = new Vector2();
    public GameObject player;
    private SpriteRenderer playerSprite;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Remember to change  the inputs in unity
        //float horizontalInput = Input.GetAxis("Horizontal2");
        //float verticalInput = Input.GetAxis("Vertical2");

        Vector2 inputVel = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")); 
        //Vector2 inputVel = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")); 
    
        Vector2 playerSize = new Vector2(playerSprite.size.x, playerSprite.size.y);
        //int playerSizeX = new Vector2(player.SpriteRenderer.size.x);
        //int playerSizeY = new Vector2(player.SpriteRenderer.size.y);

        inputVel = inputVel * movementSpeed * Time.deltaTime;

        /*
        Vector2 inputVelTemp = new Vector2(); 
         
        inputVelTemp = inputVel; 

        inputVel = inputVel * movementSpeed * Time.deltaTime;

        if(transform.position.x >= halfScreenWidth)
        {
            //transform.position.x -= 0.5f;
            inputVel.x = 0.0f; 
            inputVel.x -= 1.0f;            
        }

        if(transform.position.x <= -halfScreenWidth)
        {
            //transform.position.x += 0.5f;
            inputVel.x = 0.0f;
            inputVel.x += 1.0f;            
        }

        if(transform.position.y >= halfScreenHeight)
        {
            //transform.position.y -= 0.5f;
            inputVel.y = 0.0f;
            inputVel.y -= 1.0f;            
        }

        if(transform.position.y <= -halfScreenHeight)
        {
            //transform.position.y += 0.5f;
            inputVel.y = 0.0f;
            inputVel.y += 1.0f;            
        }

        transform.Translate(inputVel); 
        */
        
        transform.Translate(inputVel); 

        Vector3 viewPos = new Vector3();
        viewPos = transform.position; 
        //viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1), screenBounds.x);
        //viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1), screenBounds.y);
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + (playerSize.x/2), screenBounds.x - (playerSize.x/2));
        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1) + (playerSize.y/2), screenBounds.y - (playerSize.y/2));
        
        //Debug.Log(screenBounds.x);

        transform.position = viewPos; 
    
        
    }
}
