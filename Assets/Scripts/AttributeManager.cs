using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    //bit flags
    static public int MAGIC = 16;
    static public int INT = 8;
    static public int CHA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    public Text attributeDisplay;

    //attributes for display
    public int attributes = 0;



    // Update is called once per frame
    void Update()
    {
        //world to screen translates the display
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);

        //text will display as the binary attribute, with 8 zeroes padded to the left
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        //if the trigger entered has the magic tag, add the magic flag to the attributes int
        if (tag == "MAGIC")
        {
            //bitwise OR operator; will turn on if either ints are on in each bit
            attributes ^= MAGIC;
        }
        else if (tag == "INT")
        {
            attributes ^= INT;
        }
        else if (tag == "CHA")
        {
            attributes ^= CHA;
        }
        else if (tag == "FLY")
        {
            attributes ^= FLY;
        }
        else if (tag == "INVISIBLE")
        {
            attributes ^= INVISIBLE;
        }
        else if(tag == "ANTIMAG")
        {
            //attributes will only equal the inverse of magic; hence removing magic flag
            //bitwise AND operator; will only turn on if both bits are on
            //bitwise NOT operator; returns the inverse of the bits
            attributes &= ~MAGIC;
        }
        else if(tag == "REMOVE")
        {
            attributes &= ~(INT | MAGIC);
        }
        else if(tag == "ADD")
        {
            attributes |= (INT | MAGIC | CHA);
        }
        else if(tag == "CLEAR")
        {
            attributes = 0;
        }
    }

}
