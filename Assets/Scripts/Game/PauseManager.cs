using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private bool isPaused;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public string mainMenu;
    public bool usingPausePanel;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            ChangePause();
        }

    }

    private void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            usingPausePanel = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            pausePanel.SetActive(false);
            Time.timeScale = 1f;

        }
    }

    public void Resume()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(false);
            inventoryPanel.SetActive(true);
        }
    }

}
