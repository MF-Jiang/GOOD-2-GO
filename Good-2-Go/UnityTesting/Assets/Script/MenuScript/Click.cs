using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Camera camera;
    public UIManager uim;
    Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        tempPos = camera.transform.position;
        uim.wewanttransform = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = uim.wewanttransform;
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, tempPos, 5.0f * Time.deltaTime);


        
    }




}
