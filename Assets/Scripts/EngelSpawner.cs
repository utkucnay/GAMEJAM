using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    public GameObject Engel;
    public GameObject Yemek;


    void Start()
    {
        InvokeRepeating("EngelYarat",2f,3f);
    }
   
    void EngelYarat()
    {
        int oldNumer = -1;
        for (int i = 0; i < Random.Range(1,3); i++)
        {
            int NewNumber = Random.Range(0, 3);
            if (NewNumber != oldNumer)
            {
                Instantiate(Engel, gameObject.transform.GetChild(NewNumber).position, Quaternion.identity);
                oldNumer = NewNumber;
            }
            else
            {
                while (oldNumer == NewNumber)
                {
                    NewNumber = Random.Range(0, 3);
                }
                Instantiate(Yemek, gameObject.transform.GetChild(NewNumber).position, Quaternion.identity);
            }
        }
    }

    void ResetTime(float repeatTime)
    {
        CancelInvoke("EngelYarat");
        InvokeRepeating("EngelYarat", 0, repeatTime);
    }
}
