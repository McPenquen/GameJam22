using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamesAnimation : MonoBehaviour
{
    public float frequency;
    public float range;
    Vector3 initialPosition;
    public float maxDelay;
    float delay;
    [Range(0.0f, 3.14159f)]
    public float initial;
    public bool startRight;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (delay < 0.0f)
        {
            transform.position = new Vector3((Mathf.Sin((startRight ? 1.0f : 0.0f) * initial + (Time.time * frequency)) * range) + initialPosition.x, transform.position.y, transform.position.z);
            delay = maxDelay;
        }
        delay -= Time.deltaTime;
    }
}
