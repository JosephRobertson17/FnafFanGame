using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float minimum_Y_value;
    public float maximum_Y_value;
    float currentRotation;
    public float directionChangeDelay = 1f;
    public float delayReset;
    public float rotationSpeed = 20f;
    public float rotationDirection = 1f;

    void Start() {  
        delayReset = directionChangeDelay;
    }

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


        if(currentRotation < 0 && currentRotation >= minimum_Y_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
            directionChangeDelay = delayReset;
        }
        else if(currentRotation < 0 && currentRotation <= minimum_Y_value) {
            if(directionChangeDelay <= 0) {
                rotationDirection = 1f;
            }
            else {
                directionChangeDelay  -= Time.deltaTime;
            }
        }
        if(currentRotation > 0 && currentRotation <= maximum_Y_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
            directionChangeDelay = delayReset;
        }
        else if(currentRotation > 0 && currentRotation >= maximum_Y_value) {
            if(directionChangeDelay <= 0) {
                rotationDirection = -1f;
            }
            else {
                directionChangeDelay  -= Time.fixedDeltaTime;
            }
        }
    }

    public void setEnable(bool active) {
        GetComponent<Light>().enabled = active;
    }
}
