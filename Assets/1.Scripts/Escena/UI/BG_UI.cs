using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_UI : MonoBehaviour
{
    public static BG_UI instance;

    private void Awake()
    {
        instance = this; 
    }
}
