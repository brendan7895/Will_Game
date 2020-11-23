using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        buttons[0].SetActive(true);
        buttons[1].SetActive(false);

        button.onClick.AddListener(ButtonClick);
        startButton.onClick.AddListener(StartButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ButtonClick()
    {

        if (characterText.text == "Maron")
        {
            dialogText.text = "Add dialog and load scene";
        }
        if (characterText.text == "Nerio")
        {
            dialogText.text = "Add dialog and load scene";
        }
        if (characterText.text == "Sirius")
        {
            dialogText.text = "Add dialog and load scene";
        }

        buttons[0].SetActive(false);
        buttons[1].SetActive(true);
    }

    void StartButtonClick()
    {
        Debug.LogError("Add code to change to other scenes");

       
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
        }

        if (col.tag == "Seahorse")
        {
            col.transform.LookAt(gameObject.transform.position);
            Debug.Log("Seahorse");
            PlayerController.playerMovement = false;
            canvas.SetActive(true);
            characterImage.sprite = images[1];
            characterText.text = "Nerio";

            dialogText.text = "Hi! My name is Nerio... Add more";
        }

        if (col.tag == "Shark")
        {
            Debug.Log("Shark");
            PlayerController.playerMovement = false;
            canvas.SetActive(true);
            characterImage.sprite = images[2];
            characterText.text = "Sirius";

            dialogText.text = "Hi! My name is Sirius... Add more";
        }

    }

    void OnTriggerExit(Collider col)
    {
        PlayerController.playerMovement = true;
        canvas.SetActive(false);
    }
}
