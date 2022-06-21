using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    bool frontDoorClosed;
    bool leftDoorClosed;
    public bool animatronicAtFrontDoor;
    public bool animatronicAtLeftDoor;
    public bool gameOver;
    public float frontDoorAnimatronicTollerance;
    public float leftDoorAnimatronicTollerance;
    float leftDoorAnimatronicTolleranceReset;
    float frontDoorAnimatronicTolleranceReset;
    public GameObject gameOverText;
    void Start() {
        gameOver = false;
        animatronicAtLeftDoor = false;
        animatronicAtFrontDoor = false;
        frontDoorClosed = false;
        leftDoorClosed = false;
        leftDoorAnimatronicTolleranceReset = leftDoorAnimatronicTollerance;
        frontDoorAnimatronicTolleranceReset = frontDoorAnimatronicTollerance;
    }

    void Update() {
        if(animatronicAtFrontDoor && frontDoorAnimatronicTollerance <= 1.3f && frontDoorClosed) {
            frontDoorAnimatronicTollerance = 1.3f;
        }
        else if(animatronicAtFrontDoor && frontDoorAnimatronicTollerance > 0) {
            frontDoorAnimatronicTollerance = frontDoorAnimatronicTollerance - Time.deltaTime;
        }
        else if(animatronicAtFrontDoor && frontDoorAnimatronicTollerance <= 0 && !frontDoorClosed) {
            gameOver = true;
            gameOverText.SetActive(true);
        }
        else if(!animatronicAtFrontDoor) {
            frontDoorAnimatronicTollerance = frontDoorAnimatronicTolleranceReset;
        }

        if(animatronicAtLeftDoor && leftDoorAnimatronicTollerance <= 1.3f && leftDoorClosed) {
           leftDoorAnimatronicTollerance = 1.3f; 
        }
        else if(animatronicAtLeftDoor && leftDoorAnimatronicTollerance > 0) {
            leftDoorAnimatronicTollerance = leftDoorAnimatronicTollerance - Time.deltaTime;
        }
        else if(animatronicAtLeftDoor && leftDoorAnimatronicTollerance <= 0 && !leftDoorClosed) {
            gameOver = true;
            gameOverText.SetActive(true);
        }
        else if(!animatronicAtLeftDoor) {
            leftDoorAnimatronicTollerance = leftDoorAnimatronicTolleranceReset;
        }

    }

    public void toggleFrontDoor() {
        frontDoorClosed = !frontDoorClosed;
    }

    public void toggleLeftDoor() {
        leftDoorClosed = !leftDoorClosed;
    }

    public void setAnimatronicAtFrontDoor(bool x) {
        animatronicAtFrontDoor = x;
    }

    public void setAnimatronicAtLeftDoor(bool x) {
        animatronicAtLeftDoor = x;
    }

    public bool isAnimatronicAtFrontDoor() {
        return animatronicAtFrontDoor;
    }

    public bool isAnimatronicAtLeftDoor() {
        return animatronicAtLeftDoor;
    }
}
