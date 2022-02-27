using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dondur : MonoBehaviour
{
    public Vector3 rotateVector = new Vector3(-1, 0, 0);
    public float speed = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    transform.Rotate(rotateVector* speed * Time.fixedDeltaTime);
    }
}
