using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Tag used for the desired player:
    [SerializeField] string triggeringTag;

    // Used for checking if we need to reset the level:
    bool resetGameListener = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == triggeringTag)
        {
            // Disable player's controller:
            collision.GetComponent<KeyboardForce>().enabled = false;

            // Display the "Game Over" text messages and instructions:
            GameObject.FindGameObjectWithTag("GameOverText").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("PlayAgainText").GetComponent<MeshRenderer>().enabled = true;

            resetGameListener = true;
        }
    }
    private void Update()
    {
        // If we lost the game and pressed a key, we'll start over current level:
        if (resetGameListener && Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
