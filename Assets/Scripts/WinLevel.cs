using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    // Tag used for the desired player:
    [SerializeField] string triggeringTag;

    // Next level scene name:
    [SerializeField] string nextScene;

    // Used to check if level finished successfully:
    bool finishLevelListener = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggeringTag)
        {
            // Disable player's controller:
            collision.GetComponent<KeyboardForce>().enabled = false;

            // Display the "You Win!" text messages and instructions:
            GameObject.FindGameObjectWithTag("WinText").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("NextLevelText").GetComponent<MeshRenderer>().enabled = true;

            finishLevelListener = true;
        }
    }
    void Update()
    {
        // If we won the game and pressed LCTRL, we'll start the next level:
        if (finishLevelListener && Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
