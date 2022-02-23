using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{

    public int CharSpeed;
    public float CharSpeedMultiplier;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0,0,CharSpeed*CharSpeedMultiplier);
    }
}
