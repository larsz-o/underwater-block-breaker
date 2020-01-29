using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // find out current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // load the next one
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
