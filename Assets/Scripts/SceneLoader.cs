using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                FreezeTime(false);
            }
            else
            {
                pauseMenu.SetActive(true);
                FreezeTime(true);
            }
        }
    }

    // carrega uma Scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // fecha o jogo
    public void QuitGame()
    {
        Application.Quit();
    }

    // pausa e despausa o jogo
    public void FreezeTime(bool isFrozen)
    {
        if (isFrozen)
        {
            isPaused = true;
            Time.timeScale = 0;

        } 
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    // reinicia o level
    public void RestartLevel()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    // passa pro próximo level
    public void NextLevel()
    {
        int totalLevels = SceneManager.sceneCountInBuildSettings;
        int nextLevelIndex = (SceneManager.GetActiveScene().buildIndex) + 1;
        
        if (nextLevelIndex < totalLevels)
        {
            SceneManager.LoadScene(nextLevelIndex);
        } else
        {
            SceneManager.LoadScene(0);
        }
    }
}
