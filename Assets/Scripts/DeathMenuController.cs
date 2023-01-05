using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public void Pause()
    {
        transform.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void StartOver()
    {
        transform.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
}
