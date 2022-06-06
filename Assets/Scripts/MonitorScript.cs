using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScript : MonoBehaviour
{
    float rotationDirection = 1f;
    public float rotationSpeed = 40f;
    float currentRotation;
    public float maximum_Y_value;
    public float minimum_Y_value;

    // Update is called once per frame
    void Update()
    {
        if(transform.eulerAngles.y <= 180f)
        {
            currentRotation = transform.eulerAngles.y;
        }
        else
        {
            currentRotation = transform.eulerAngles.y - 360f;
        }
        if(rotationDirection < 0 && currentRotation > minimum_Y_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        else if(rotationDirection > 0 && currentRotation < maximum_Y_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
    }

    public void changeDirection(float x) {
        rotationDirection = x;
    }
}