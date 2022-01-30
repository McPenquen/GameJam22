using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CursorSystem : MonoBehaviour
{
    void Awake() { Cursor.lockState = CursorLockMode.Locked; }
}