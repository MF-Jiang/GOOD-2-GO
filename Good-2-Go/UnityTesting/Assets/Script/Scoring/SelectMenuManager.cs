using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SelectMenuManager : MonoBehaviour
{
    [Header("-------------score------------")]
    public TMP_Text P1score;
    public TMP_Text P2score;

    [Header("-------------Panel-------------")]
    public GameObject SelectLevelPanel;
    public GameObject ScorePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        P1score.text = "P1 Score: " + PlayerPrefs.GetInt("Score1");
        P2score.text = "P2 Score: " + PlayerPrefs.GetInt("Score2");
    }

    //回到选择关卡
    public void BackToLevel()
    {
        SelectLevelPanel.SetActive(true);
        ScorePanel.SetActive(false);
    }
    //到分数界面
    public void GotoScore()
    {
        SelectLevelPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }
    //重置分数
    public void DeleteScore()
    {
        PlayerPrefs.SetInt("Level1key", 0);
        PlayerPrefs.SetInt("Level2key", 0);
        PlayerPrefs.SetInt("Level3key", 0);
        PlayerPrefs.SetInt("Level4key", 0);

        //Debug.Log(PlayerPrefs.GetInt("Level1key"));


        PlayerPrefs.SetInt("Score1",0);
        PlayerPrefs.SetInt("Score2",0);
    }
}
