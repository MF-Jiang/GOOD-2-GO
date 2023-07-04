using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DieBack : MonoBehaviour
{
    private Transform originTransform;
    private PlayerManagement turnScript;
    public GameObject Level3DieBackPanel;
    // Start is called before the first frame update
    void Start()
    {
        originTransform = gameObject.transform;
        turnScript = GameObject.Find("Player").GetComponent<PlayerManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((turnScript.playerObject[0] == null && turnScript.playerObject[1] != null) || (turnScript.playerObject[0] != null && turnScript.playerObject[1] == null)) { //一个玩家寄了
            if (gameObject.transform == originTransform) {//三连物体在卡关位置 
                GameObject finalplayer = GameObject.FindGameObjectWithTag("Player");
                //Debug.Log(finalplayer.name);
                if (finalplayer.transform.position.z==-4|| finalplayer.transform.position.z == -3 || finalplayer.transform.position.x == 4 || finalplayer.transform.position.x == 3) {
                    Debug.Log(finalplayer.name);
                    Level3DieBackPanel.SetActive(true);
                }
            }
        }   

    }
}
