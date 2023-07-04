using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCouldChoose : MonoBehaviour
{
    [SerializeField] private int couldlevel1 = 0;
    public GameObject level1btn;
    [SerializeField] private int couldlevel2 = 0;
    public GameObject level2btn;
    [SerializeField] private int couldlevel3 = 0;
    public GameObject level3btn;
    [SerializeField] private int couldlevel4 = 0;
    public GameObject level4btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("Level1key"));
        /*        Debug.Log(PlayerPrefs.GetInt("Level1key"));
                couldlevel1 = PlayerPrefs.GetInt("Level1key");
                couldlevel2 = PlayerPrefs.GetInt("Level2key");
                couldlevel1 = PlayerPrefs.GetInt("Level3key");
                couldlevel2 = PlayerPrefs.GetInt("Level4key");

                Debug.Log(couldlevel1);*/

        if (PlayerPrefs.GetInt("Level1key") == 1)
        {
            level1btn.SetActive(true);
        }
        else {
            level1btn.SetActive(false);
        }
        
        if (PlayerPrefs.GetInt("Level2key") == 1) {
            level2btn.SetActive(true);
        }
        else
        {
            level2btn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level3key") == 1)
        {
            level3btn.SetActive(true);
        }
        else
        {
            level3btn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level4key") == 1)
        {
            level4btn.SetActive(true);
        }
        else
        {
            level4btn.SetActive(false);
        }
    }
}
