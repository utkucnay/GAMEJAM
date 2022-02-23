using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    public GameObject Engel;
    
    void Start()
    {
        Instantiate(Engel,gameObject.transform.position, Quaternion.identity);
    }
}
