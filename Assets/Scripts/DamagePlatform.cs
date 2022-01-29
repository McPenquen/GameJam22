using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlatform : MonoBehaviour
{
    public GameObject player;
    public HealthSystem health;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("Player1").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            health.Damage();
    }
}
