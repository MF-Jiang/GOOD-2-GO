using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrap : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatethisTrap() {
        if (anim.GetFloat("x") == 0 && anim.GetFloat("z") == 1) {
            anim.SetFloat("x", -1);
            anim.SetFloat("z", 0);
            gameObject.transform.parent.gameObject.GetComponentInChildren<EnvAttack>().gameObject.transform.localPosition = new Vector3(-1.0f,0.5f,0.0f);
        }
        else if (anim.GetFloat("x") == 0 && anim.GetFloat("z") == -1) {
            anim.SetFloat("x", 1);
            anim.SetFloat("z", 0);
            gameObject.transform.parent.gameObject.GetComponentInChildren<EnvAttack>().gameObject.transform.localPosition = new Vector3(1.0f, 0.5f, 0.0f);
        }
        else if (anim.GetFloat("x") == 1 && anim.GetFloat("z") == 0) {
            anim.SetFloat("x", 0);
            anim.SetFloat("z", 1);
            gameObject.transform.parent.gameObject.GetComponentInChildren<EnvAttack>().gameObject.transform.localPosition = new Vector3(0.0f, 0.5f, 1.0f);
        }
        else if (anim.GetFloat("x") == -1 && anim.GetFloat("z") == 0) {
            anim.SetFloat("x", 0);
            anim.SetFloat("z", -1);
            gameObject.transform.parent.gameObject.GetComponentInChildren<EnvAttack>().gameObject.transform.localPosition = new Vector3(0.0f, 0.5f, -1.0f);
        }

    }
}
