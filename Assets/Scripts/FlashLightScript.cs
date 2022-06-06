using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour {

    public Transform player;
    public float rotationSpeed;
    public float minimum_Y_value;
    public float maximum_Y_value;
    public float rotationDirection;
    float currentRotation;
    float playerCurrentRotation;

    void FixedUpdate() {
        if(player.eulerAngles.y <= 180f)
        {
            playerCurrentRotation = player.eulerAngles.y;
        }
        else
        {
            playerCurrentRotation = player.eulerAngles.y - 360f;
        }
        if(playerCurrentRotation < -42f) {
            rotationDirection = -1f;
        }
        else if(playerCurrentRotation > -25f) {
            rotationDirection = 1f;
        }
        if(playerCurrentRotation > 15) {
            GetComponent<Light>().enabled = false;
        }
        else {
            GetComponent<Light>().enabled = true;
        }
    }

    void Update() {
        if(transform.eulerAngles.y <= 180f)
        {
            currentRotation = transform.eulerAngles.y;
        }
        else
        {
            currentRotation = transform.eulerAngles.y - 360f;
        }
        if(rotationDirection < 0 && currentRotation > minimum_Y_value) {
            transform.rotation = Quaternion.Euler(2, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        else if(rotationDirection > 0 && currentRotation < maximum_Y_value) {
            transform.rotation = Quaternion.Euler(2, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
        }
        else {
            if(rotationDirection < 0) {
                transform.rotation = Quaternion.Euler(2, minimum_Y_value, 0);
            }
            else {
                transform.rotation = Quaternion.Euler(2, maximum_Y_value, 0);
            }
        }
    }
}
