using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement1 : MonoBehaviour
{
    public float movspeed=1;
    private Vector3 mTargetPos;
    private PlayerManagement turnScript;

    [Header("GameOBject")]
    public GameObject NewTrapBotton;
    public GameObject P1turn;
    public GameObject P2turn;
    public GameObject EndTurnBotton;
    

    [Header("Panel")]
    public GameObject NewTrapPanel;
    public GameObject BlackPanel;
    public GameObject settingGamePanel;
    public GameObject PausePanel;

    [Header("Bool")]
    private bool justArrive = false;
    public bool movetoanotherCube = false;

    [Header("Audio")]
    public AudioClip[] walksounds;
    public AudioClip[] laughsounds;
    private AudioSource source;

    [Header("Animator")]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        justArrive = false;
        mTargetPos = transform.position;
        turnScript = GameObject.Find("Player").GetComponent<PlayerManagement>();
        anim = GetComponent<Animator>();

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == mTargetPos) {
            anim.SetBool("isMoving", false);
            movetoanotherCube = false;
            
        }
        if (anim.GetBool("isMoving") == false) {
            mTargetPos = this.transform.position;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, mTargetPos, movspeed * Time.deltaTime);

        if (NewTrapPanel.active != true && settingGamePanel.active !=true && PausePanel.active != true) {           
            ClicktoMove();
        }

        
        if (this.transform.position == mTargetPos && justArrive== true) {
            EndTurnBotton.SetActive(true);
            justArrive = false;
            source.Stop();
        }
    }

    void ClicktoMove() {
        if (Input.GetMouseButtonDown(0) && turnScript.isWaitForPlayer1 == true)
        {
            Vector3 mScreenPos = Input.mousePosition;
            Ray mRay = Camera.main.ScreenPointToRay(mScreenPos);
            RaycastHit mHit;
            if (Physics.Raycast(mRay, out mHit))
            {

                float a = Mathf.Sqrt((Mathf.Pow(Mathf.Abs(mHit.collider.gameObject.transform.position.x - this.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(mHit.collider.gameObject.transform.position.z - this.transform.position.z), 2)));
                float b = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(mHit.collider.gameObject.transform.position.y - (this.transform.position.y - 1.5f)), 2));
                //Debug.Log(a);
                //Debug.Log(b);
                if ((mHit.collider.gameObject.CompareTag("Cube") || mHit.collider.gameObject.CompareTag("MovingCube") || mHit.collider.gameObject.CompareTag("P1MovingCube") || mHit.collider.gameObject.CompareTag("P2MovingCube") || mHit.collider.gameObject.CompareTag("Rod2MovingCube") || mHit.collider.gameObject.CompareTag("ThreeMovingCube")) && a > 0.9f && a < 1.3f && b<1.1f)
                {
                    //Debug.Log("XXX");
                    anim.SetBool("isMoving", true);
                    EndTurnBotton.SetActive(false);
                    justArrive = true;
                    Vector3 Cposition = mHit.collider.gameObject.transform.position;

                    anim.SetFloat("x", Mathf.Round(Cposition.x - transform.position.x));
                    anim.SetFloat("z", Mathf.Round(Cposition.z - transform.position.z));


                    mTargetPos = Cposition;
                    mTargetPos.y = Cposition.y + 1.5f;

                    turnScript.isWaitForPlayer1 = false;
                    turnScript.ChangetoP2 = true;
                    movetoanotherCube = true;

                    StartCoroutine(WaitRotate());

                    source.clip = walksounds[Random.Range(0, walksounds.Length)];
                    source.PlayOneShot(source.clip);
                }
            }
        }

    }
    public void laugh() {
        source.clip = laughsounds[Random.Range(0, laughsounds.Length)];
        source.PlayOneShot(source.clip);
    }

    IEnumerator WaitRotate() {
        yield return new WaitForSeconds(1.0f);
        RotateTrap[] P1Enemy = GameObject.Find("P1Trap").gameObject.GetComponentsInChildren<RotateTrap>();
        if (P1Enemy != null)
        {
            for (int i = 0; i < P1Enemy.Length; i++)
            {
                P1Enemy[i].gameObject.GetComponent<RotateTrap>().RotatethisTrap();
            }
        }
    }
}
