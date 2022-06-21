/*
    This script is the basic foundation for animatronic movement.
    This script is just mostly just for testing and to try out different ways of doing movement
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEndoScript : MonoBehaviour {
    public GameObject[] nodes; // Used to store all of the nodes that the animatronic will move towards
    public float delayMax = 15f; // Maximum delay in seconds between movements
    public float delayMin = 10f; // Minimum delay in seconds between movements
    float delay; // Current time in seconds until next movement
    public GameController gameController;

    public int nextNode = 0; // The next node the animatronic will move to

    void Start() {
        delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the animatronics first move
    }

    void FixedUpdate() {
        if(delay <= 0) { // Check to see if the animatronic should move again
            delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the next move
            if(nextNode < nodes.Length) { // Check to see if the animatronic is at the final node
                if(nextNode == nodes.Length - 1) {
                    if(nodes[nextNode].GetComponent<NodeScript>().isLeftDoorNode) {
                        gameController.setAnimatronicAtLeftDoor(true);
                    }
                    else {
                        gameController.setAnimatronicAtFrontDoor(true);
                    }
                }
                transform.position = new Vector3(nodes[nextNode].transform.position.x, nodes[nextNode].transform.position.y, nodes[nextNode].transform.position.z); // Moves to the next node
                transform.rotation = Quaternion.Euler(nodes[nextNode].transform.eulerAngles.x, nodes[nextNode].transform.eulerAngles.y, nodes[nextNode].transform.eulerAngles.z); // Changes rotation to match the next node
                nextNode++; // Sets its current target node
            }
            else { // Resets the animatronic back to where it started if it is at the final node
                nextNode = 0;
                delay = Random.Range(delayMin, delayMax + 1);
                transform.position = new Vector3(nodes[0].transform.position.x, nodes[0].transform.position.y, nodes[0].transform.position.z); // Resets the animatronic back to its start position
                transform.rotation = Quaternion.Euler(nodes[0].transform.eulerAngles.x, nodes[0].transform.eulerAngles.y, nodes[0].transform.eulerAngles.z); // Resets the animatronic to its start rotation
                if(nodes[nodes.Length - 1].GetComponent<NodeScript>().isLeftDoorNode) {
                    gameController.setAnimatronicAtLeftDoor(false);
                }
                else {
                    gameController.setAnimatronicAtFrontDoor(false);
                }
            }
        }
        else if(delay > 0) { // Controlles the count down on moves
            delay -= 0.02f; 
        }
    }
}
