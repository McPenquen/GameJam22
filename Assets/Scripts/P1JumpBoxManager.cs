using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class P1JumpBoxManager : MonoBehaviour
{
	[HideInInspector] public bool CanJump { get { return hitCount == 0; } };
	int hitCount = 0;

	void OnCollisionEnter()
	{
		hitCount++;
	}

	void OnCollisionLeave()
	{
		hitCount--;
		if (hitCount < 0)
		{
			Debug.Log("Player 1 jump box collision count is " + hitCount + ".");
		}
	}
}
