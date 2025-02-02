using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public GameObject character1Prefab;
    public GameObject character2Prefab;

    public void SelectCharacter1()
    {
        PlayerPrefs.SetString("SelectedCharacter", "nam");
        LoadMapScene();
    }

    public void SelectCharacter2()
    {
        PlayerPrefs.SetString("SelectedCharacter", "nu");
        LoadMapScene();
    }

    private void LoadMapScene()
    {
        SceneManager.LoadScene("Map 1");
    }
}