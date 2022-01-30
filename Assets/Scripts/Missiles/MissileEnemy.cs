using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Player1 = null;
    [SerializeField] private Player2Script Player2 = null;

    [Header("Movement Variables")]
    [SerializeField] private float speed = 1;

    // Private Variables
    public bool isAlive = true;
    // Dying counter
    private float dyingCountdown = 3.0f; // countdown for the missile to die
    private SpriteRenderer sRenderer = null;
    private bool isKillable = false; // can be killed by player 2
    private void Start()
    {
        // Setup the missile
        isAlive = true;
        sRenderer = GetComponent<SpriteRenderer>();
        isKillable = false;
    }

    private void Update()
    {
        if (isAlive)
        {
            // Chase the player
            Vector3 dir = (Player1.transform.position - transform.position).normalized;
            // Move the missile
            transform.position += dir * Time.deltaTime * speed;

            // Rotate the missile
            float newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(newAngle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            // inspired from: https://answers.unity.com/questions/650460/rotating-a-2d-sprite-to-face-a-target-on-a-single.html

            // Check the distance to the player 2 - it is killable if the distance is smaller than the attack
            float dist = (Player2.transform.position - transform.position).magnitude;
            if (dist <= Player2.GetAttackRadius())
            {
                isKillable = true;
            }
            else
            {
                isKillable = false;
            }
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponentInChildren<BoxCollider2D>().enabled = false;
        dyingCountdown -= Time.deltaTime;
        // Fade away 
        if (sRenderer.color.a > 0.0f)
        {
            // TODO add dying animation
            Color newColor = sRenderer.color;
            newColor.a = newColor.a - 0.01f;
            // Lowest val can be 0
            if (newColor.a < 0)
            {
                newColor.a = 0;
            }
            sRenderer.color = newColor;
        }

        // Die after the countdown
        if (dyingCountdown <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    // Setter for the alive bool
    public void SetAlive(bool b )
    {
        isAlive = b;
    }
    // Set if it it killable by player 2
    public void SetKillable(bool b)
    {
        isKillable = b;
    }
    // Die by player 2 if it is killable now
    public void GetKilled()
    {
        if (isKillable)
        {
            isAlive = false;
        }
    }
}
