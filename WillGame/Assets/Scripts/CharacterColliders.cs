using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterColliders : MonoBehaviour
{
    public GameObject canvas;
    public Image characterImage;
    public Sprite[] images = new Sprite[3];
    public Text characterText;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        if (col.tag == "Seahorse")
        {
            col.transform.LookAt(gameObject.transform.position);
            Debug.Log("Seahorse");
            PlayerController.playerMovement = false;
            canvas.SetActive(true);
            characterImage.sprite = images[1];
            characterText.text = "Nerio";
        }

        if (col.tag == "Shark")
        {
            Debug.Log("Shark");
            PlayerController.playerMovement = false;
            canvas.SetActive(true);
            characterImage.sprite = images[2];
            characterText.text = "Sirius";
        }
    }

    void OnTriggerExit(Collider col)
    {
        PlayerController.playerMovement = true;
        canvas.SetActive(false);
    }
}
