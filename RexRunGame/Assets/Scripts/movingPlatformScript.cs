using UnityEngine;

public class movingPlatformScript : MonoBehaviour
{
    public float speed = 5f; // Speed of the platform movement
    public Transform targetPosition; // Target position for the platform to stop

    private bool moveUp = false; // Flag to control the movement direction
    private Vector3 initialPosition; // Initial position of the platform
    private bool returning = false; // Flag to indicate whether the platform is returning to its original position

    private void Start()
    {
        // Store the initial position of the platform
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (moveUp)
        {
            if (returning)
            {
                // Move the platform back to the initial position
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);

                // Check if the platform has reached the initial position
                if (transform.position == initialPosition)
                {
                    moveUp = false;
                    returning = false;
                }
            }
            else
            {
                // Move the platform up to the target position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

                // Check if the platform has reached the target position
                if (transform.position == targetPosition.position)
                {
                    moveUp = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.CompareTag("Player"))
        {
            // Parent the player to the platform
            collision.transform.SetParent(transform, true);

            if (moveUp)
            {
                // If the platform is already moving up, it means the player is re-entering the collision trigger after exiting
                // In this case, set the returning flag to true to make the platform move back to the initial position
                returning = true;
            }
            else
            {
                // Set the flag to true to enable upward movement towards the target position
                moveUp = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.CompareTag("Player"))
        {
            // Unparent the player from the platform
            collision.transform.SetParent(null);

            // Set the flag to false to stop upward movement
            moveUp = false;

            // Check if the platform has reached the target position
            if (transform.position == targetPosition.position)
            {
                // Set the returning flag to true to make the platform move back to the initial position
                returning = true;
            }
            else
            {
                // Reset the platform to its initial position
                transform.position = initialPosition;
            }
        }
    }
}
