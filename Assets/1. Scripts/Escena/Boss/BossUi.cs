using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BossUi : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject walls;

    public static BossUi instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
            instance = this; 
        }
    }

    private void Start()
    {
        bossPanel.SetActive(false); 
        walls.SetActive(false); 
    }

    public void BossActivator()
    {
        bossPanel.SetActive(true); 
        walls.SetActive(true); 
    } 
    
    public void BossDeactivator()
    {
        bossPanel.SetActive(false); 
        walls.SetActive(false);
        StartCoroutine(BossDefeated()); 
    }

    IEnumerator BossDefeated()
    {
        var velocity = Movmiento_Alec.instance.GetComponent<Rigidbody2D>().velocity;

        Vector2 originalSpeed = velocity; 
        velocity = new Vector2(0, velocity.y); 
        Movmiento_Alec.instance.enabled = false;
        yield return new WaitForSeconds(3);
        Movmiento_Alec.instance.enabled = true;
        velocity = originalSpeed; 
    }

}
