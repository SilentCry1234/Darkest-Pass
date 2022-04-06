using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{
    public int fireStoneCost;
    public GameObject dagger;

    private void Update()
    {
        UseSubWeapons(); 
    }

    public void UseSubWeapons()
    {
        if (Input.GetButtonDown("Fire2") && fireStoneCost <= FireStone.instance.fireStonesAmount)
        {
            FireStone.instance.SubItem(-fireStoneCost);
            GameObject subitem =  Instantiate(dagger, transform.position, Quaternion.Euler(0,0, -132));

            if(transform.localScale.x < 0)
            {
              subitem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f, 0f), ForceMode2D.Force);
                subitem.transform.localScale = new Vector2(-1, -1); 
            }
            else
            {
                subitem.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 0f), ForceMode2D.Force);
            }
        }

    }
}
