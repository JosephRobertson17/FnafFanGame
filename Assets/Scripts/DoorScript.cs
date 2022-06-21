/*
    This script controls the doors that the player can close
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    
    public bool doorIsClosed = false; // Is the door closed
    public float maxYValue; // The y value of the door when it is fully opened
    public float minYValue; // The y value of the door when it is fully closed
    public float doorSpeed = 6f; // The speed of the door

    // Update is called once per frame
    void Update() {
        if(doorIsClosed && transform.position.y > minYValue) { // Checks if the door should be closed and is not closed
            // Closes the door
            transform.position = new Vector3(transform.position.x, transform.position.y - doorSpeed * Time.deltaTime, transform.position.z);
        }
        else if(!doorIsClosed && transform.position.y < maxYValue) { // Checks if the door should be open but is not open\
            // Opens the door
            transform.position = new Vector3(transform.position.x, transform.position.y + doorSpeed * Time.deltaTime, transform.position.z);
        }
        else if(doorIsClosed && transform.position.y < minYValue) {
            transform.position = new Vector3(transform.position.x, minYValue, transform.position.z);
        }
    }

    // Switches the door from open to closed and from closed to open
    public void changeDoorState() {
        doorIsClosed = !doorIsClosed;
    }
}
