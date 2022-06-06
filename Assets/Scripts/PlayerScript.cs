using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Transform playerCamera;
    public CameraScript[] cameras;
    CameraScript currentCamera;



    void Update() {
        
    }


    public void setCamera1Enable(bool active) {
        currentCamera.setEnable(!active);
        cameras[0].setEnable(active);
        currentCamera = cameras[2];
    }
    public void setCamera2Enable(bool active) {
        currentCamera.setEnable(!active);
        cameras[1].setEnable(active);
        currentCamera = cameras[2];
    }
    public void setCamera3Enable(bool active) {
        currentCamera.setEnable(!active);
        cameras[2].setEnable(active);
        currentCamera = cameras[2];
    }
    public void setCamera4Enable(bool active) {
        currentCamera.setEnable(!active);
        cameras[3].setEnable(active);
        currentCamera = cameras[2];
    }
}
