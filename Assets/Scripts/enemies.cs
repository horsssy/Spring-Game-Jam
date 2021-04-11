using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    Vector3 currentTarget;
    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((currentTarget-transform.position).magnitude<0.2f && !triggered)
        {

        }
        else
        {
            
        }
    }

    void SetTarget(Vector3 pos)
    {
        
    }
    void TriggerRemoval()
    {

    }
}
