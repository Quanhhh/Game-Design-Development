using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");  // Đảm bảo Scene chính của bạn được đặt tên chính xác trong Build Settings
    }
}
