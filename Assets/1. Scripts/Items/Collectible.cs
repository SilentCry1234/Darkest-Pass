using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int daggersToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.fireStone);
            FireStone.instance.SubItem(daggersToGive);
            Destroy(gameObject); 
        }
    }
}
