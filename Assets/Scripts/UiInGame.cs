using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject[] emptyCoins; 
    public GameObject[] fullCoins;

    // Start is called before the first frame update
    void Start()
    {
        hs = GameObject.Find("Player1").GetComponent<HealthSystem>();
        for(int i = 0; i < 5; i++){
            fullCoins[i].SetActive(false);
            emptyCoins[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hs.health);

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

        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }

    public void coinUI(int i, bool isActive){ 
        
        if(isActive){
            emptyCoins[i].SetActive(false);
            fullCoins[i].SetActive(true);
        }
    }
}
