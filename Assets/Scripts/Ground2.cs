using UnityEngine;

public class Ground2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the interaction we want is happening with an object tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // When colliding with the "Player" tag, if this object does not have a Rigidbody2D component, add one
            Rigidbody2D platformRigidbody = gameObject.GetComponent<Rigidbody2D>();
            if (platformRigidbody == null)
            {
                // If there is no Rigidbody2D component, add it to the platform to increase gravity
                platformRigidbody = gameObject.AddComponent<Rigidbody2D>();
                platformRigidbody.gravityScale = 1.0f; // For example, set gravity to 1.0f
            }
            // Additionally, increase gravity using the Rigidbody2D component attached to the player
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.gravityScale = 1.0f; // For example, set gravity to 1.0f
            }
        }
    }
}
