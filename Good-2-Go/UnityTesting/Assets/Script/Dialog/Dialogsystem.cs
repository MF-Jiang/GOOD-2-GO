using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogsystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLablel;

    [Header("文件文本")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    bool textFinished;

    List<string> textList = new List<string>();

    private void Awake()
    {
        GetTextFromFile(textFile);
        index = 0;
    }

    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;

        textLablel.text = "";

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLablel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }

        textFinished = true;
        index++;
    }
}
