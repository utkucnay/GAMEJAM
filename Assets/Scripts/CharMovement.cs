using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public enum stage
    {
        mid,
        left,
        right
    };
    public stage currentstage;

    float m_lastPressed;

    public Transform MidLoc;
    public Transform LeftLoc;
    public Transform RightLoc;

    public int CharSpeed;
    public float CharSpeedMultiplier;
    private void Start()
    {
        currentstage = stage.mid;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (currentstage)
            {
                case stage.mid:
                    currentstage = stage.left;
                    transform.position = LeftLoc.position;
                    break;
                case stage.left:
                    break;
                case stage.right:
                    currentstage = stage.mid;
                    transform.position = LeftLoc.position;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            switch (currentstage)
            {
                case stage.mid:
                    currentstage = stage.right;
                    transform.position = RightLoc.position;
                    break;
                case stage.right:
                    break;
                case stage.left:
                    currentstage = stage.mid;
                    transform.position = RightLoc.position;
                    break;
            }

        }
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, CharSpeed * CharSpeedMultiplier);
    }
}