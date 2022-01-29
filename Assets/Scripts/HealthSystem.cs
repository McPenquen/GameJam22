using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealthSystem : MonoBehaviour
{
	public int health = 3;
	public float maxIFrames = 1.0f;
	float iFrames;
	
	void Start() {
		
	}
	
	void Update() {
		iFrames -= Time.deltaTime;
	}
	
	// Returns true if the player has taken damage
	public bool Damage() {
		if (iFrames < 0.0f) {
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
	
	void PlayerDie() {
		//@TODO Add player death code
	}
}