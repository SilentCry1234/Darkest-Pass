using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FireStone : MonoBehaviour
{
    public Text fireStonesText; 
    public int fireStonesAmount;

    public static FireStone instance;

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
        fireStonesText = GameObject.FindGameObjectWithTag("FireStoneText").GetComponent<Text>(); 
        fireStonesText.text = "X " + fireStonesAmount.ToString(); 
    }

    public void SubItem(int subItemAmount)
    {
        fireStonesAmount += subItemAmount;
        fireStonesText.text = "X " + fireStonesAmount.ToString();
    }


}
