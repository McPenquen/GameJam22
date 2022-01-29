using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInGame : MonoBehaviour
{
    public GameObject player;
    public HealthSystem hs;
    public GameObject emptyHealth1;
    public GameObject emptyHealth2;
    public GameObject emptyHealth3;
    public GameObject fullHealth1;
    public GameObject fullHealth2;
    public GameObject fullHealth3;

    // Start is called before the first frame update
    void Start()
    {
        hs = GameObject.Find("Player1").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hs.health);

        if(hs.health == 3){
            fullHealth1.SetActive(true);
            fullHealth2.SetActive(true);
            fullHealth3.SetActive(true);

            emptyHealth1.SetActive(false);
            emptyHealth2.SetActive(false);
            emptyHealth3.SetActive(false);
        }

        if(hs.health == 2){
            fullHealth1.SetActive(true);
            fullHealth2.SetActive(true);
            fullHealth3.SetActive(false);

            emptyHealth1.SetActive(false);
            emptyHealth2.SetActive(false);
            emptyHealth3.SetActive(true);
        }

        if(hs.health == 1){
            fullHealth1.SetActive(true);
            fullHealth2.SetActive(false);
            fullHealth3.SetActive(false);

            emptyHealth1.SetActive(false);
            emptyHealth2.SetActive(true);
            emptyHealth3.SetActive(true);
        }

        if(hs.health == 0){
            fullHealth1.SetActive(false);
            fullHealth2.SetActive(false);
            fullHealth3.SetActive(false);

            emptyHealth1.SetActive(true);
            emptyHealth2.SetActive(true);
            emptyHealth3.SetActive(true);
        }
    }
}
