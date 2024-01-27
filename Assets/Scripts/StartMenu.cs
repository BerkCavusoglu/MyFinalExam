
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("Bolum2"); 
    }

    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Unity Editör içinde çalışırken oyunu durdur
#else
        Application.Quit(); 
#endif
    }

    
    public void OpenOptions()
    {
        SceneManager.LoadScene("KarakterAyarlamaSahnesi"); 
    }
    public void GeriDon()
    {
        SceneManager.LoadScene("Giris"); 
    }
}
