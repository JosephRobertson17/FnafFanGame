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
    public float minimum_X_value;
    public float maximum_X_value;
    public float rotationDirection; // The direction the flashlight is currently rotating
    public float currentYRotation; // The current direction the flashlight is facing
    public float currentXRotation;
    public float playerCurrentYRotation; // The current direction the player is facing
    public float playerCurrentXRotation;

    void FixedUpdate() {
        // Changes the players rotation values from 0 - 360 to -180 - 180
        if(player.eulerAngles.y <= 180f)
        {
            playerCurrentYRotation = player.eulerAngles.y;
        }
        else
        {
            playerCurrentYRotation = player.eulerAngles.y - 360f;
        }

        if(player.eulerAngles.x <= 180f)
        {
            playerCurrentXRotation = player.eulerAngles.x;
        }
        else
        {
            playerCurrentXRotation = player.eulerAngles.x - 360f;
        }

        // Changes the flashlights direction depending on what direction the player is facing
        if(playerCurrentYRotation < -42f) {
            rotationDirection = -1f;
        }
        else if(playerCurrentYRotation > -25f) {
            rotationDirection = 1f;
        }

        // Turns the flashlight off if the player is not looking at one of the doors
        if(playerCurrentYRotation > 15) {
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

        // Checks if the flashlight should be moving left and isn't at the minimum
        if(rotationDirection < 0 && currentYRotation > minimum_Y_value) {
            // Rotates the flashlight
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, transform.localRotation.eulerAngles.z);
        }
        // Checks if the flashlight should be moving right and isn't at the maximum
        else if(rotationDirection > 0 && currentYRotation < maximum_Y_value) {
            // Rotates the flashlight
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, transform.localRotation.eulerAngles.z);
        }
        else {
            // Corrects for any overshooting caused by the speed of the flashlight by setting the flashlights rotation to it's minimum/maximum after the the flashlight stops 
            if(rotationDirection < 0) {
                transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, minimum_Y_value, transform.localRotation.eulerAngles.z);
            }
            else {
                transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, maximum_Y_value, transform.localRotation.eulerAngles.z);
            }
        }

        if(playerCurrentXRotation < -10 && currentXRotation > minimum_X_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x - rotationSpeed*Time.deltaTime,transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z);
        }
        else if(playerCurrentXRotation > -10 && currentXRotation < maximum_X_value) {
            transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x + rotationSpeed*Time.deltaTime,transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z);
        }
        else {
            if(playerCurrentXRotation < -10) {
                transform.rotation = Quaternion.Euler(minimum_X_value,transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z);
            }
            else {
                transform.rotation = Quaternion.Euler(maximum_X_value,transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z);
            }
        }
    }
}
