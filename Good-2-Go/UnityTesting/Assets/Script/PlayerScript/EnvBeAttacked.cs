using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvBeAttacked : MonoBehaviour
{
    public GameObject killsound;
    // Start is called before the first frame update

    void Start()
    {
        killsound = GameObject.Find("killsound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            killsound.GetComponent<playkillsound>().kill();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaittoBeAttacked( gameObject));
        }
    }

    IEnumerator WaittoBeAttacked(GameObject gameself)
    {

        yield return new WaitForSeconds(1.0f);

        Destroy(gameself.transform.parent.parent.gameObject);

    }

}
