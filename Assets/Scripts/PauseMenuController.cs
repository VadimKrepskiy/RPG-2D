using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void Resume()
    {
        transform.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        transform.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void MainMenu()
    {
        transform.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
