using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DoorOpenerManager : MonoBehaviour
{
	public List<GameObject> doors;
	int hitCount = 0;
	
	void Start() {
		
	}
	
	void Update() {
		
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			hitCount++;
			if (hitCount == 1) {
				foreach (GameObject door in doors) {
					door.GetComponent<SpriteRenderer>().enabled = false;
					door.GetComponent<BoxCollider2D>().enabled = false;
				}
			}
		}
	}
	
	void OnCollisionExit(Collision other) {
		if (other.gameObject.tag == "Player") {
			hitCount--;
			if (hitCount == 0) {
				foreach (GameObject door in doors) {
					door.GetComponent<SpriteRenderer>().enabled = true;
					door.GetComponent<BoxCollider2D>().enabled = true;
				}
			}
		}
	}
}