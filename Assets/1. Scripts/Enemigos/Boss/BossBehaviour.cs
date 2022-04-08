using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BossBehaviour : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;

    public float timeToShoot, countDown; 
    public float timeToTp, countDownToTp;

    public float bossHealth, currentHealth;
    public Image HealthIMG; 

    private void Start()
    {
        //var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[1].position;
        countDown = timeToShoot;
        countDownToTp = timeToTp;
    }

    private void Update()
    {
        CountDowns();
        DamageBoss();
        BossScale(); 
    }

    public void CountDowns()
    {
        countDown -= Time.deltaTime;
        countDownToTp -= Time.deltaTime;

        if (countDown < 0)
        {
            shootPlayer();
            countDown = timeToShoot;
            Teleport();
        }

        if (countDownToTp <= 0)
        {
            countDownToTp = timeToTp;
            Teleport();
        }
    }

    public void shootPlayer()
    {
        GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }

    public void Teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }

    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemigo>().Health; 
        HealthIMG.fillAmount = currentHealth / bossHealth; 
    }

    private void OnDestroy()
    {
        BossUi.instance.BossDeactivator(); 
    }

    public void BossScale()
    {
        if(transform.position.x > Movmiento_Alec.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
