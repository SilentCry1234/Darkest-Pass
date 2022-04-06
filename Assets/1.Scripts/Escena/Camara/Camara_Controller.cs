using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Controller : MonoBehaviour
{
    public Transform player;
    public Transform activeRoom;
    public float dampSpeed; 

    public static Camara_Controller instance;

    [Range(-5,5)]
    public float minModX;
    [Range(-5, 5)]
    public float maxModX;
    [Range(-5, 5)]
    public float minModY;
    [Range(-5, 5)]
    public float maxModY;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }

    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;


        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -10f, -10f)
            );

        Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime); 
        transform.position = smoothPos; 
    }
}
