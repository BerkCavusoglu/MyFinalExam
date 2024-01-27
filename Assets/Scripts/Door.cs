using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject anahtarVar;
    [SerializeField] private GameObject kapiAcik;
    [SerializeField] private AudioSource kapiKilitliSes;
    [SerializeField] private AudioSource kapiAcikSes;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && anahtarVar.activeSelf == true)
        {
            kapiAcik.SetActive(true);
            other.gameObject.SetActive(false); // Disable door object
            kapiAcikSes.Play();
            GameManager.Instance.LevelComplete(); // Call the LevelComplete function in the GameManager
        }
        else if (other.gameObject.tag == "Player" && anahtarVar.activeSelf == false)
        {
            kapiKilitliSes.Play();
        }
    }
}
