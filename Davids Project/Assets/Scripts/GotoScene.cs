using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    public GameObject player;

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerControl>().PauseWasClicked();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
