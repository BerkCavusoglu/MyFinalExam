using UnityEngine;
using UnityEngine.UI;

public class SettingCharacterSpeed : MonoBehaviour
{
    public Player player; // A reference to access the Player script
    public Slider speedSlider; // The Slider component on the UI to control the character speed

    void Start()
    {
        // Set the initial value of the Slider to match the character's starting speed
        if (player != null && speedSlider != null)
        {
            speedSlider.value = player.moveSpeed;
        }
    }

    // Called when the value of the Slider changes
    public void OnSpeedChange(float newSpeed)
    {
        // If there is access to the Player script and the Slider, update the character's speed
        if (player != null && speedSlider != null)
        {
            player.moveSpeed = newSpeed;
            // Add code here to save the speed value (e.g., PlayerPrefs)
            PlayerPrefs.SetFloat("CharacterSpeed", newSpeed);
        }
    }
}
