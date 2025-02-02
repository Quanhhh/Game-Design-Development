using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour
{
    public static LivesCounter instance;
    public static string currentSceneName = "";
    float livessCounterWidth = 73.0f;
    private RectTransform rectTransform;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        rectTransform = GetComponent<RectTransform>();
        AdjustLivesCounter(3);
    }

    public void AdjustLivesCounter(int currentLives)
    {
        rectTransform.sizeDelta = new Vector2(livessCounterWidth * currentLives, rectTransform.sizeDelta.y);

        if (currentLives <= 0)
        {
            currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(6);
        }
    }
}
