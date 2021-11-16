using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepLevelSpawner : MonoBehaviour
{

    [SerializeField] PlatformEffector2D prefabToSpawn; // Step prefab

    // Settings for the spawner to spawn steps:
    [SerializeField] float distanceBetweenSteps;
    [SerializeField] float minStepSize;
    [SerializeField] float maxStepSize;

    // Screen boundaries to spawn steps between them:
    private float leftBoundX;
    private float rightBoundX;

    // Next destination point for spawning:
    float nextStepPointY; 

    void Start()
    {
        // Get the left and right boundaries from the bounds objects:
        leftBoundX = GameObject.FindGameObjectWithTag("LeftBound").transform.position.x;
        rightBoundX = GameObject.FindGameObjectWithTag("RightBound").transform.position.x;

        // Initialize next step to be current position:
        nextStepPointY = transform.position.y;
    }

    private void Update()
    {
        float currentSpawnerPointY = transform.position.y;

        // If we reached the next step destination point:
        if (nextStepPointY <= currentSpawnerPointY)
        {
            // Update the next step destination to the next position according to distanceBetweenSteps:
            nextStepPointY = currentSpawnerPointY + distanceBetweenSteps;
            spawnRandomStep();
        }
    }

    private void spawnRandomStep()
    {
        // Create the new object with the prefab on generic location:
        GameObject newStep = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);

        // Calculate the width of the new step randomly and set it.
        // Width value will be between minStepSize to maxStepSize:
        Vector3 scaleOfSpawnedStep = new Vector3(
                            Random.Range(minStepSize, maxStepSize),
                            newStep.transform.localScale.y,
                            newStep.transform.localScale.z);
        newStep.transform.localScale = scaleOfSpawnedStep;

        // Calculate the position of the new step and set it.
        // Position is chosen randomly within right and left bounds.
        // Since the actual position of the step is it's center - we need to calculate the offset from our bounds positions.
        // The offset will be (step width)/2 so that the step's edge will touch the left/right bound.
        BoxCollider2D stepCollider = newStep.GetComponent<BoxCollider2D>();
        float stepOffset = stepCollider.bounds.size.x / 2;

        newStep.transform.position = new Vector3(
                                        Random.Range(leftBoundX + stepOffset, rightBoundX - stepOffset),
                                        transform.position.y,
                                        transform.position.z);
    }

    public float getStepDistance()
    {
        return distanceBetweenSteps;
    }
}

