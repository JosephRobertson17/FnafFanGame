/*
    This script controlles the players flashlight
    This script is used to rotate, activate, and deactivate the players flashlight
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour {

    public Transform player; // A reference to the players current rotation and location
    public float rotationSpeed; // The rotation speed of the flashlight
    public float minimum_Y_value; // The farthest to the left the flashlight can go
    public float maximum_Y_value; // The farthest to the right the flashlight can go
    public float rotationDirection; // The direction the flashlight is currently rotating
    float currentRotation; // The current direction the flashlight is facing
    float playerCurrentRotation; // The current direction the player is facing

    void FixedUpdate() {
        // Changes the players rotation values from 0 - 360 to -180 - 180
        if(player.eulerAngles.y <= 180f)
        {
            playerCurrentRotation = player.eulerAngles.y;
        }
        else
        {
            playerCurrentRotation = player.eulerAngles.y - 360f;
        }

        // Changes the flashlights direction depending on what direction the player is facing
        if(playerCurrentRotation < -42f) {
            rotationDirection = -1f;
        }
        else if(playerCurrentRotation > -25f) {
            rotationDirection = 1f;
        }

        // Turns the flashlight off if the player is not looking at one of the doors
        if(playerCurrentRotation > 15) {
            GetComponent<Light>().enabled = false;
        }
        else {
            GetComponent<Light>().enabled = true;
        }
    }

    void Update() {
        // Changes the objects rotation values from 0 - 360 to -180 - 180
        if(transform.eulerAngles.y <= 180f)
        {
            currentRotation = transform.eulerAngles.y;
        }
        else
        {
            currentRotation = transform.eulerAngles.y - 360f;
        }

        // Checks if the flashlight should be moving left and isn't at the minimum
        if(rotationDirection < 0 && currentRotation > minimum_Y_value) {
            // Rotates the flashlight
            transform.rotation = Quaternion.Euler(2, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        // Checks if the flashlight should be moving right and isn't at the maximum
        else if(rotationDirection > 0 && currentRotation < maximum_Y_value) {
            // Rotates the flashlight
            transform.rotation = Quaternion.Euler(2, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        else {
            // Corrects for any overshooting caused by the speed of the flashlight by setting the flashlights rotation to it's minimum/maximum after the the flashlight stops 
            if(rotationDirection < 0) {
                transform.rotation = Quaternion.Euler(2, minimum_Y_value, 0);
            }
            else {
                transform.rotation = Quaternion.Euler(2, maximum_Y_value, 0);
            }
        }
    }
}
