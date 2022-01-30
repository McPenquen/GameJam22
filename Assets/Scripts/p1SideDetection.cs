using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1SideDetection : MonoBehaviour
{
	public int hitCount = 0;

	private Animator animator = null;

	private void Start()
	{
		animator = GetComponentInParent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Ground")
		{
			hitCount++;
			animator.SetBool("isGrabbing", true);
		}
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Ground") {
			hitCount--;
			if (hitCount < 0)
			{
				Debug.Log("Player 1 side collision count is " + hitCount + ".");
			}
            animator.SetBool("isGrabbing", false);
		}
	}
}
