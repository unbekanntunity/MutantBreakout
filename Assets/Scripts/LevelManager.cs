using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GathdarScene1");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
