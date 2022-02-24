using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    enum stage
    {
        mid,
        left,
        right
    };
    stage currentstage;

    public Transform MidLoc;
    public Transform LeftLoc;
    public Transform RightLoc;

    float timeLimit;
    float pastTime;

    public float CharSpeed;
    public float CharSpeedMultiplier;
    private void Start()
    {
        currentstage = stage.mid;
        timeLimit = 10;
        pastTime = 0;
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
        if (Time.fixedTime - pastTime > timeLimit)
        {
            pastTime = Time.fixedTime;
            //CharSpeedMultiplier = pastTime / 500;
        }
        transform.position += new Vector3(0, 0, CharSpeed * CharSpeedMultiplier);
    }
}