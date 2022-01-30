using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	public int id;
	[HideInInspector] UiInGame uig;
	
    void Start()
    {
		uig = GameObject.FindObjectsOfType<UiInGame>()[0];
    }
	
	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Player") {
			//Debug.Log(id);
			Destroy(gameObject);
			uig.coinUI(id, true);
		}
	}
}
