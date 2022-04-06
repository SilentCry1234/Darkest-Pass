using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_UI : MonoBehaviour
{
    
    public Transform Alec_Von_Dum;
    public float xPos;
    public float yPos;
    public float zPos;

    public static Camara_UI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        transform.position = new Vector3(Alec_Von_Dum.position.x + xPos, Alec_Von_Dum.position.y + yPos, zPos);
    }

    void Update()
    {
        transform.position = new Vector3(Alec_Von_Dum.position.x + xPos, Alec_Von_Dum.position.y + yPos, zPos);
    }
}
