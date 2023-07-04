using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : HintTrigger
{
    private GameObject[] PlayerSet;
    public int twowin = 0;
    public bool P1finsih=false;
    public bool P2finish=false;
    private bool OneisFinish = false;
    private PlayerManagement BeAttackedObject;

    public AudioClip allwinsound;
    public AudioClip alldiesound;
    public AudioClip[] onewinsounds;
    public AudioClip[] onefirstwinsounds;
    private AudioSource source;
    private bool finishgame = false;
    // Start is called before the first frame update
    void Start()
    {
        OneisFinish = false;
        twowin = 0;
        P1finsih = false;
        P2finish = false;

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSet = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(PlayerSet.Length);

        //双人获胜
        if (twowin == 2 && finishgame==false) {
            ScoreCounting1.gamesocre1 += 1000;
            ScoreCounting2.gamesocre2 += 1000;
            GamingManager.sharedInstance.GameOver(true);
            finishgame = true;
            source.clip = allwinsound;
            source.PlayOneShot(source.clip);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.gameObject.CompareTag("Player")) {

            //一个人先死了，后者一个人独自获胜
            if (PlayerSet.Length == 2 && other.gameObject.name=="P1Collider" && OneisFinish == false) 
            {
                ScoreCounting1.gamesocre1 += 2000;
                GamingManager.sharedInstance.GameOver(true);

                source.clip = onewinsounds[Random.Range(0, onewinsounds.Length)];
                source.PlayOneShot(source.clip);
            }

            if (PlayerSet.Length == 2 && other.gameObject.name == "P2Collider" && OneisFinish == false)
            {
                ScoreCounting2.gamesocre2 += 2000;
                GamingManager.sharedInstance.GameOver(true);

                source.clip = onewinsounds[Random.Range(0, onewinsounds.Length)];
                source.PlayOneShot(source.clip);
            }

            //一个人先到达终点
            if (PlayerSet.Length == 4 && other.gameObject.name == "P1Collider") 
            {
                twowin += 1;
                OneisFinish = true;
                BeAttackedObject = other.gameObject.transform.parent.gameObject.transform.GetComponentInParent<PlayerManagement>();
                BeAttackedObject.isWaitForPlayer1 = !BeAttackedObject.isWaitForPlayer1;
                BeAttackedObject.isWaitForPlayer2 = !BeAttackedObject.isWaitForPlayer2;
                BeAttackedObject.OneisDie = true;
                P1finsih = true;
                Destroy(other.gameObject.transform.parent.gameObject);

                source.clip = onefirstwinsounds[Random.Range(0, onefirstwinsounds.Length)];
                source.PlayOneShot(source.clip);
            }

            if (PlayerSet.Length == 4 && other.gameObject.name == "P2Collider")
            {
                twowin += 1;
                OneisFinish = true;
                BeAttackedObject = other.gameObject.transform.parent.gameObject.transform.GetComponentInParent<PlayerManagement>();
                BeAttackedObject.isWaitForPlayer1 = !BeAttackedObject.isWaitForPlayer1;
                BeAttackedObject.isWaitForPlayer2 = !BeAttackedObject.isWaitForPlayer2;
                BeAttackedObject.OneisDie = true;
                P2finish = true;
                Destroy(other.gameObject.transform.parent.gameObject);

                source.clip = onefirstwinsounds[Random.Range(0, onefirstwinsounds.Length)];
                source.PlayOneShot(source.clip);
            }

            //另一个人也到终点
            if (PlayerSet.Length == 2 && OneisFinish == true && other.gameObject.name == "P1Collider") 
            {
                twowin += 1;

                source.clip = allwinsound;
                source.PlayOneShot(source.clip);
            }

            if (PlayerSet.Length == 2 && OneisFinish == true && other.gameObject.name == "P2Collider")
            {
                twowin += 1;

                source.clip = allwinsound;
                source.PlayOneShot(source.clip);
            }

        }
    }
    public void bothdie() {
        source.clip = alldiesound;
        source.PlayOneShot(source.clip);
    }

}
