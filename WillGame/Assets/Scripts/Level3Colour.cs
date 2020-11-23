using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Level3Colour : MonoBehaviour
{
    GameObject g;
    GameObject trashPiece;
    GameObject rockPiece;

    public GameObject gameOverImage;

    public Color[] colour = new Color[5];
    int count = 0;
    int trash = 0;
    int rock = 0;

    public static bool gameOver = false; // final game over call

    public Image coral;
    public Image flask;
    public Image rockImg;

    public Sprite done;

    public Text counter;

    bool trashCounter = false;
    bool coralCounter = false;
    bool rockCounter = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && g != null)
        {
            g.GetComponent<Renderer>().material.color = colour[Random.Range(0,4)];
            Destroy(trashPiece);
            Destroy(rockPiece);

            if (count < 20 && coralCounter)
            {
                count++;
            }

            if (rock < 12 && rockCounter)
            {
                rock++;
            }

            if (trash < 15 && trashCounter)
            {
                trash++;
                
            }

            if(count == 20)
            {
                coral.sprite = done;
            }
            if (trash == 15)
            {
                flask.sprite = done;
            }
            if(rock == 12)
            {
                rockImg.sprite = done;
            }

            if (count == 20 && trash == 15 && rock == 12)
            {             
                gameOver = true;
                PlayerController.playerMovement = false;
                
            }

            coralCounter = false;
            trashCounter = false;
            rockCounter = false;
            counter.text = count + "/20\n" +trash+"/15\n" + rock + "/12";
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if(col.tag == "Coral")
        {
            //Debug.Log("Hit");
            coralCounter = true;
            g = col.gameObject;
        }
        if(col.tag == "Trash")
        {
            trashCounter = true;
            trashPiece = col.gameObject;           
        }

        if(col.tag == "Boulder")
        {
            rockCounter = true;
            rockPiece = col.gameObject;
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        gameOverImage.SetActive(true);
    }
    
}
