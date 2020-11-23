using UnityEngine;
using UnityEngine.UI;

public class Level3Colour : MonoBehaviour
{
    GameObject g;
    GameObject trashPiece;
    public Color[] colour = new Color[5];
    int count = 0;
    int trash = 0;
    public static bool gameOver = false;

    public Image coral;
    public Image flask;

    public Sprite done;

    public Text counter;

    bool trashCounter = false;
    bool coralCounter = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && g != null)
        {
            g.GetComponent<Renderer>().material.color = colour[Random.Range(0,4)];
            Destroy(trashPiece);

            if (count < 20 && coralCounter)
            {
                count++;
            }

            if(trash < 15 && trashCounter)
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

            if (count == 20 && trash == 15)
            {             
                gameOver = true;
            }
            coralCounter = false;
            trashCounter = false;
            counter.text = count + "/20\n" +trash+"/15";
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
    }

    
}
