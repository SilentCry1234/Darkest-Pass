using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Vida : MonoBehaviour
{
    public static BG_Vida instance;

    private void Awake()
    {
        instance = this; 
    }

}
