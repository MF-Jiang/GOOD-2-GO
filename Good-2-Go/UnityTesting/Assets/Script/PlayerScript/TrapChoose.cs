using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChoose : MonoBehaviour
{
    private PlayerManagement turnScript;
    public GameObject P1;
    public GameObject P2;
    private GameObject[] trapfabs;
    public GameObject[] trapfabsP1;
    public GameObject[] trapfabsP2;
    public int whichtrap = 4;
    
    public GameObject TrapSelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        turnScript = GameObject.Find("Player").GetComponent<PlayerManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (whichtrap != 4)
        {
            CLicktoBuild();
        }
        /*        if (whichtrap <= 4 && 0 <= whichtrap)
                {
                    ClicktoDelete();
                }*/

        ClicktoDelete();

        if ((turnScript.ChangetoP2 == true || turnScript.isWaitForPlayer1 == true) && turnScript.playerObject[0] != null)
        { //P1回合
            trapfabs = trapfabsP1;
        }
        if ((turnScript.ChangetoP1 == true || turnScript.isWaitForPlayer2 == true) && turnScript.playerObject[1] != null)
        { //P2回合
            trapfabs = trapfabsP2;
        }
    }

    void CLicktoBuild() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouPosition = Input.mousePosition;
            Ray mRay = Camera.main.ScreenPointToRay(mouPosition);
            RaycastHit mHit;
            if (Physics.Raycast(mRay, out mHit)) {
                float a = Mathf.Sqrt((Mathf.Pow(Mathf.Abs(mHit.collider.gameObject.transform.position.x - this.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(mHit.collider.gameObject.transform.position.z - this.transform.position.z), 2)));

                if ((mHit.collider.gameObject.CompareTag("Cube")|| mHit.collider.gameObject.CompareTag("MovingCube")|| mHit.collider.gameObject.CompareTag("P1MovingCube")|| mHit.collider.gameObject.CompareTag("P2MovingCube") || mHit.collider.gameObject.CompareTag("Rod2MovingCube") || mHit.collider.gameObject.CompareTag("ThreeMovingCube")) &&mHit.collider.gameObject.GetComponent<Cube>().hasTrap==false)
                {
                    Vector3 Cposition = mHit.collider.gameObject.transform.position;
                    Cposition.y = Cposition.y +0.88f;

                    GameObject point = GameObject.Instantiate(trapfabs[whichtrap], Cposition,trapfabs[whichtrap].transform.rotation) as GameObject;

                    whichtrap = 4;

                    if (P1 != null)
                    {
                        P1.GetComponent<Playermovement1>().enabled = true;
                    }
                    if (P2 != null)
                    {
                        P2.GetComponent<Playermovement2>().enabled = true;
                    }
                }
            }

        }  
    }

    void ClicktoDelete() {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouPosition = Input.mousePosition;
            Ray mRay = Camera.main.ScreenPointToRay(mouPosition);
            RaycastHit mHit;
            if (Physics.Raycast(mRay, out mHit))
            {
                if (mHit.collider.gameObject.CompareTag("FakeTrapcenter"))
                {
                    mHit.collider.GetComponent<CapsuleCollider>().center = new Vector3(0.0f,20.0f,0.0f);
                    //Destroy(mHit.collider.gameObject.transform.parent.parent.gameObject);
                    StartCoroutine(WaitDes(mHit.collider.gameObject.transform.parent.parent.gameObject));
                }
            }
        }

    }

    IEnumerator WaitDes(GameObject gameObject) {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
