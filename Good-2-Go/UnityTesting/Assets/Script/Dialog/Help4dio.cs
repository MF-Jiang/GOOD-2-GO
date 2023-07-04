using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help4dio : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject dioPanel1;
    public GameObject dioPanel2;
    // Start is called before the first frame update
    private void Awake()
    {
        dioPanel1.SetActive(true);
        firstPanel.SetActive(false);
        Time.timeScale = 0;
    }

    void Start()
    {
        firstPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dioPanel1.active == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                StartCoroutine(waitscene());
            }
        }

        if (dioPanel2.active==true) {
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(0))
            {
                dioPanel2.SetActive(false);
                Time.timeScale = 1;
                firstPanel.SetActive(true);
            }
        }

    }

    IEnumerator waitscene() {      
        yield return new WaitForSeconds(0.1f);
        dioPanel1.SetActive(false);
        dioPanel2.SetActive(true);
    }
}
