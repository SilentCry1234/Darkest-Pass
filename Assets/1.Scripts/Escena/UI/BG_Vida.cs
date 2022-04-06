using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Vida : MonoBehaviour
{
    public static BG_Vida instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

}
