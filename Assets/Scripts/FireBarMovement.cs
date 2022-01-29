using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FireBarMovement : MonoBehaviour
{
	public float speed;

	void Update()
	{
		transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
	}
}
