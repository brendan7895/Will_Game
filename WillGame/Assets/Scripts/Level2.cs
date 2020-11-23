using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    public GameObject paused;

    public Button btnUnpause;
    public Button btnLevelMenu;
    public Button btnMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        paused.SetActive(false);

        Time.timeScale = 1;

        btnUnpause.onClick.AddListener(Unpause);
        btnLevelMenu.onClick.AddListener(LevelSelect);
        btnMainMenu.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        paused.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        paused.SetActive(false);
    }

    public void LevelSelect()
    {

        Debug.Log("Load Level Menu");
        SceneManager.LoadScene("Levels");
    }

    public void MainMenu()
    {
        Debug.Log("Load Main Menu");
        SceneManager.LoadScene("StartMenu");
    }
}
