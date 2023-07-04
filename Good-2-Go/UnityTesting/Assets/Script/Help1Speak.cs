using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help1Speak : MonoBehaviour
{
    public GameObject P1;
    private bool P1dieone = false;
    public GameObject P2;
    private bool P2dieone = false;
    public GameObject P1SpeakPanel;
    public GameObject P2SpeakPanel;
    public GameObject NewTrapBotton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (P1 == null && P1dieone == false) {
            P1SpeakPanel.SetActive(true);
            NewTrapBotton.SetActive(false);
            P1dieone = true;
            StartCoroutine(TimeOut());
        }

        if (P2 == null && P2dieone == false) {
            P2SpeakPanel.SetActive(true);
            NewTrapBotton.SetActive(false);
            P2dieone = true;
            StartCoroutine(TimeOut());
        }

        if (P1SpeakPanel.active || P2SpeakPanel.active) {
            if (Input.GetMouseButtonDown(0))
            {
                //NewTrapBotton.SetActive(true);
                P1SpeakPanel.SetActive(false);
                P2SpeakPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator TimeOut() {
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
    }
}
