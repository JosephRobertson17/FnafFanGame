/*
    This script is used to control the side panel that swings out when the player moves all the way the the right
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScript : MonoBehaviour
{
    public float rotationDirection = 1f; // The monitors current rotation direction
    public float rotationSpeed = 40f; // The speed that the monitor rotates
    float currentRotation; // The current rotation of the monitor
    public float maximum_Y_value; // The maximum rotation of the monitor
    public float minimum_Y_value; // The minimum rotation of the monitor
    bool cameraActive; // Is the the security camera system active

    public CameraController cameraController;

    // Update is called once per frame
    void Update()
    {
        // Changes the objects rotation values from 0 - 360 to -180 - 180
        if(transform.eulerAngles.y <= 180f)
        {
            currentRotation = transform.eulerAngles.y;
        }
        else
        {
            currentRotation = transform.eulerAngles.y - 360f;
        }

        // Checks if the monitor should be moving left and isn't at the minimum
        if(rotationDirection < 0 && currentRotation > minimum_Y_value) {
            // Rotates the monitor
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        // Checks if the monitor should be moving right and isn't at the maximum
        else if(rotationDirection > 0 && currentRotation < maximum_Y_value) {
            // Rotates the monitor
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }

        // Checks if the monitor is all the way out
        if(rotationDirection < 0 && currentRotation <= minimum_Y_value && !cameraActive) {
            // Activates the security camera system
            cameraController.switchCamera(cameraController.getLastSecurityCamera());
            cameraActive = true;
        }
        else if(rotationDirection > 0) {
            // Deactivates the security system if the monitor is not all the way  out
            cameraController.switchCamera(0);
            cameraActive = false;
        }
    }

    public void changeDirection(float x) { // Changes the direction of the monitors rotation
        rotationDirection = x;
    }
}
