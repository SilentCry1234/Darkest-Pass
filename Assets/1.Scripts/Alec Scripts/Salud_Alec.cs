using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Salud_Alec : MonoBehaviour
{
    [Header("Vida")]
    [Space]
    public float Vida;
    public float maxVida;

    [Header("Retraso")]
    [Space]
    bool isInmune; 
    public float tiempoInmune;

    [Header("Retroceso")]
    [Space]
    public float knockbackForceX;
    public float knockbackForceY;

    public Image ImagenVida;
    public GameObject GameOverImage;

    public bool isDead; 

    Blink material;
    SpriteRenderer sprite1;
    Rigidbody2D rbA; 

    void Start()
    {
        GameOverImage.SetActive(false);
        rbA      = GetComponent<Rigidbody2D>(); 
        sprite1  = GetComponent<SpriteRenderer>(); 
        material = GetComponent<Blink>(); 
        Vida     = maxVida;
        material.original = sprite1.material; 
        if(!isDead)
        {
            GameOverImage.GetComponent<CanvasGroup>().alpha = 0.0f; 
        }
    }

    void Update()
    {
        ImagenVida.fillAmount = Vida / 100; 
        if(Vida > maxVida)
        {
            Vida = maxVida; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")  && !isInmune)
        {
            Vida -= collision.GetComponent<Enemigo>().damageToGive;
            AudioManager.instance.PlayAudio(AudioManager.instance.hitPlayer);

            StartCoroutine(Inmunidad()); 

            if(collision.transform.position.x > transform.position.x)
            {
                rbA.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force); 
            }
            else
            {
                rbA.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            if (Vida <=0)
            {
                // Aparecer pantalla de game over 
                AudioManager.instance.PlayAudio(AudioManager.instance.PlayerDeath);
                isDead = true;
                StartCoroutine(CartelMuerte()); 
            }
        }
    }

    IEnumerator Inmunidad()
    {
        isInmune = true;
        sprite1.material = material.blink;
        yield return new WaitForSeconds(tiempoInmune);
        sprite1.material = material.original;
        isInmune = false;
    }

    IEnumerator CartelMuerte()
    {
        if (isDead)
        {
            Time.timeScale = 0;
            GameOverImage.SetActive(true);

            AudioManager.instance.backgroundMusic.Stop();

            while (GameOverImage.GetComponent<CanvasGroup>().alpha < 1f)
            {
                GameOverImage.GetComponent<CanvasGroup>().alpha += 0.005f;
                yield return new WaitForSecondsRealtime(0.01f); 
            }
        }
    }
}
