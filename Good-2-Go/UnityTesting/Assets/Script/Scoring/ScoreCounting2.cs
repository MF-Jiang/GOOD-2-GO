using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounting2 : MonoBehaviour
{
    [SerializeField] public static int gamesocre2 = 0;
    [SerializeField]private static ScoreCounting2 onlyOneScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if (onlyOneScore != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        onlyOneScore = this;
        DontDestroyOnLoad(gameObject);
        gamesocre2 = PlayerPrefs.GetInt("Score2");
        //Debug.Log(gamesocre2);
    }
    void Update()
    {
        //Debug.Log(gamesocre2);
    }
    // Update is called once per frame
    /* private void OnGUI()
     {
         GUI.skin.box.fontSize = 30;
         GUI.Box(new Rect(20, 80, 200, 50), " Score2:" + gamesocre2);
     }
    */

}
