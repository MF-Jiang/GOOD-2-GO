using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getcamera : MonoBehaviour
{
    public GameObject maincamera;

    private Canvas ui;
    private void Awake()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        ui = gameObject.GetComponent<Canvas>();

        ui.worldCamera = maincamera.GetComponent<Camera>();
    }
}
