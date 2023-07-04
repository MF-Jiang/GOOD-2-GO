using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamingManager : MonoBehaviour
{

    public static GamingManager sharedInstance = null;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject TimeOutPanel;
    public GameObject BlackPanel;
    public GameObject settingPanel;
    public GameObject TurnOverButton;
    public GameObject NewTrapButton;
    private Scene scene;
    private bool inTimeOut = false;
    private GoalTrigger Goal;

    private void Awake()
    {
        
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Goal = GameObject.FindGameObjectWithTag("Goal").GetComponent<GoalTrigger>();
        scene = SceneManager.GetActiveScene();
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        Goal = GameObject.FindGameObjectWithTag("Goal").GetComponent<GoalTrigger>();

        if (scene.name == "help1" || scene.name == "help2" || scene.name == "help3") {
            NewTrapButton.SetActive(false);
        }
        if (BlackPanel.activeInHierarchy == true) {
            CloseBlackPanel();
        
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && scene.name != "Menu" && scene.name != "Helpscene" && inTimeOut == false)
        {
            TimeOutGame();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && scene.name != "Menu" && scene.name != "Helpscene" && inTimeOut == true)
        {
            ContinueTimeGame();
            return;
        }

        if (scene.name == "Level1")
        {
            PlayerPrefs.SetInt("Level1key", 1);
            //Debug.Log(PlayerPrefs.GetInt("Level1key"));

        }else if (scene.name == "Level2")
        {
            PlayerPrefs.SetInt("Level2key", 1);
            //Debug.Log(PlayerPrefs.GetInt("Level2key"));
        }

        else if (scene.name == "Level3")
        {
            PlayerPrefs.SetInt("Level3key", 1);
            //Debug.Log(PlayerPrefs.GetInt("Level3key"));
            //Debug.Log(PlayerPrefs.GetInt("Level3key"));

        }

        else if (scene.name == "Level4")
        {
            PlayerPrefs.SetInt("Level4key", 1);

        }
    }

    public void GameOver(bool playerWin)
    {
        StartCoroutine(DelayGameOver(playerWin));
    }

    IEnumerator DelayGameOver(bool playerWin)
    {
        yield return new WaitForSeconds(1.5f);
        if (playerWin)
        {
            NewTrapButton.SetActive(false);
            TurnOverButton.SetActive(false);
            winPanel.SetActive(true);
            if (Goal.twowin == 2)
            {
                //Debug.Log(Goal.twowin);
                winPanel.gameObject.transform.Find("WinPanel two").gameObject.SetActive(true);

            }
            else {
                //Debug.Log(Goal.twowin);
                winPanel.gameObject.transform.Find("WinPanel one").gameObject.SetActive(true);

            }

        }
        else
        {
            NewTrapButton.SetActive(false);
            TurnOverButton.SetActive(false);
            losePanel.SetActive(true);
        }
        Time.timeScale = 0;

    }

    public void LoadNextLevel(int index)
    {
        if (index == 0) {
            int quitScore1 = ScoreCounting1.gamesocre1;
            int quitScore2 = ScoreCounting2.gamesocre2;
            PlayerPrefs.SetInt("Score1", quitScore1);
            PlayerPrefs.SetInt("Score2", quitScore2);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Debug.Log(ScoreCounting1.gamesocre1 + "ssssssssssssssssssss");
        PlayerPrefs.SetInt("firstpic", 0);
        //¥Ê»Î∑÷ ˝
        int quitScore1 = ScoreCounting1.gamesocre1;
        int quitScore2 = ScoreCounting2.gamesocre2;
        PlayerPrefs.SetInt("Score1", quitScore1);
        PlayerPrefs.SetInt("Score2", quitScore2);
        

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
       Application.Quit();
#endif
    }
    public void SettingGame()
    {
        settingPanel.SetActive(true);
        TimeOutPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void TimeOutGame()
    {

        NewTrapButton.SetActive(false);
        TurnOverButton.SetActive(false);

        inTimeOut = true;

        TimeOutPanel.SetActive(true);

        Time.timeScale = 0;


    }

    public void ContinueTimeGame()
    {
        inTimeOut = false;
        TimeOutPanel.SetActive(false);
        NewTrapButton.SetActive(true);
        TurnOverButton.SetActive(true);
        settingPanel.SetActive(false);
        if (BlackPanel.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
        

    }

    public void CloseBlackPanel() {
        if (Input.GetMouseButtonDown(0)) {
            BlackPanel.SetActive(false);
            Time.timeScale = 1;
        
        }
    
    }
}
