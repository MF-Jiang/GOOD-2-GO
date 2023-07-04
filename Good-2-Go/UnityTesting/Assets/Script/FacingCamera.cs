using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    Transform[] Childs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Childs[i] = transform.GetChild(i);
        }
        for (int i = 0; i < Childs.Length; i++)
        {
            Childs[i].rotation = Camera.main.transform.rotation;
        }
    }
}
