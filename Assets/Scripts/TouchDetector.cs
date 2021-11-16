using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    // Tag used for the ground:
    [SerializeField] string groundTag;
    
    private int touchingColliders = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If player touched the ground - increase touchingColliders:
        if (collision.gameObject.tag == groundTag)
            touchingColliders++;
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If player left the ground - decrease touchingColliders:
        if (collision.gameObject.tag == groundTag)
            touchingColliders--;
    }

    public bool IsTouching()
    {
        // If (touchingColliders > 0) it means we are touching the ground:
        return touchingColliders > 0;
    }
}
