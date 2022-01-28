using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Movement : MonoBehaviour
{
    //This script is for the movement of the 2nd player. detached from cam. no collision. arrow keys from movement
    //Edit -> Project Settings -> Input Manager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Remember to change  the inputs in unity
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
    }
}
