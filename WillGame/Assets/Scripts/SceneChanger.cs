using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //public Button play;
    //public Button settings;
    //public Button levels;

    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "StartMenu")
        {
            buttons = gameObject.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(PlayScene);
            buttons[1].onClick.AddListener(SettingScene);
            buttons[2].onClick.AddListener(LevelsScene);
        }

        if(SceneManager.GetActiveScene().name == "Settings")
        {
            buttons = gameObject.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(Back);
        }

        if (SceneManager.GetActiveScene().name == "Levels")
        {
            buttons = gameObject.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(Back);

            buttons[1].onClick.AddListener(() => { LoadLevel(1); });
            buttons[2].onClick.AddListener(() => { LoadLevel(2); });
            buttons[3].onClick.AddListener(() => { LoadLevel(3); });
            buttons[4].onClick.AddListener(() => { LoadLevel(4); });
        }
    }

    void PlayScene()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Level1");
    }
    void SettingScene()
    {
        SceneManager.LoadScene("Settings");
    }
    void LevelsScene()
    {
        Debug.Log("Level");
        SceneManager.LoadScene("Levels");
    }
    void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void LoadLevel(int level)
    {
        switch (level)
        {
            case 1:
                Debug.Log("Load Level 1");
                break;

            case 2:
                Debug.Log("Load Level 2");
                break;

            case 3:
                Debug.Log("Load Level 3");
                break;

            case 4:
                Debug.Log("Load Level 4");
                break;
        }
        

    }
}
