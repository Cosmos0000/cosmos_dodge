using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] a = new int[10];

        int love = 60;
        int i = 0;
        for(love = 60; love < 91; love++)
        {
            Debug.Log(love + ".." + i);
            i++;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
