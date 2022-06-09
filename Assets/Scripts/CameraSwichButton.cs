using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwichButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int cameraNumber;
    public CameraController cameraController;

    public void buttonPress() {
        cameraController.switchCamera(cameraNumber);
    }
}
