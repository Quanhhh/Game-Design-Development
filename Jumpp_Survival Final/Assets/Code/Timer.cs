using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private static Timer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Sửa lại tên phương thức
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (GameManager.Instance.IsCounting)
        {
            GameManager.Instance.SurviveTime += Time.deltaTime;

            int minutes = (int)(GameManager.Instance.SurviveTime / 60);
            int seconds = (int)(GameManager.Instance.SurviveTime % 60);

            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    public void StopTimer()
    {
        GameManager.Instance.IsCounting = false;
    }

    public void StartNewGame()
    {
        GameManager.Instance.ResetSurviveTime(); // Gọi phương thức reset khi bắt đầu game mới
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject timerTextObject = GameObject.FindGameObjectWithTag("TimerText");
        if (timerTextObject != null)
        {
            timerText = timerTextObject.GetComponent<TextMeshProUGUI>();
            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", (int)(GameManager.Instance.SurviveTime / 60), (int)(GameManager.Instance.SurviveTime % 60));
            }
        }

        string sceneName = scene.name;
        if (sceneName == "Menu")
        {
            GameManager.Instance.ResetSurviveTime(); // Reset thời gian nếu đến các Scene này
        }
    }
}
