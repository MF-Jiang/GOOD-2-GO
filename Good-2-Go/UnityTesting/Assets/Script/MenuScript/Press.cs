using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Press : MonoBehaviour
{
    private Text text;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        originalColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {   
            Flashcolor(0.1f);
            

        }
    }

    void Flashcolor(float time) {
        text.color = Color.white;
        Invoke("Resetcolor",time);
    }

    void Resetcolor()
    {
        text.color = originalColor;
    }
}
