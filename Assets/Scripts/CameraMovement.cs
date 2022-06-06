using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float maximum_Y_value = 35f;
    float minimum_Y_value = -45f;
    public float rotationSpeed = 10f;
    float rotationDirection = 0f;
    public float currentRotation;
    public float screenWidth;
    public MonitorScript monitor;

    void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition;
        screenWidth = Screen.width;
        if(mousePos.x < screenWidth/20f) {
            rotationDirection = -1f;
        }
        else if(mousePos.x > screenWidth - screenWidth/20f) {
            rotationDirection = 1f;
        }
        else {
            rotationDirection = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // currentRotation = transform.localRotation.eulerAngles.y;
        if(transform.eulerAngles.y <= 180f)
        {
            currentRotation = transform.eulerAngles.y;
        }
        else
        {
            currentRotation = transform.eulerAngles.y - 360f;
        }
        if(currentRotation > 25) {
            monitor.changeDirection(-1f);
        }
        else{
            monitor.changeDirection(1f);
        }
        if(rotationDirection < 0 && currentRotation > minimum_Y_value) {
            transform.rotation = Quaternion.Euler(15f, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        else if(rotationDirection > 0 && currentRotation < maximum_Y_value) {
            transform.rotation = Quaternion.Euler(15f, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
    }
}
