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
    public float rotationSpeed = 10f; // How fast the camera rotates
    float rotationDirection = 0f; // What direction is the camera currently rotating
    public float currentRotation; // What is the current direction the camera is facing
    public float screenWidth; // How wide in pixles is the screen
    public MonitorScript monitor; // The players monitor that pops up when the player moves all the way to the right

    void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition; // A 3 dimentional vector of the users mouse
        screenWidth = Screen.width; // setting the screen width
        if(mousePos.x < screenWidth/20f) { // Check if the mouse is on the left side of the screen
            rotationDirection = -1f; // Change the rotation direction to rotate left
        }
        else if(mousePos.x > screenWidth - screenWidth/20f) { // Check if the mouse is on the right side of the screen
            rotationDirection = 1f; // Set the rotation direction to rotate right
        }
        else {
            rotationDirection = 0f; // Set the rotation direction to 0 if the mouse is not on either side of the screen
        }
    }

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

        // Makes the monitor appear and disappear depending on the players rotation
        if(currentRotation > 30) {
            monitor.changeDirection(-1f);
        }
        else{
            monitor.changeDirection(1f);
        }

        // Checks if the player should be moving left and isn't at the minimum
        if(rotationDirection < 0 && currentRotation > minimum_Y_value) {
            // Rotates the players camera
            transform.rotation = Quaternion.Euler(15f, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        // Checks if the player should be moving right and isn't at the maximum
        else if(rotationDirection > 0 && currentRotation < maximum_Y_value) {
            // Rotates the players camera
            transform.rotation = Quaternion.Euler(15f, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
    }
}
