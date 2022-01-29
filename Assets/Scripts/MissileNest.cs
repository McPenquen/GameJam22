using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileNest : MonoBehaviour
{
    private bool releasedMissile = false;
    private void Start()
    {
        // Deactivates the missile until the nest becomes visible
        transform.GetChild(0).gameObject.SetActive(false);
        releasedMissile = false;
    }
    private void OnBecameVisible()
    {   
        if (!releasedMissile)
        {
            // Activate the missile when the nest appears on the screen
            transform.GetChild(0).gameObject.SetActive(true);
            releasedMissile = true;
        }
    }

}
