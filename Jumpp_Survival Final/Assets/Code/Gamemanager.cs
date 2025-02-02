using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public float SurviveTime { get; set; }
    public bool IsCounting { get; set; } = true;

    // Thêm phương thức reset
    public void ResetSurviveTime()
    {
        SurviveTime = 0;
        IsCounting = true;
    }
}
