using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    bool playerPressedEsc = false;
    [SerializeField] GameObject pauseMenu;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerPressedEsc = true;
        }
    }

    private void FixedUpdate()
    {
        if(playerPressedEsc)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        playerPressedEsc = false;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        playerPressedEsc = false;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
