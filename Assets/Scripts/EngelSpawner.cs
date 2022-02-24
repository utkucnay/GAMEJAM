using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    public GameObject Engel;
    
    void Start()
    {
        InvokeRepeating("EngelYarat",2f,3f);
        
    }
   
    void EngelYarat()
    {
        Instantiate(Engel, gameObject.transform.position, Quaternion.identity);
    }
}
