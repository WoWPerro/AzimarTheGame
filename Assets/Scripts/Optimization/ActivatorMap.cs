using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ActivatorMap : MonoBehaviour
{
    ShadowCaster2D shadowCaster;
    // Start is called before the first frame update
    void Start()
    {
        shadowCaster = GetComponent<ShadowCaster2D>();
        shadowCaster.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            shadowCaster.enabled = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            shadowCaster.enabled = false;
        }
    }
}
