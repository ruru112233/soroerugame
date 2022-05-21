using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TextRollMove : MonoBehaviour
{
    private StuffRollManager stuffRollManager;

    private float speed = 25.0f;

    void Start()
    {
        stuffRollManager = GameObject.FindGameObjectWithTag("StuffRoll").GetComponent<StuffRollManager>();
    }

    void Update()
    {
        
        if (stuffRollManager.ScrollCheck) 
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }


    }
}
