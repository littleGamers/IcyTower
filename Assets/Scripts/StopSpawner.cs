using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  This script is used to identify the spawner with edge collider and stop it from spawning steps.
 *  It is used with a collider placed near the finish line.
 *  The finish line will stay the last step.
 */
public class StopSpawner : MonoBehaviour
{
    // Tag used for the desired spawner:
    [SerializeField] string triggeringTag;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            Destroy(other.gameObject);
        }
    }

}
