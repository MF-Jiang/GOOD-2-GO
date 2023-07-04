using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectTrapButton : MonoBehaviour
{
    public static SelectTrapButton sharedInstance = null;
    public GameObject TrapSelectPanel;
    public GameObject NewTrapBotton;
    public GameObject EndTurnBtn;
    public GameObject P1;
    public GameObject P2;

    private GameObject[] turnObject;
    private GameObject[] FakeObject;

    private TrapChoose resetwhichtrap;

    private void Start()
    {
        resetwhichtrap = GameObject.Find("TrapbuttonObjectprefab").GetComponent<TrapChoose>();
    }

    private void Update()
    {

    }

    private void Awake()
    {

        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }
    public void SetTrapPanel() {
        TrapSelectPanel.SetActive(true);
        resetwhichtrap.whichtrap = 4;
        FakeObject = GameObject.FindGameObjectsWithTag("FakeEnemy");
        if (FakeObject.Length != 0)
        {
            for (int i = 0; i < FakeObject.Length; i++)
            {
                FakeObject[i].layer = LayerMask.NameToLayer("Default");
                FakeObject[i].GetComponentInChildren<CapsuleCollider>().gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }

        NewTrapBotton.SetActive(false);
        EndTurnBtn.SetActive(false);
        if (P1 != null) {
            P1.GetComponent<Playermovement1>().enabled = false;
        }
        if (P2 != null) {
            P2.GetComponent<Playermovement2>().enabled = false;
        }
        
        //Time.timeScale = 0;
       

    }
    public void ContinueTimeGame()
    {
        gameObject.GetComponent<TrapChoose>().whichtrap = 4;
        turnObject = GameObject.FindGameObjectsWithTag("TempTurn");

        //Debug.Log(turnObject.Length);

        if (turnObject.Length == 0)
        {
            FakeObject = GameObject.FindGameObjectsWithTag("FakeEnemy");
            if (FakeObject.Length != 0)
            {
                for (int i = 0; i < FakeObject.Length; i++)
                {
                    FakeObject[i].layer = LayerMask.NameToLayer("Ignore Raycast");
                    FakeObject[i].GetComponentInChildren<CapsuleCollider>().gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                }
            }

            TrapSelectPanel.SetActive(false);
            NewTrapBotton.SetActive(true);

            if (P1 != null)
            {
                P1.GetComponent<Playermovement1>().enabled = true;
            }
            if (P2 != null)
            {
                P2.GetComponent<Playermovement2>().enabled = true;
            }

            EndTurnBtn.SetActive(true);
            Time.timeScale = 1;
        }
        else {
            for (int i = 0; i < turnObject.Length; i++) {
                Destroy(turnObject[i].transform.parent.gameObject);
            }

            TrapSelectPanel.SetActive(false);
            NewTrapBotton.SetActive(true);

            if (P1 != null)
            {
                P1.GetComponent<Playermovement1>().enabled = true;
            }
            if (P2 != null)
            {
                P2.GetComponent<Playermovement2>().enabled = true;
            }

            EndTurnBtn.SetActive(true);
            Time.timeScale = 1;
        }

    }

    public void SendTrapInt(int index) {
        gameObject.GetComponent<TrapChoose>().whichtrap = index;

    }


}
