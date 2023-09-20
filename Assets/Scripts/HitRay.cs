using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRay : MonoBehaviour
{

    private void Update()
    {
        int layerMask = 1 << 10 | 1 << 9;
        //layer will hit everything but specified layer mask
        //layerMask = ~layerMask;
       
        RaycastHit hit;

        //if raycast hits an object with specified layer mask, draw line 
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("no hit");
        }
    }
}
