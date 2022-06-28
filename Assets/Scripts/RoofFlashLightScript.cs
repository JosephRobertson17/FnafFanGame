using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofFlashLightScript : MonoBehaviour
{
    public Transform player;
    float playerCurrentXRotation;


    // Update is called once per frame
    void Update()
    {
        if(player.eulerAngles.x <= 180f)
        {
            playerCurrentXRotation = player.eulerAngles.x;
        }
        else
        {
            playerCurrentXRotation = player.eulerAngles.x - 360f;
        }

        if(playerCurrentXRotation < -60) {
            GetComponent<Light>().enabled = true;
        }
        else {
            GetComponent<Light>().enabled = false;
        }
    }
}
