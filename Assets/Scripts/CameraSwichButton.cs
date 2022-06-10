/*
    This script is used to swich cameras when one of the securiy camera buttons is pressed
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwichButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int cameraNumber; // The camera number that the button belongs to
    public CameraController cameraController; // A reference to the camera controller

    public void buttonPress() { // Called when the button is pressed
        cameraController.switchCamera(cameraNumber);
    }
}
