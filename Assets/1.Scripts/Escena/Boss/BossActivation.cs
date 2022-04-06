using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossGO;

    private void Start()
    {
        bossGO.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BossUi.instance.BossActivator();
            //llama al jefe
            StartCoroutine(waitForBoss());
        }

    }

    IEnumerator waitForBoss()
    {
        var currentSpeed = Movmiento_Alec.instance.Velocidad;
        Movmiento_Alec.instance.Velocidad = 0;
        bossGO.SetActive(true);
        yield return new WaitForSeconds(3f);
        Movmiento_Alec.instance.Velocidad = currentSpeed;
        Destroy(gameObject); 
    }
}
