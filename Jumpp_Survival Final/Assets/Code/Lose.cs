using UnityEngine;
using UnityEngine.SceneManagement;
public class Lose : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(LivesCounter.currentSceneName);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
