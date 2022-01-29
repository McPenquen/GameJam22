using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer1OnContact : MonoBehaviour
{
	Transform player;
	
    void Start()
    {
		player = GameObject.Find("Player1").transform;
    }
	
	void OnTriggerEnter2D(Collider2D c) {
		if (c.transform == player) {
			player.gameObject.GetComponent<HealthSystem>().PlayerDie();
		}
	}
}
