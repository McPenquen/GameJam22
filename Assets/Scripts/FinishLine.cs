using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    public float timeUntilWin = 1f;
    private float currentTime = 0;
    private bool updateTime;

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
        if (currentTime >= timeUntilWin)
        {
            updateTime = false;
            currentTime = 0;
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        updateTime = true;
    }
}
