using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Image : MonoBehaviour
{
    public static Player_Image instance;

    private void Awake()
    {
        instance = this; 
    }
}
