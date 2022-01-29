using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class P1JumpBoxManager : MonoBehaviour
{
	[HideInInspector] public bool CanJump { get { return true /*hitCount > 0*/; } }
	public int hitCount = 0;

	void OnCollisionEnter2D(Collision2D collider)
	{
		Debug.Log("Yeah I do exist");
		if (collider.otherCollider.gameObject.tag == "Ground")
			hitCount++;
	}
	
	void OnCollisionLeave2D(Collision2D collider)
	{
		if (collider.otherCollider.gameObject.tag == "Ground") {
			hitCount--;
			if (hitCount < 0)
			{
				Debug.Log("Player 1 jump box collision count is " + hitCount + ".");
			}
		}
	}
}
