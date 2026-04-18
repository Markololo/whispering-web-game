using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitTrigger : MonoBehaviour
{
    public string nextSceneName = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // SceneManager.LoadScene(nextSceneName);
            int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentSceneIdx + 1);
        }
    }
}