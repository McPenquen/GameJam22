using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    public float timeUntilDestroy = 2f;
    public float timeUntilRespawn = 4f;

    private float currentTime;
    private bool updateTime;
    private bool isDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTime)
        {
            currentTime += Time.deltaTime;
        }
        if (currentTime >= timeUntilDestroy && isDisabled)
        {
            DisableObject();
        }
        if (currentTime >= timeUntilRespawn)
        {
            EnableObject();
        }
        print(currentTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentTime = 0;
        updateTime = true;
        isDisabled = true;
    }

    private void DisableObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        isDisabled = false;
    }

    private void EnableObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        updateTime = false;
    }
}
