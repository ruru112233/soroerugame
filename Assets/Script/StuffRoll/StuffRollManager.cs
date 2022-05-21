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


    // �e�L�X�g�̃I�u�W�F�N�g���i�[
    public GameObject textObj;

    // canvas�̊i�[
    public Transform canvas;

    // �e�L�X�g�̊Ԋu
    private float distance = 150.0f;

    // �����̈ʒu
    private Vector3 initPosition = new Vector3(700, 300, 0);

    // �X�^�b�t���[�����ړ�����܂ł̑ҋ@����
    private float waitTime = 2.0f;
    private float countTime = 0;

    // �e�L�X�g�̃��X�g
    private List<string> textList = new List<string>() 
                                       {"�X�^�b�t���[��",
                                        "���F����@�h�i",
                                        "�v���O�����F����h�i",
                                        "�����iBGM�j�FMusMus�l",
                                        "�����iSE�j�F���ʉ��H�[�l",
                                        "�����L���O�@�\����ҁFnaichi�l",
                                        "�V��ł����������肪�Ƃ��������܂��I�I",};

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
