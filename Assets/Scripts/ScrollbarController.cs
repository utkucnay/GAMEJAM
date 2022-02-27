using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScrollbarController : MonoBehaviour
{
    public Transform Distance1;
    public Transform Distance2;
    public float firsDistance;
    public float firsStart;
    Scrollbar Scrollbar;
    float gidilenMiktar;
    // Start is called before the first frame update
    void Start()
    {
        gidilenMiktar = 0;
        firsStart = Distance1.position.z;
        Scrollbar = GetComponent<Scrollbar>();
        firsDistance = Distance2.position.z - Distance1.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gidilenMiktar = Distance1.position.z - firsStart;
        Scrollbar.size =  gidilenMiktar/ firsDistance * 95/100;
    }
}
