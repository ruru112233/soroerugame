using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class StuffRollManager : MonoBehaviour
{

    private bool scrollCheck = false;
    public bool ScrollCheck 
    {
        get => scrollCheck;
        set => scrollCheck = value;
    }


    // テキストのオブジェクトを格納
    public GameObject textObj;

    // canvasの格納
    public Transform canvas;

    // テキストの間隔
    private float distance = 150.0f;

    // 初期の位置
    private Vector3 initPosition = new Vector3(700, 300, 0);

    // スタッフロールが移動するまでの待機時間
    private float waitTime = 2.0f;
    private float countTime = 0;

    // テキストのリスト
    private List<string> textList = new List<string>() 
                                       {"スタッフロール",
                                        "企画：樋口　栄司",
                                        "プログラム：樋口栄司",
                                        "音源（BGM）：MusMus様",
                                        "音源（SE）：効果音工房様",
                                        "ランキング機能制作者：naichi様",
                                        "遊んでいただきありがとうございます！！",};

    void Start()
    {
        SetText();

    }

    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime > waitTime) ScrollCheck = true;
    }

    void SetText()
    {
        Vector3 pos = initPosition;

        foreach (string text in textList)
        {
            CreateText(text, pos);

            pos.y -= distance;
        }
    }

    void CreateText(string str, Vector3 position)
    {
        GameObject obj = Instantiate(textObj);

        obj.transform.SetParent(canvas);
        obj.GetComponent<Text>().text = str;
        obj.AddComponent<TextRollMove>();
        obj.transform.position = position;

        obj.SetActive(true);
    }

}
