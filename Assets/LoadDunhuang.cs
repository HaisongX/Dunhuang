using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadDunhuang : MonoBehaviour
{
    public string levelName = "Dunhuang";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}