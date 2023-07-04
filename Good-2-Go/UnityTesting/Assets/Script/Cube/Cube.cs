using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool hasTrap = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (((other.gameObject.tag == "FakeTrapcenter" && other.gameObject.transform.parent.parent.gameObject.tag == "FakeEnemy") ||  other.gameObject.tag == "Player") && other.transform.position.x == gameObject.transform.position.x && other.transform.position.z == gameObject.transform.position.z)
        {
            hasTrap = true;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (((other.gameObject.tag == "FakeTrapcenter" && other.gameObject.transform.parent.parent.gameObject.tag == "FakeEnemy") || (other.gameObject.tag == "Untagged" && other.gameObject.transform.parent.parent.gameObject.tag == "P1Enemy") || (other.gameObject.tag == "Untagged" && other.gameObject.transform.parent.parent.gameObject.tag == "P2Enemy") || other.gameObject.tag == "Player"))
        {
            //Debug.Log("XXXXX");
            hasTrap = false;
        }
    }
}
