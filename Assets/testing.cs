using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    float timee;
    bool isEven;
    // Start is called before the first frame update
    void Start()
    {
        isEven = true;
    }

    // Update is called once per frame
    void Update()
    {
        timee += Time.deltaTime;
        if(System.Convert.ToInt32(timee) % 2 ==0)
        {
            if (isEven)
            {
                isEven = false;
                Debug.Log(System.Convert.ToInt32(timee));
            }
            if(timee > 2)
            {
                timee = 0;
                isEven = true;
            }


        }

    }
}
