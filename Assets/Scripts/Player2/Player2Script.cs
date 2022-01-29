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
            else
            {
                isMoving = true;
            }

        }
    }
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
