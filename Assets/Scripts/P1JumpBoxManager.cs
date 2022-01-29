using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class P1JumpBoxManager : MonoBehaviour
{
	[HideInInspector] public bool CanJump { get { return hitCount > 0; } }
	public int hitCount = 0;

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("Yeah I do exist");
		if (collider.tag == "Ground")
			hitCount++;
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Ground") {
			hitCount--;
			if (hitCount < 0)
			{
				Debug.Log("Player 1 jump box collision count is " + hitCount + ".");
			}
		}
	}
}
