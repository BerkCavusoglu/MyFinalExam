using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private Player player; // Reference to the Player object
    private Vector3 offset; // Starting distance between camera and character

    void Start()
    {
        // Find the Player object and get the reference
        player = FindObjectOfType<Player>();

        // Calculate the initial distance between camera and character
        if (player != null)
        {
            offset = transform.position - player.transform.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Track the character's position
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * player.moveSpeed);
        }
        else
        {
            Debug.LogWarning("Player nesnesi bulunamadý.");
        }
    }
}
