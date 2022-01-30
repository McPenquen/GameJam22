using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    private bool isVisualisingAttack = false;
    [SerializeField] private float attackCooldown = 1.0f;
    private SpriteRenderer sRenderer = null;

    private void Start()
    {
        isVisualisingAttack = false;
        sRenderer = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (isVisualisingAttack)
        {
            attackCooldown -= Time.deltaTime;
            // When it reaches zero reset the attack
            if (attackCooldown <= 0)
            {
                isVisualisingAttack = false;
                attackCooldown = 1.0f;
            }

            // Fade away
            if (sRenderer.color.a > 0.0f)
            {
                Color newColor = sRenderer.color;
                newColor.a = newColor.a - Time.deltaTime;
                // Lowest val can be 0
                if (newColor.a < 0)
                {
                    newColor.a = 0;
                }
                sRenderer.color = newColor;
            }

        }
    }

    public void AttackVisualisation()
    {
        isVisualisingAttack = true;
        Color newColor = sRenderer.color;
        newColor.a = 1;
        sRenderer.color = newColor;
    }

    // Return if the player can attack
    public bool CanAttack()
    {
        return !isVisualisingAttack;
    }
}
