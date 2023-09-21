using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBits : MonoBehaviour
{
    int bSeq = 64;
    int newSeq = 8 + 1;

    private void Start()
    {
        //converted to base 2 (binary)
        Debug.Log(Convert.ToString(bSeq, 2));

        //8 + 1 will not calculate as it is a string
        Debug.Log(Convert.ToString(newSeq, 2));
    }
    //will print the number's binary 
}
