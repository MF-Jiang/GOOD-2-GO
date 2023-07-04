using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnBotton : MonoBehaviour
{
    private PlayerManagement turnScript;
    public GameObject NewTrapBotton;
    public GameObject P1turn;
    public GameObject P2turn;
    public GameObject BlackPanel;
    public GameObject EndTrunBotton;
    public GameObject P1Canvas;
    public GameObject P2Canvas;
    private GameObject[] MovingCubes;
    private GameObject[] P1MovingCubes;
    private GameObject[] P2MovingCubes;
    private GameObject[] Rod2MovingCubes;
    private GameObject[] ThreeMovingCubes;
    // Start is called before the first frame update
    void Start()
    {
        turnScript = GameObject.Find("Player").GetComponent<PlayerManagement>();
        MovingCubes = GameObject.FindGameObjectsWithTag("MovingCube");
        P1MovingCubes = GameObject.FindGameObjectsWithTag("P1MovingCube");
        P2MovingCubes = GameObject.FindGameObjectsWithTag("P2MovingCube");
        Rod2MovingCubes = GameObject.FindGameObjectsWithTag("Rod2MovingCube");
        ThreeMovingCubes = GameObject.FindGameObjectsWithTag("ThreeMovingCube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurn() {
        if ((turnScript.ChangetoP2== true || turnScript.isWaitForPlayer1==true)&&turnScript.playerObject[0]!=null) { //P1回合
            turnScript.ChangetoP2 = false;
            EndTrunBotton.SetActive(false);
            for (int i = 0; i < MovingCubes.Length; i++)
            {
                MovingCubes[i].GetComponent<MovingCube>().MovePosition();
            }
            for (int i = 0; i < P1MovingCubes.Length; i++)
            {
                P1MovingCubes[i].GetComponent<MovingCube>().MovePosition();
            }
            for (int i = 0; i < Rod2MovingCubes.Length; i++)
            {
                Rod2MovingCubes[i].GetComponent<PullRodStyle2Cube>().MovePosition();
            }
            /*for (int i = 0; i < ThreeMovingCubes.Length; i++) {
                ThreeMovingCubes[i].GetComponent<ThreeTypeMovingCube>().MovePosition();
            }*/
            NewTrapBotton.SetActive(false);
            P1Canvas.SetActive(false);
            StartCoroutine("Wait"); 
        }

        if ((turnScript.ChangetoP1 == true || turnScript.isWaitForPlayer2==true)&&turnScript.playerObject[1]!=null) { //P2回合
            turnScript.ChangetoP1 = false;
            EndTrunBotton.SetActive(false);
            for (int i = 0; i < MovingCubes.Length; i++)
            {
                MovingCubes[i].GetComponent<MovingCube>().MovePosition();
            }
            for (int i = 0; i < P2MovingCubes.Length; i++)
            {
                P2MovingCubes[i].GetComponent<MovingCube>().MovePosition();
            }
            for (int i = 0; i < Rod2MovingCubes.Length; i++)
            {
                Rod2MovingCubes[i].GetComponent<PullRodStyle2Cube>().MovePosition();
            }
            if (turnScript.playerObject[0] != null)
            { 
                for (int i = 0; i < ThreeMovingCubes.Length; i++)
                {
                    ThreeMovingCubes[i].GetComponent<ThreeTypeMovingCube>().MovePosition();
                }
            }
            NewTrapBotton.SetActive(false);
            P2Canvas.SetActive(false);
            StartCoroutine("Wait2");
        }
    }


    IEnumerator Wait2()
    {
        turnScript.isWaitForPlayer2 = false;
        yield return new WaitForSeconds(1.0f);

        if (turnScript.playerObject[0] != null)
        {
            NewTrapBotton.SetActive(false);
            GameObject[] P1Traps = GameObject.FindGameObjectsWithTag("P1Enemy");
            GameObject[] P2Traps = GameObject.FindGameObjectsWithTag("P2Enemy");
            GameObject[] FakeTraps = GameObject.FindGameObjectsWithTag("FakeEnemy");
            for (int i = 0; i < P1Traps.Length; i++)
            {
                P1Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < P2Traps.Length; i++)
            {
                P2Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < FakeTraps.Length; i++)
            {
                FakeTraps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            if (turnScript.playerObject.Count == 2) {
                BlackPanel.SetActive(true);
            }
            
            Time.timeScale = 0;

            StartCoroutine("WaitforAnotherOne2");
        }
        else
        {
            P2turn.SetActive(true);
            StartCoroutine("WaitturnShow2");
        }


    }

    IEnumerator WaitturnShow2()
    {
        NewTrapBotton.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        P1turn.SetActive(false);
        P2turn.SetActive(false);
        if (turnScript.playerObject[0] != null)
        {
            P1Canvas.SetActive(true);
            turnScript.isWaitForPlayer1 = true;
            NewTrapBotton.SetActive(true);
        }
        else
        {
            P2Canvas.SetActive(true);
            turnScript.isWaitForPlayer2 = true;
            NewTrapBotton.SetActive(true);
        }
        EndTrunBotton.SetActive(true);

    }

    IEnumerator WaitforAnotherOne2()
    {
        yield return new WaitForSeconds(1.0f);
        P1turn.SetActive(true);
        StartCoroutine("WaitturnShow2");
    }

    IEnumerator Wait()
    {
        turnScript.isWaitForPlayer1 = false;

        yield return new WaitForSeconds(1.0f);


        if (turnScript.playerObject[1] != null)
        {
            NewTrapBotton.SetActive(false);
            GameObject[] P1Traps = GameObject.FindGameObjectsWithTag("P1Enemy");
            GameObject[] P2Traps = GameObject.FindGameObjectsWithTag("P2Enemy");
            GameObject[] FakeTraps = GameObject.FindGameObjectsWithTag("FakeEnemy");
            for (int i = 0; i < P1Traps.Length; i++)
            {
                P1Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < P2Traps.Length; i++)
            {
                P2Traps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < FakeTraps.Length; i++) {
                FakeTraps[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            if (turnScript.playerObject.Count == 2)
            {
                BlackPanel.SetActive(true);
            }
            Time.timeScale = 0;
            StartCoroutine("WaitforAnotherOne");

        }
        else
        {
            P1turn.SetActive(true);
            StartCoroutine("WaitturnShow");
        }

    }

    IEnumerator WaitturnShow()
    {
        NewTrapBotton.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        P1turn.SetActive(false);
        P2turn.SetActive(false);
        if (turnScript.playerObject[1] != null)
        {
            P2Canvas.SetActive(true);
            turnScript.isWaitForPlayer2 = true;
            NewTrapBotton.SetActive(true);
        }
        else
        {
            P1Canvas.SetActive(true);
            turnScript.isWaitForPlayer1 = true;
            NewTrapBotton.SetActive(true);
        }

        EndTrunBotton.SetActive(true);

    }

    IEnumerator WaitforAnotherOne()
    {
        yield return new WaitForSeconds(1.0f);
        P2turn.SetActive(true);
        StartCoroutine("WaitturnShow");
    }
}
