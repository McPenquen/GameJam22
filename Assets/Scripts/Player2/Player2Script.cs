using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    [SerializeField] private List<MissileEnemy> missiles = new List<MissileEnemy>();
    // Radius of the attack zone
    [SerializeField] private float attackRadius = 4.0f;
    [SerializeField] private AttackRadius ar = null;
    private bool isMoving = true;

    // Global Variables
    public float movementSpeed = 10.0f; 
    public float movementScalarAdder = 0.2f;
    float movementScalar = 0.0f; 
    private Vector2 screenBounds = new Vector2();
    private SpriteRenderer playerSprite;

    [SerializeField] private GameObject cam = null;

    void Start()
    {
        //Gets boundaries of main camera
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));   

        //Cursor Stuffs
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        //Set playerSprite to be the sprite of the game object player. 
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Attack by press of P
        if (Input.GetKeyDown(KeyCode.P))
        {
            // player can attack only every 1s
            if (ar.CanAttack())
            {
                // Disable moving
                isMoving = false;
                // Attack
                Attack();
                ar.AttackVisualisation();
            }

        }

        // Allow moving again
        if (!ar.CanAttack())
        {
            isMoving = true;
        }

        if (isMoving)
        {
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

            viewPos.x = Mathf.Clamp(viewPos.x, cam.transform.position.x - screenBounds.x + playerSize.x /2.0f,
                 cam.transform.position.x + screenBounds.x - playerSize.x /2.0f );
            viewPos.y = Mathf.Clamp(viewPos.y, cam.transform.position.y - screenBounds.y,
                 cam.transform.position.y + screenBounds.y );

            transform.position = viewPos; 
        }
    }
    //Author Olav J. Digranes

    // Attack the enemies
    private void Attack()
    {
        foreach (MissileEnemy me in missiles)
        {
            if (me.gameObject.active)
            {
               me.GetKilled(); 
            }
        }
    }

    public float GetAttackRadius()
    {
        return attackRadius;
    }
}
