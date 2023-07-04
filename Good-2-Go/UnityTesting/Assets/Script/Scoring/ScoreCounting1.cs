using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounting1 : MonoBehaviour
{

    [SerializeField] public static int gamesocre1 = 0;
    [SerializeField]private static ScoreCounting1 onlyOneScore;
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
        gamesocre1 = PlayerPrefs.GetInt("Score1");
        //Debug.Log(gamesocre1);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(gamesocre1);

    }

   /* private void OnGUI()
    {
        GUI.skin.box.fontSize = 30;
        GUI.Box(new Rect(20, 20, 200, 50), " Score1:" + gamesocre1);


    }*/
}
