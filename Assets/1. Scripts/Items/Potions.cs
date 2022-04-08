using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public float HealthToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.potion); 
            collision.GetComponent<Salud_Alec>().Vida += HealthToGive;
            Destroy(gameObject); 
        }
    }
}
