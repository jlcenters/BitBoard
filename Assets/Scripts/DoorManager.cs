using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    //grabs static instance 
    int doorType = AttributeManager.MAGIC;

    private void OnCollisionEnter(Collision collision)
    {
        //if not an empty instance, turn into a trigger so player can walk through
        if((collision.gameObject.GetComponent<AttributeManager>().attributes & doorType) != 0)
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //will turn back into solid collider when player exits door
        this.GetComponent<BoxCollider>().isTrigger = false;
    }
}
