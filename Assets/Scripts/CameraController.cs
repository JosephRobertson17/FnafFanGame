using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject[] cameraButton;
    public int currentCamera;
    public int lastSecurityCamera;
    public bool exitedOnTasks;

    void Start() {
        currentCamera = 0;
        lastSecurityCamera = 1;
        exitedOnTasks = false;
        for(int i = 0; i < 5; i++) {
            cameraButton[i].SetActive(false);
        }
    }

    public async void switchCamera(int nextCamera) {
        if(nextCamera == 0 && currentCamera != 0) {
            lastSecurityCamera = currentCamera;
            for(int i = 0; i < 5; i++) {
                cameraButton[i].SetActive(true);
            }
        }
        else if(nextCamera >= 20 && currentCamera != 0) {
            lastSecurityCamera = currentCamera;
            for(int i = 0; i < 5; i++) {
                cameraButton[i].SetActive(true);
            }
        }

        cameras[currentCamera].enabled = false;
        cameras[nextCamera].enabled = true;
        currentCamera = nextCamera;

        if(currentCamera == 0 || currentCamera >= 20){
            for(int i = 0; i < 5; i++) {
                cameraButton[i].SetActive(false);
            }
        }
        else {
            for(int i = 0; i < 5; i++) {
                cameraButton[i].SetActive(true);
            }
        }
    }

    public int getLastSecurityCamera() {
        return lastSecurityCamera;
    }
}
