using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Active Perspective")]
    [SerializeField] private bool is1stPP = true;
    [Header("Movement Variables")]
    [SerializeField] private int movementSpeed = 10;
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private int rotationSpeed = 5;
    [SerializeField] private float jumpForce = 10.0f;

    [Header("Object References")]
    [SerializeField] private GameObject cam = null; // camera
    [SerializeField] private GameObject body = null; // body    
    [SerializeField] private GameObject camAndBody = null; // body    
    private Rigidbody rb = null;
    private Animator animator = null;
    
    // The player is can jump - is touching the floor/and object with feet
    private bool canJump = false;
    // Activate controls detection
    private bool isDetectingInput = true;

     void Start()
    {
        // Save the perspective
        is1stPP = GameManager.GetIs1stPP();

        // Setup the camera
        if (is1stPP)
        {
            cam.transform.localPosition = new Vector3(0 , 1.9f,0);
        }
        else
        {
            cam.transform.localPosition = new Vector3(0 , 3.0f,-2.0f);
        }

        // Save rigid body reference
        rb = GetComponent<Rigidbody>();
        // Save animator reference
        animator = body.GetComponent<Animator>();

    }

    void Update()
    {
        // Detect movement
        if (isDetectingInput)
        {
          DetectInput();  
        }
    }

     // Detect Movement and move
    public void DetectInput()
    {
        // Detect input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseXInput = Input.GetAxis("Mouse X");
        float mouseYInput = Input.GetAxis("Mouse Y");
        float jumpInput = Input.GetAxis("Jump");

        // If movement is detected
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Adjust the forward and side vectors to 2D
            Vector3 twoDForward = cam.transform.forward;
            Vector3 twoDSide = Vector3.Cross(cam.transform.forward, transform.up);
            twoDForward.y = 0;
            twoDSide.y = 0;

            // Get the new position
            Vector3 newPosition = twoDForward.normalized * movementSpeed * Time.deltaTime * verticalInput
                + - twoDSide.normalized * movementSpeed * Time.deltaTime * horizontalInput;

            // Move the object to the new position
            rb.AddForce(newPosition, ForceMode.VelocityChange);

            // Walking animation isn't zero
            if (verticalInput != 0)
            {
                animator.SetBool("isVerticalZero", false);
            }
            else
            {
                animator.SetBool("isVerticalZero", true);
            }
            if (horizontalInput != 0)
            {
                animator.SetBool("isHorizontalZero", false);  
            }
            else
            {
                animator.SetBool("isHorizontalZero", true); 
            }          
        }
        else
        {
            // Walking animation is zero
            animator.SetBool("isVerticalZero", true);
            animator.SetBool("isHorizontalZero", true);  
        }

        // Set walking animation
        animator.SetFloat("horizontalMovement", horizontalInput);
        animator.SetFloat("verticalMovement", verticalInput);


        // Move the camera based on the view mode
        if (is1stPP)
        {
            // Rotate the camera
            cam.transform.Rotate(-mouseYInput * rotationSpeed, mouseXInput * rotationSpeed, 0);
            // Freeze the z-axis rotation
            Vector3 currentAngles = cam.transform.eulerAngles;
            cam.transform.eulerAngles = new Vector3(currentAngles.x, currentAngles.y, 0);

            // Rotate the body
            body.transform.Rotate(0, mouseXInput * rotationSpeed, 0);
            // Freeze the z-axis & x-axis rotation
            body.transform.eulerAngles = new Vector3(0, currentAngles.y, 0);
        }
        else
        {
            // Rotate the camera about the x axis
            cam.transform.Rotate(-mouseYInput * rotationSpeed, 0, 0);

            // Rotate the body and cam object about the y axis
            camAndBody.transform.Rotate(0, mouseXInput * rotationSpeed, 0);
            Vector3 currentAngles2 = camAndBody.transform.eulerAngles;
            camAndBody.transform.eulerAngles = new Vector3(0, currentAngles2.y, 0);
        }
    
        // Detect jumping
        if (jumpInput != 0 && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetBool("isJumping", true);
        }    
    }
    // Set the jumping to a bool
    public void SetCanJump(bool b)
    {
        canJump = b;
    }
    // Set detecting input bool
    public void SetInputDetection(bool b)
    {
        isDetectingInput = b;
    }

}