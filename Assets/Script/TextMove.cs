using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x - speed * Time.deltaTime;
        float y = transform.position.y + speed * Time.deltaTime;

        if (x < -1000f || y < 2000f)
        {
            transform.position = new Vector3(x , y , 0);
        }
        
    }
}
