using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    public List<GameObject> playerObject;
    public bool isWaitForPlayer1 = true;
    public bool isWaitForPlayer2 = false;
    public GameObject NewTrapBotton;
    public GameObject endTurnBotton;
    public bool OneisDie = false;

    private Playermovement1 P1Script;
    private Playermovement2 P2Script;

    public GameObject firstTurn;

    public GameObject P1turn;
    public GameObject P2turn;

    public GameObject P1Canvas;
    public GameObject P2Canvas;

    private GameObject[] checkTurn;

    public bool ChangetoP1 = false;
    public bool ChangetoP2 = false;
    private Scene scene;
    private bool Over;
    public GameObject GoalObject;
    private bool dieonekey = false;
    // Start is called before the first frame update
    void Start()
    {
        Over = false;
        scene = SceneManager.GetActiveScene();
        P1Script = GameObject.Find("P1").GetComponent<Playermovement1>();
        P2Script = GameObject.Find("P2").GetComponent<Playermovement2>();
        if (scene.name != "help3" && scene.name!="help4" && scene.name!="help7") {
            firstTurn.SetActive(true);
        }

        
        StartCoroutine(FistCanvas());
        StartCoroutine("WaitturnShow");
    }

    IEnumerator FistCanvas() {
        yield return new WaitForSeconds(1.0f);
        P1Canvas.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        checkTurn = GameObject.FindGameObjectsWithTag("TempTurn");


        if (OneisDie == true) {
            OneDie();
        }

        if (playerObject[0] == null && playerObject[1] == null && GoalObject.GetComponent<GoalTrigger>().twowin == 0 &&Over==false) 
        {
            Over = true;
            GamingManager.sharedInstance.GameOver(false);

        }

        if (playerObject[0] == null && playerObject[1] == null && GoalObject.GetComponent<GoalTrigger>().twowin == 1)
        {
            if (GoalObject.GetComponent<GoalTrigger>().P1finsih == true) {
                ScoreCounting1.gamesocre1 += 2000;
                GoalObject.GetComponent<GoalTrigger>().P1finsih = false;
            }
            if (GoalObject.GetComponent<GoalTrigger>().P2finish == true) {
                ScoreCounting2.gamesocre2 += 2000;
                GoalObject.GetComponent<GoalTrigger>().P2finish = false;
            }
            GamingManager.sharedInstance.GameOver(true);
        }

        if (checkTurn.Length != 0)
        {
            if (playerObject[0] != null)
            {
                playerObject[0].GetComponent<Playermovement1>().enabled = false;
            }
            if (playerObject[1] != null)
            {
                playerObject[1].GetComponent<Playermovement2>().enabled = false;
            }
        }
        else {
            if (playerObject[0] != null)
            {
                playerObject[0].GetComponent<Playermovement1>().enabled = true;
            }
            if (playerObject[1] != null)
            {
                playerObject[1].GetComponent<Playermovement2>().enabled = true;
            }

        }

        //如果P1回合获取PTrap的所有子物体，把Meshrender勾掉
        if (isWaitForPlayer1 == true) {
            GameObject[] P1Traps = GameObject.FindGameObjectsWithTag("P1Enemy");
            GameObject[] P2Traps = GameObject.FindGameObjectsWithTag("P2Enemy");
            GameObject[] FakeTraps = GameObject.FindGameObjectsWithTag("FakeEnemy");
            for (int i = 0; i < P1Traps.Length; i++) {
                P1Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = true;        
            }
            for (int i = 0; i < P2Traps.Length; i++) {
                P2Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < FakeTraps.Length; i++)
            {
                FakeTraps[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }

        if (isWaitForPlayer2 == true)
        {
            GameObject[] P1Traps = GameObject.FindGameObjectsWithTag("P1Enemy");
            GameObject[] P2Traps = GameObject.FindGameObjectsWithTag("P2Enemy");
            GameObject[] FakeTraps = GameObject.FindGameObjectsWithTag("FakeEnemy");
            for (int i = 0; i < P1Traps.Length; i++)
            {
                P1Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < P2Traps.Length; i++)
            {
                P2Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            for (int i = 0; i < FakeTraps.Length; i++)
            {
                FakeTraps[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }
        if (dieonekey==false) {
            //需要加一个判断
            if (playerObject[0] == null && ChangetoP2 == true && isWaitForPlayer1 == false && isWaitForPlayer2 == false && ChangetoP1 == false)
            {
                StartCoroutine(wP2());
                dieonekey = true;
            }

            if (playerObject[1] == null && ChangetoP1 == true && isWaitForPlayer1 == false && isWaitForPlayer2 == false && ChangetoP2 == false)
            {
                StartCoroutine(wP1());
                dieonekey = true;
            }

            
        }

    }

    IEnumerator wP2() {
        yield return new WaitForSeconds(1.5f);
        isWaitForPlayer2 = true;
    }

    IEnumerator wP1()
    {
        yield return new WaitForSeconds(1.5f);
        isWaitForPlayer1 = true;
    }

    IEnumerator WaitturnShow()
    {
        yield return new WaitForSeconds(1.0f);
        firstTurn.SetActive(false);
        endTurnBotton.SetActive(true);
        NewTrapBotton.SetActive(true);
        P1turn.SetActive(false);
        P2turn.SetActive(false);
    }

    public void OneDie() {
        if (playerObject[0] == null && playerObject[1] != null)
        {
            P1Canvas.SetActive(false);
            P2Canvas.SetActive(true);
            isWaitForPlayer1 = false;
            P2turn.SetActive(true);
            StartCoroutine("WaitturnShow");
        }
        if (playerObject[1] == null && playerObject[0] != null)
        {
            P1Canvas.SetActive(true);
            P2Canvas.SetActive(false);
            isWaitForPlayer2 = false;
            P1turn.SetActive(true);
            StartCoroutine("WaitturnShow");

        }

        OneisDie = false;

    }


}
