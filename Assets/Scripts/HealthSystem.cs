using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
	public int health = 3;
	public float maxIFrames = 1.0f;
	float iFrames;
	// Animation
	private Animator animator = null;
	private float cooldownAnim = 1.0f;
	private bool isDamaged = false;
	
	void Start() {
		animator = GetComponent<Animator>();
		isDamaged = false;
	}
	
	void Update() {
		iFrames -= Time.deltaTime;

		if (isDamaged)
		{
			cooldownAnim -= Time.deltaTime;
			if (cooldownAnim <= 0)
			{
				animator.SetBool("isDamaging", false);
				isDamaged = false;
				cooldownAnim = 1.0f;
			}
		}
	}
	
	// Returns true if the player has taken damage
	public bool Damage() {
		if (iFrames < 0.0f) {
			animator.SetBool("isDamaging", true);
			isDamaged = true;
			health--;
			iFrames = maxIFrames;
			if (health <= 0) {
				PlayerDie();
			}
			return true;
		} else {
			return false;
		}
	}
	
	public void PlayerDie() {
		SceneManager.LoadScene(1);
	}
}