using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroyer : MonoBehaviour
{
    public float secondsDestroy; 
    void Start()
    {
        Destroy(gameObject, secondsDestroy);
    }
}
