using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    public GameObject[] placeBubbles;
    public GameObject bubble;
    public Transform[] bubbleTransform;

    public GameObject paused;
    public GameObject _levelCounter;
    public GameObject _neriosBrother;

    public Text counter;

    public Button btnUnpause;
    public Button btnLevelMenu;
    public Button btnMainMenu;

    public LayerMask ground;
    Vector3 groundPos;

    public static bool levelFinished { get; set; }
    public static GameObject levelCounter;
    public static GameObject nerioBrother;
    public static int bubblesBlocked { get; set; }
    public static int neriosBrother { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bubblesBlocked = 0;
        neriosBrother = 0;

        nerioBrother = _neriosBrother;
        nerioBrother.SetActive(false);

        levelCounter = _levelCounter;
        levelCounter.SetActive(false);
        paused.SetActive(false);

        Time.timeScale = 1;

        btnUnpause.onClick.AddListener(Unpause);
        btnLevelMenu.onClick.AddListener(LevelSelect);
        btnMainMenu.onClick.AddListener(MainMenu);

        PlaceBubbles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        counter.text = bubblesBlocked + "/5\n" + neriosBrother + "/1\n";

        if(bubblesBlocked == 5 && neriosBrother == 1)
        {
            CharacterColliders.foundEverything = true;
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

    void PlaceBubbles()
    {
        placeBubbles = new GameObject[5];
   
        for (int i = 0; i < 5; i++)
        {
            placeBubbles[i] = bubble;

            Vector3 pos = new Vector3(Random.Range(-100, 100), 4.1f, Random.Range(-100, 100));
            int index = Random.Range(0, 5);
            placeBubbles[i] = Instantiate(bubble, pos, bubble.transform.rotation);

            RaycastHit hit;
            Ray ray = new Ray(placeBubbles[i].transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 20, ground))
            {
                groundPos = new Vector3(
                    placeBubbles[i].transform.position.x,
                    hit.point.y,
                    placeBubbles[i].transform.position.z);

                //Debug.Log(hit.point.y);
                placeBubbles[i].transform.position = groundPos;
            }
        }
    }

    void PlaceNerioBrother()
    {

    }
}
