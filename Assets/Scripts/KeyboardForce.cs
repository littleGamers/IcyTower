using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(TouchDetector))]
public class KeyboardForce : MonoBehaviour
{
    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] float walkForce;

    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse;

    private Rigidbody2D rb;
    private TouchDetector td;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        td = GetComponent<TouchDetector>();
    }

    // Define force modes for actions:
    private ForceMode2D walkForceMode = ForceMode2D.Force;
    private ForceMode2D jumpForceMode = ForceMode2D.Impulse;
    private bool playerWantsToJump = false;

    private void Update()
    {
        // Keyboard events are tested each frame, so we should check them here.

        // Check if SPACE is pressed and if the player is standing on the ground.
        if (Input.GetKeyDown(KeyCode.Space) && td.IsTouching())
        {
            playerWantsToJump = true;
        }
    }

    private void FixedUpdate()
    {
        // Walk right and left if desired:
        // Horizontal used to get the correct direction on the x-axis - right:1, left:-1

        float horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector3(horizontal * walkForce, 0, 0), walkForceMode);

        // Jump if the flag is true (According to the conditions in Update():
        if (playerWantsToJump)
        {
            rb.AddForce(new Vector3(0, jumpImpulse, 0), jumpForceMode);
            playerWantsToJump = false;
        }

    }
}

