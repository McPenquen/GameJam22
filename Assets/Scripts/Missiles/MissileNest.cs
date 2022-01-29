using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileNest : MonoBehaviour
{
    private bool releasedMissile = false;
    private bool detectedPlayer = false;
    [SerializeField] private GameObject player1 = null;
    private void Start()
    {
        // Deactivates the missile until the nest becomes visible
        transform.GetChild(0).gameObject.SetActive(false);
        releasedMissile = false;
        detectedPlayer = false;
    }
    private void OnBecameVisible()
    {   
        // When the nest is visible look for the player
        if (!releasedMissile)
        {
            detectedPlayer = true;
        }
    }

    private void OnBecameInvisible()
    {
        detectedPlayer = false;
    }

    private void FixedUpdate()
    {
        // If the player is detected start casting rays when the player becomes visible to the missile
        if (detectedPlayer)
        {
            // Check if the player is in sight and then launch a missile
            Vector3 dir = player1.transform.position - transform.position; 
            Vector2 dir2D = new Vector2(dir.x, dir.y);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir2D);

            if (hit.transform.position == player1.transform.position)
            {
                // Activate the missile when the nest appears on the screen
                transform.GetChild(0).gameObject.SetActive(true);
                releasedMissile = true;
            }
        }
    }

}
