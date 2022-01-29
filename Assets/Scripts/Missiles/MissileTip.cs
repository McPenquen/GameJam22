using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTip : MonoBehaviour
{
    [SerializeField] private MissileEnemy owner = null;
    private void OnCollisionEnter2D(Collision2D other)
    {
        owner.SetAlive(false);
		GameObject.Find("Player1").GetComponent<HealthSystem>().Damage();
    }
}
