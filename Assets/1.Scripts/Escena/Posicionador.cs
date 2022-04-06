using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicionador : MonoBehaviour
{
    //El jugador se posiciona en la parte principal del nivel. 
    private void Start()
    {
        Movmiento_Alec player = GameObject.FindObjectOfType<Movmiento_Alec>();
        player.transform.position = transform.position;
    }

}
