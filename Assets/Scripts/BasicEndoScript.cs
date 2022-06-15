/*
    This script is the basic foundation for animatronic movement.
    This script is just mostly just for testing and to try out different ways of doing movement
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEndoScript : MonoBehaviour {
    public Transform[] nodes; // Used to store all of the nodes that the animatronic will move towards
    public float delayMax = 15f; // Maximum delay in seconds between movements
    public float delayMin = 10f; // Minimum delay in seconds between movements
    float delay; // Current time in seconds until next movement

    public int nextNode = 0; // The next node the animatronic will move to

    void Start() {
        delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the animatronics first move
    }

    void FixedUpdate() {
        if(delay <= 0) { // Check to see if the animatronic should move again
            delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the next move
            if(nextNode < nodes.Length) { // Check to see if the animatronic is at the final node
                transform.position = new Vector3(nodes[nextNode].position.x, nodes[nextNode].position.y, nodes[nextNode].position.z); // Moves to the next node
                transform.rotation = Quaternion.Euler(nodes[nextNode].eulerAngles.x, nodes[nextNode].eulerAngles.y, nodes[nextNode].eulerAngles.z); // Changes rotation to match the next node
                nextNode++; // Sets its current target node
            }
            else { // Resets the animatronic back to where it started if it is at the final node
                nextNode = 0;
                delay = Random.Range(delayMin, delayMax + 1);
                transform.position = new Vector3(nodes[0].position.x, nodes[0].position.y, nodes[0].position.z); // Resets the animatronic back to its start position
                transform.rotation = Quaternion.Euler(nodes[0].eulerAngles.x, nodes[0].eulerAngles.y, nodes[0].eulerAngles.z); // Resets the animatronic to its start rotation
            }
        }
        else if(delay > 0) { // Controlles the count down on moves
            delay -= 0.02f; 
        }
    }
}
