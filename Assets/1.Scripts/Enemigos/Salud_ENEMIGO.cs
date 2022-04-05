using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud_ENEMIGO: MonoBehaviour
{
    public bool IsDamaged; 
    public GameObject deathEffect;

    Enemigo enemy;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb; 

    private void Start()
    {
        sprite    = GetComponent<SpriteRenderer>();
        rb        = GetComponent<Rigidbody2D>();  
        material  = GetComponent<Blink>();
        enemy     = GetComponent<Enemigo>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Espada") && !IsDamaged)
        {
            if (collision.GetComponent<Espada>().Atacando)
            {
              enemy.Health -= 2f;
                AudioManager.instance.PlayAudio(AudioManager.instance.hit);

                if (collision.transform.position.x < transform.position.x)
              {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force); 
              }
              else
              {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
              }

                StartCoroutine(damager());
              if(enemy.Health <= 0)
              {
                    AudioManager.instance.PlayAudio(AudioManager.instance.EnemyDeath);

                    Instantiate(deathEffect, transform.position, Quaternion.identity); 
               Destroy(gameObject); 
              }
            }
        }
    }

    IEnumerator damager()
    {
        IsDamaged = true;
        sprite.material = material.blink; 
        yield return new WaitForSeconds(0.5f);
        sprite.material = material.original;
        IsDamaged = false; 
    }
}


 