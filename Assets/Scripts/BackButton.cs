using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Operations to be executed when the back button is clicked
    public void GeriDon()
    {
        SceneManager.LoadScene("Giris"); // Return to the scene named "Giris" (Entry)
    }
}
