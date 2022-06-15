/*
    The CameraController script is attached to an empty object that is used to manage the security camera system
    This script manages all cameras in the scene and handles the player switching between cameras
    This script also manages any ui elements associated with any of the cameras
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras; // An array of all cameras in the scene
    public GameObject[] cameraButton; // An array of all buttons on the security camera screen
    public int currentCamera; // What camera in the cameras array the player is currently looking at
    public int lastSecurityCamera; // The last security camera the player was on
    public bool exitedOnTasks; // Did the player put the camera away while on tasks

    void Start() {
        currentCamera = 0; // Sets the current camera to the players main pov
        lastSecurityCamera = 1; // Sets a start value for the security cameras
        exitedOnTasks = false; // Sets a default value for exitedOnTasks so the player enters on the security cameras the firts time they open the side panel
        // Disables all buttons for the security camera screen
        for(int i = 0; i < 5; i++) {
            cameraButton[i].SetActive(false);
        }
    }

    public void switchCamera(int nextCamera) {
        // Checks if the player currenty is on the security cameras and is putting them away
        if(nextCamera == 0 && currentCamera != 0) {
            lastSecurityCamera = currentCamera; // Sets the last security camera the player was looking at
        }
        // Checks if the player currenty is on the security cameras and is switching to the tasks menu
        else if(nextCamera >= 20 && currentCamera != 0) { 
            lastSecurityCamera = currentCamera; // Sets the last security camera the player was looking at
        }

        cameras[currentCamera].enabled = false; // Disables the camera the player is currently looking at
        cameras[nextCamera].enabled = true; // Enables the camera the player should be looking at
        currentCamera = nextCamera; // Sets currentCamera to the new camera

        // Checks it the player is on the main pov or the tasks menu
        if(currentCamera == 0 || currentCamera >= 20){
            // Disables all security camera buttons
            for(int i = 0; i < 5; i++) {
                cameraButton[i].SetActive(false);
            }
        }
        else {
            // Enables the security camera buttons if the player is looking at the securtiy cameras
            for(int i = 0; i < 5; i++) {
                cameraButton[i].SetActive(true);
            }
        }
    }

    public int getLastSecurityCamera() { // Used to get the security camera the player was last looking at
        return lastSecurityCamera;
    }
}
