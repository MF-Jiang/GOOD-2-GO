using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKeyMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            StartCoroutine("waittoClose");
        }
    }

    IEnumerator waittoClose() {
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("firstpic", 1);
        gameObject.SetActive(false);
        
    }
}
