/*
    This script is used to control the players veiw by moving the mouse to the edge of the screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    float maximum_Y_value = 35f; // The farthest the camera can move to the right
    float minimum_Y_value = -45f; // The farthest the camera can move to the left
    float maximum_X_value = 8f;
    float minimum_X_value = -75f;
    public float rotationSpeed = 10f; // How fast the camera rotates
    public float rotationDirection = 0f; // What direction is the camera currently rotating
    public float currentYRotation; // What is the current direction the camera is facing
    public float currentXRotation;
    public float screenWidth; // How wide in pixles is the screen
    public float screenHeight;
    public MonitorScript monitor; // The players monitor that pops up when the player moves all the way to the right
    public bool isLookingUp = false;

    void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition; // A 3 dimentional vector of the users mouse
        screenWidth = Screen.width; // setting the screen width
        screenHeight = Screen.height;
        if(mousePos.y > screenHeight - screenHeight/20f && !isLookingUp) {
            isLookingUp = true;
        }
        else if (mousePos.y < screenHeight/20f && isLookingUp) {
            isLookingUp = false;
        }
        
        if(mousePos.x < screenWidth/20f && !isLookingUp) { // Check if the mouse is on the left side of the screen
            rotationDirection = -1f; // Change the rotation direction to rotate left
        }
        else if(mousePos.x > screenWidth - screenWidth/20f && !isLookingUp) { // Check if the mouse is on the right side of the screen
            rotationDirection = 1f; // Set the rotation direction to rotate right
        }
        else {
            if(!isLookingUp) {
                rotationDirection = 0;
            }
            else {
                if(currentYRotation > 0.3f) {
                    rotationDirection = -1f;
                }
                else if(currentYRotation < -0.3f) {
                    rotationDirection = 1f;
                }
                else {
                    rotationDirection = 0;
                    transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, 0, 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Changes the objects rotation values from 0 - 360 to -180 - 180
        if(transform.eulerAngles.y <= 180f)
        {
            currentYRotation = transform.eulerAngles.y;
        }
        else
        {
            currentYRotation = transform.eulerAngles.y - 360f;
        }

        if(transform.eulerAngles.x <= 180f)
        {
            currentXRotation = transform.eulerAngles.x;
        }
        else
        {
            currentXRotation = transform.eulerAngles.x - 360f;
        }

        // Makes the monitor appear and disappear depending on the players rotation
        if(currentYRotation > 30) {
            monitor.changeDirection(-1f);
        }
        else{
            monitor.changeDirection(1f);
        }

        // Checks if the player should be moving left and isn't at the minimum
        if(rotationDirection < 0 && currentYRotation > minimum_Y_value) {
            // Rotates the players camera
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        // Checks if the player should be moving right and isn't at the maximum
        else if(rotationDirection > 0 && currentYRotation < maximum_Y_value) {
            // Rotates the players camera
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }

        if(isLookingUp && currentXRotation > minimum_X_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x - rotationSpeed*Time.deltaTime*1.5f, transform.localRotation.eulerAngles.y, 0);
        }
        else if(isLookingUp &&currentXRotation < minimum_X_value - 0.2f) {
            transform.rotation = Quaternion.Euler(minimum_X_value, transform.localRotation.eulerAngles.y, 0);
        }
        else if(!isLookingUp && currentXRotation < maximum_X_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x + rotationSpeed*Time.deltaTime*1.5f, transform.localRotation.eulerAngles.y, 0);
        }
        else if (!isLookingUp && currentXRotation > maximum_X_value + 0.2f) {
            transform.rotation = Quaternion.Euler(maximum_X_value, transform.localRotation.eulerAngles.y, 0);
        }
    }
}
