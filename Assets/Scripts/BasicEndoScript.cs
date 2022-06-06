using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEndoScript : MonoBehaviour {
    public Transform[] nodes;
    public float delayMax = 15f;
    public float delayMin = 10f;
    float delay;
    bool isAtNode = false;
    public int currentNode = 0;
    float movementSpeed = 10f;
    float xDirection;
    float zDirection;
    bool isFacingCurrentNode = false;
    public float startingX;
    public float startingY;
    public float startingZ;
    int numberOfNodes = 10;
    public float rotationSpeed = 10f;
    float rotationDirection = 1f;
    public float rotationDirectionRef;

    public float currentRotation;


    void Start() {
        delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the animatronics first move
    }

    void FixedUpdate() {
        if(delay <= 0 && isAtNode) { // Check to see if the animatronic is at its destination
            delay = Random.Range(delayMin, delayMax + 1); // Set the delay for the next move
            if(currentNode < numberOfNodes - 1) { // Check to see if the animatronic is at the final node
                currentNode++; // Sets its current target node
            }
            else { // Resets the animatronic back to where it started
                currentNode = 0;
                delay = Random.Range(delayMin, delayMax + 1);
                transform.position = new Vector3(startingX, startingY, startingZ);
            }
            isAtNode = false;
        }
        else if(delay > 0) { // Controlles the count down on moves
            delay -= 0.02f; 
        }
    }


    void Update() {
        if(delay <= 0 && !isAtNode) {
            // check if it is facing the next node
            Vector3 distanceToTarget = new Vector3(nodes[currentNode].position.x - transform.position.x, 0f, nodes[currentNode].position.z - transform.position.z);
            if(isFacingCurrentNode) {
                transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
            }
            else {
                // rotate towards next node
                // how to get an obj rotation
                currentRotation = transform.localRotation.eulerAngles.y;

                Vector2 direction = new Vector2(nodes[currentNode].position.x - transform.position.x, nodes[currentNode].position.z - transform.position.z);
                direction.Normalize();
                Vector2 currentDirection = new Vector2(Mathf.Sin(transform.localRotation.eulerAngles.y * Mathf.Deg2Rad), Mathf.Cos(transform.localRotation.eulerAngles.y * Mathf.Deg2Rad));
                rotationDirectionRef = Vector3.Cross(direction, currentDirection).z;
                if(rotationDirectionRef <= 0.009f && rotationDirectionRef >= 0.001f && direction.x < currentDirection.x + 0.2f && direction.x > currentDirection.x - 0.2f && direction.y < currentDirection.y + 0.2f && direction.y > currentDirection.y - 0.2f) {
                    rotationDirection = 0f;
                    isFacingCurrentNode = true;
                }
                else if(rotationDirectionRef >= 0) {
                    rotationDirection = 1f;
                }
                else {
                    rotationDirection = -1f;
                }

                transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y + rotationSpeed*Time.deltaTime*rotationDirection, 0);
            }
            // Checks if the animatronic is at its current target node
            if(transform.position.x < nodes[currentNode].position.x + 0.5f && transform.position.x > nodes[currentNode].position.x - 0.5f) {
                if(transform.position.z < nodes[currentNode].position.z + 0.5f && transform.position.z > nodes[currentNode].position.z - 0.5f) {
                    isAtNode = true;
                    isFacingCurrentNode = false;
                }
            }
        }
    }
}
