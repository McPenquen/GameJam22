using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraMovement : MonoBehaviour
{
	Transform p1Transform;
    Transform p2Transform;
    [Range(0.0f, 1.0f)]
    public float p2Strength;
	public float initialDelay = 5.0f;
	public float camSlideSpeed = 0.1f;
	
	
    void Awake()
    {

    }

    void Start()
    {
        // @TODO: Replace temp call names
        p1Transform = GameObject.Find("Player1").transform;
        p2Transform = GameObject.Find("Player2").transform;
    }

    void Update()
    {
		if (initialDelay > 0.0f) {
			initialDelay -= Time.deltaTime;
			return;
		}
		
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0.0f, Mathf.Lerp(p1Transform.position.y, p2Transform.position.y, p2Strength), Camera.main.transform.position.z), camSlideSpeed);
    }
}
