using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterColliders : MonoBehaviour
{
    public GameObject canvas;
    public Image characterImage; //sprite for character
    public Sprite[] images = new Sprite[3];
    public Text characterText; //character name
    public Text dialogText; //dialog text in main box

    public Button button;
    public Button startButton;

    public GameObject[] buttons = new GameObject[2];

    public static bool level1complete = false;
    public static bool level2complete = false;
    public static bool level3complete = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        buttons[0].SetActive(true);
        buttons[1].SetActive(false);

        button.onClick.AddListener(ButtonClick);
        startButton.onClick.AddListener(StartButtonClick);

        PlayerController.playerMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ButtonClick()
    {

        if (characterText.text == "Maron")
        {
            dialogText.text = "Come find me when you're done.";
        }
        if (characterText.text == "Nerio")
        {
            dialogText.text = "Add dialog and load scene";
        }
        if (characterText.text == "Sirius")
        {
            canvas.SetActive(false);
            //dialogText.text = "Add dialog and load scene";
        }

        buttons[0].SetActive(false);
        buttons[1].SetActive(true);
    }

    void StartButtonClick()
    {
        //Debug.LogError("Add code to change to other scenes");

        if(characterText.text == "Maron" && SceneManager.GetActiveScene().name == "MainWorld")
        {
            SceneManager.LoadScene("Level1");
        }
        if (characterText.text == "Maron" && SceneManager.GetActiveScene().name == "Level1")
        {
            level1complete = true;
            SceneManager.LoadScene("MainWorld");
        }

        if (characterText.text == "Nerio" && SceneManager.GetActiveScene().name == "MainWorld")
        {
            SceneManager.LoadScene("Level2");
        }
        if (characterText.text == "Nerio" && SceneManager.GetActiveScene().name == "Level2")
        {
            level2complete = true;
            SceneManager.LoadScene("MainWorld");
        }


        if (characterText.text == "Sirius" && SceneManager.GetActiveScene().name == "MainWorld")
        {
            SceneManager.LoadScene("Level3");
        }
        if (characterText.text == "Sirius" && SceneManager.GetActiveScene().name == "Level3" && Level3Colour.gameOver)
        {
            level3complete = true;
            SceneManager.LoadScene("MainWorld");
        }
        else
        {
            canvas.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if(col.tag == "Shrimp")
        {
            //col.transform.LookAt(gameObject.transform.position);
            //col.transform.Rotate(-180, 0, 0);
            Debug.Log("Shrimp");
            PlayerController.playerMovement = false;
            canvas.SetActive(true);
            characterImage.sprite = images[0];
            characterText.text = "Maron";

            dialogText.text = "Hi! My name is Maron... Add more";

            if(SceneManager.GetActiveScene().name == "Level1")
            {
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                dialogText.text = "You finished the task. Well Done";
            }
        }

        if (col.tag == "Seahorse")
        {
            if (level1complete)
            {
                //col.transform.LookAt(gameObject.transform.position);
                Debug.Log("Seahorse");
                PlayerController.playerMovement = false;
                canvas.SetActive(true);
                characterImage.sprite = images[1];
                characterText.text = "Nerio";

                dialogText.text = "Hi! My name is Nerio... Add more";
            }
            else
            {
                PlayerController.playerMovement = false;
                canvas.SetActive(true);
                characterImage.sprite = images[1];
                characterText.text = "Nerio";
                dialogText.text = "Go find the shrimp first";
            }
        }

        if (col.tag == "Shark")
        {
            if (level2complete)
            {
                Debug.Log("Shark");
                PlayerController.playerMovement = false;
                canvas.SetActive(true);
                characterImage.sprite = images[2];
                characterText.text = "Sirius";

                dialogText.text = "Hi! My name is Sirius... Add more";
            }
            else
            {
                PlayerController.playerMovement = false;
                canvas.SetActive(true);
                characterImage.sprite = images[2];
                characterText.text = "Sirius";
                dialogText.text = "Go find the seahorse";
            }

            if (SceneManager.GetActiveScene().name == "Level3" && Level3Colour.gameOver)
            {
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                dialogText.text = "The reef has been cleaned. Well done";
            }
            else if(!Level3Colour.gameOver)
            {
                dialogText.text = "You need to cleaen up the reef. Come back when you're done.";
            }

        }

    }

    void OnTriggerExit(Collider col)
    {
        PlayerController.playerMovement = true;
        canvas.SetActive(false);
    }
}
