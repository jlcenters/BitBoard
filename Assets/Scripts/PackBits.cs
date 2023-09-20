using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PackBits : MonoBehaviour
{
    static string A = "110111";
    static string B = "10001";
    static string C = "1101";
    int aBits = Convert.ToInt32(A, 2);
    int bBits = Convert.ToInt32(B, 2);
    int cBits = Convert.ToInt32(C, 2);

    int packed = 0;

    private void Start()
    {
        //of 32 digits, packed will start all the way to the left
        packed |= (aBits << 26);
        packed |= (bBits << 21);
        packed |= (cBits << 17);
        Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));
    }
}
