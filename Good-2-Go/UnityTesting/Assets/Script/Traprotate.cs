using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traprotate : MonoBehaviour
{
    public Transform[] ChildsObject;

    
    // Start is called before the first frame update
    void Start()
    {
        ChildsObject = transform.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        rotateTrap();
    }


    void rotateTrap() {


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouPosition = Input.mousePosition;
            Ray mRay = Camera.main.ScreenPointToRay(mouPosition);
            RaycastHit mHit;
            if (Physics.Raycast(mRay, out mHit))
            {
                if (mHit.collider.gameObject.name == "face") {
                    /*var FatherObject = gameObject.transform.parent;
                    FatherObject.localRotation = Quaternion.Euler(0, 0, 0);*/

                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("x", 0);
                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("z", 1);

                    Time.timeScale = 1;
                    Destroy(gameObject);
                }

                if (mHit.collider.gameObject.name == "left") {
                    /*var FatherObject = gameObject.transform.parent;
                    FatherObject.localRotation = Quaternion.Euler(0, -90, 0);*/

                    

                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("x", -1);
                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("z", 0);

                    Time.timeScale = 1;
                    Destroy(gameObject);
                }

                if (mHit.collider.gameObject.name == "behind") {
                    /*var FatherObject = gameObject.transform.parent;
                    FatherObject.localRotation = Quaternion.Euler(0, 180, 0);*/
                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("x", 0);
                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("z", -1);
                    

                    

                    Time.timeScale = 1;
                    Destroy(gameObject);
                }

                if (mHit.collider.gameObject.name == "right") {
                    /*var FatherObject = gameObject.transform.parent;
                    FatherObject.localRotation = Quaternion.Euler(0, 90, 0);*/

                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("x", 1);
                    gameObject.transform.parent.GetComponentInChildren<Animator>().SetFloat("z", 0);

                    

                    Time.timeScale = 1;
                    Destroy(gameObject);
                }


            }
        }

    }
}
