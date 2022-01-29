using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Player1 = null;
    [Header("Movement Variables")]
    [SerializeField] private float speed = 5;

    // Private Variables
    private bool isAlive = true;
    // Dying counter
    private float dyingCountdown = 3.0f;
    private SpriteRenderer sRenderer = null;
    private void Start()
    {
        // Setup the missile
        isAlive = true;
        sRenderer = GetComponent<SpriteRenderer>();
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
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
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
}
