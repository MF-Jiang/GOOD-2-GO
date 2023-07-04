using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private int firstpic = 0;
    private Scene scene;
    public Vector3 wewanttransform;
    public GameObject firstPic;
    
    // Start is called before the first frame update
    void Start()
    {
        firstpic = PlayerPrefs.GetInt("firstpic");
        if (firstpic == 0) {
            firstPic.SetActive(true);
            
        }
        scene = SceneManager.GetActiveScene();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int index) {

        wewanttransform =  OnClick();
        StartCoroutine(WaittoLoad(index));
    }


    public void QuitGame()
    {
        PlayerPrefs.SetInt("firstpic", 0);
        int quitScore1 = ScoreCounting1.gamesocre1;
        int quitScore2 = ScoreCounting2.gamesocre2;
        PlayerPrefs.SetInt("Score1", quitScore1);
        PlayerPrefs.SetInt("Score2", quitScore2);
        wewanttransform = OnClick();
        StartCoroutine(WaittoQiut());
    }

    IEnumerator WaittoLoad(int index) {
        yield return new WaitForSeconds(3.0f);
        LoadNextLevel(index);
    }

    IEnumerator WaittoQiut() {
        yield return new WaitForSeconds(3.0f);
        Application.Quit();
    }

    public void LoadNextLevel(int index)
    {
        SceneManager.LoadScene(index);

    }

    public Vector3 OnClick()
    {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Vector3 temppos = button.transform.position;
        temppos.z = temppos.z - 5;
        return temppos;
    }
}
