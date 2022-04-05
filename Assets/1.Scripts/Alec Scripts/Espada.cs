using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public bool Atacando;

    private void Start()
    {
        Atacando = false; 
    }

    void Update()
    {
        Ataque(); 
    }
    public void Ataque()
    {
        if (Input.GetButton("Fire1"))
        {
            Atacando = true;
        }
        else
        {
            Atacando = false;
        }
    }
}
