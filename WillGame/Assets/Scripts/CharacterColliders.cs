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

    public static bool level1complete = false;
    public static bool level2complete = false;
    public static bool level3complete = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);

        button.onClick.AddListener(StartButtonClick);

        PlayerController.playerMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("rjog;wregw");
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

            //button.enabled = false;

            dialogText.text = "HEY KAI! we are in trouble and we need your help!\n" +
                "The reef has come under threat.Our habitats and sea friends have fallen\n" +
                "victim to oil spillage, ocean acidification, waste pollution and overfishing.\n" +
                "The reef needs you to help restore pride to our landmark and bring back the\n" +
                "fight that we have fell victim to for a long time now!";

            StartCoroutine(Level1Wait());


            if (SceneManager.GetActiveScene().name == "Level1")
            {
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

                //button.enabled = false;

                dialogText.text = "Hey KAI! I am Nerio the sea horse, as you can see our reef is in a state\n" +
                    "of panic and we are counting on you to help save us from turmoil\n" +
                    "and extinction.\n" +
                    "This part of the reef is covered in plastic and waste and we need your\n" +
                    "help to remove it.Watch out for any threats and dangers you might find here.";
            }
            else
            {
                PlayerController.playerMovement = false;
                canvas.SetActive(true);
                characterImage.sprite = images[1];
                characterText.text = "Nerio";
                dialogText.text = "Go find the shrimp first";
            }

            if (SceneManager.GetActiveScene().name == "Level2")
            {
                dialogText.text = "You finished the task. Well Done";
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

                //button.enabled = false;

                dialogText.text = "KAI! I am glad you are here: \nI am sure Nerio has told you about our reef coming under threat.\n" +
                    "The sharks have been caught up in plastic packets.\n" +
                    "We need your help to set them free and remove the toxins.\n " +
                    "The humans have overdone it and are wreaking havoc amongst the seas,\n" +
                    "our reefs are no longer landmarks and are covered in trash.\n" +
                    "We need your help to save and protect it.";

                StartCoroutine(Wait());

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
                dialogText.text = "Well done on making a start to clean up our ocean.";
            }
            else if(!Level3Colour.gameOver && SceneManager.GetActiveScene().name == "Level3")
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(15);
        dialogText.text = "We need you to colour in 20 pieces of coral by appraoching the coral \nand clicking on it,\n" +
            "we need you to clear 15 pieces of trash.\n" +
            "Finally we need you to clear the rocks and trash around Hali to save her";
        button.enabled = true;
    }

    IEnumerator Level1Wait()
    {
        yield return new WaitForSeconds(15);
        dialogText.text = "We need you to find the boulders and move them to get the water moving again\n" +
            "While you are looking for this try clicking on floating plastic to destroy it";
        button.enabled = true;
    }
}
