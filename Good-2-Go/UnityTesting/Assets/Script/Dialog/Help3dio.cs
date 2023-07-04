using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help3dio : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject dioPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        dioPanel.SetActive(true);
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
        if (dioPanel.active == true) {
            if (Input.GetMouseButtonDown(0)) {
                dioPanel.SetActive(false);
                Time.timeScale = 1;
                firstPanel.SetActive(true);
            }
        }
    }
}
