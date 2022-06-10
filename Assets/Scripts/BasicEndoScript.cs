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

    public int currentNode = 0; // What is the node the animatronic is currently at
    public float startingX; // Starting X position of the animatronic
    public float startingY; // Starting Y position of the animatronic
    public float startingZ; // Starting Z position of the animatronic


    void Start() {
        delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the animatronics first move
    }

    void FixedUpdate() {
        if(delay <= 0) { // Check to see if the animatronic should move again
            delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the next move
            if(currentNode < nodes.Length - 1) { // Check to see if the animatronic is at the final node
                currentNode++; // Sets its current target node
            }
            else { // Resets the animatronic back to where it started if it is at the final node
                currentNode = 0;
                delay = Random.Range(delayMin, delayMax + 1);
                transform.position = new Vector3(startingX, startingY, startingZ);
            }
        }
        else if(delay > 0) { // Controlles the count down on moves
            delay -= 0.02f; 
        }
    }


    void Update() {

    }
}
