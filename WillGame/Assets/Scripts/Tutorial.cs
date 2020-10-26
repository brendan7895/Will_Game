using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject movement;
    public GameObject dodge;
    public GameObject interact;
    public GameObject boost;
    public GameObject attack;
    public GameObject tutorialDone;

    public GameObject player;
    public GameObject character;
    public GameObject shark;

    public Button btnCloseMovement;
    public Button btnCloseDodge;
    public Button btnCloseInteract;
    public Button btnCloseBoost;
    public Button btnCloseAttack;
    public Button btnCloseTutorial;

    private bool movementComplete = false;
    private bool dodgeComplete = false;
    private bool interactComplete = false;
    private bool boostComplete = false;
    private bool attackComplete = false;

    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        movement.SetActive(true);
        dodge.SetActive(false);
        interact.SetActive(false);
        character.SetActive(false);
        boost.SetActive(false);
        attack.SetActive(false);
        shark.SetActive(false);
        tutorialDone.SetActive(false);

        movementComplete = false;

        Time.timeScale = 0;

        btnCloseMovement.onClick.AddListener(CloseMovement);
        btnCloseDodge.onClick.AddListener(CloseDodge);
        btnCloseInteract.onClick.AddListener(CloseInteract);
        btnCloseBoost.onClick.AddListener(CloseBoost);
        btnCloseAttack.onClick.AddListener(CloseAttack);
        btnCloseTutorial.onClick.AddListener(CloseTutorial);

        dist = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if(movementComplete == false)
            {
                StartCoroutine(MovementDone());
                movementComplete = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(movementComplete == true && dodgeComplete == false)
            {
                StartCoroutine(DodgeDone());
                dodgeComplete = true;
            }
        }


        if(Vector3.Distance(player.transform.position, character.transform.position) <= 5 )
        {
            if(Input.GetKeyDown(KeyCode.I) && movementComplete == true && dodgeComplete == true)
            {
                StartCoroutine(InteractDone());
                interactComplete = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(movementComplete == true && dodgeComplete == true && interactComplete == true)
            {
                StartCoroutine(BoostDone());
                boostComplete = true;
            }
        }

        if (Vector3.Distance(player.transform.position, shark.transform.position) <= 10)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                if (movementComplete == true && dodgeComplete == true && interactComplete == true && boostComplete == true)
                {
                    StartCoroutine(AttackDone());
                    attackComplete = true;
                }
            }
        }
           
        Debug.Log($"Current position x of player: {player.transform.position.x}");

    }

    public void CloseMovement()
    {
        movement.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseDodge()
    {
        dodge.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseInteract()
    {
        interact.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseBoost()
    {
        boost.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseAttack()
    {
        attack.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseTutorial()
    {
        tutorialDone.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator MovementDone()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;

        dodge.SetActive(true);
    }

    IEnumerator DodgeDone()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;

        character.SetActive(true);
        interact.SetActive(true);
        character.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z + 20);
    }

    IEnumerator InteractDone()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;

        character.SetActive(false);

        boost.SetActive(true);
    }

    IEnumerator BoostDone()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;

        attack.SetActive(true);
        shark.SetActive(true);
        shark.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z + 20);
    }

    IEnumerator AttackDone()
    {
        shark.SetActive(false);
        yield return new WaitForSeconds(2.5f);

        Time.timeScale = 0;

        tutorialDone.SetActive(true);
    }
}
