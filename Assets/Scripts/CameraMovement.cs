using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraMovement : MonoBehaviour
{
	Transform p1Transform;
    Transform p2Transform;
    [Range(0.0f, 1.0f)]
    public float p2Strength;

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
        Camera.main.transform.position = new Vector3(0.0f, Mathf.Lerp(p1Transform.position.y, p2Transform.position.y, p2Strength), Camera.main.transform.position.z);
    }
}
