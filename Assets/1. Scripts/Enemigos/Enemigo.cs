using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Caracteristicas")]
    [Space]
    public string enemyName;
    public float Health;
    public float speed;
    public float knockbackForceX; 
    public float knockbackForceY;
    public float damageToGive;

    public static Enemigo instance;

   private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }


}
