using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnvAttack : MonoBehaviour
{
    private PlayerManagement BeAttackedObject;
    //public Button EndBtn;
    public GameObject p1;
    public GameObject p2;

    public AudioClip[] eatsounds;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(WaittoDie(other.gameObject.transform.parent.gameObject,gameObject.transform.parent.gameObject));
        }
    }

    IEnumerator WaittoDie(GameObject game, GameObject gameself) {
        BeAttackedObject = game.transform.GetComponentInParent<PlayerManagement>();
        Destroy(game);
        gameObject.transform.parent.gameObject.GetComponentInChildren<Animator>().SetBool("CouldAttack", true);

        source.clip = eatsounds[Random.Range(0, eatsounds.Length)];
        source.PlayOneShot(source.clip);

        yield return new WaitForSeconds(1.0f);

        if (p1!=null) {
            p1.GetComponent<Playermovement1>().laugh();
        }
        if (p2 != null)
        {
            p2.GetComponent<Playermovement2>().laugh();
        }
        //p1À¿¡Àp2≥∞–¶£¨p2À¿¡À£¨£¨£¨£¨£¨
        BeAttackedObject.isWaitForPlayer1 = !BeAttackedObject.isWaitForPlayer1;
        BeAttackedObject.isWaitForPlayer2 = !BeAttackedObject.isWaitForPlayer2;
        BeAttackedObject.OneisDie = true;
        //Destroy(gameself);
        gameself.gameObject.GetComponentInChildren<CapsuleCollider>().center = new Vector3(0.0f, 20.0f, 0.0f);
        StartCoroutine(WaitDES(gameself));

    }

    IEnumerator WaitDES(GameObject game) {
        yield return new WaitForSeconds(0.1f);
        Destroy(game);
    }



}
