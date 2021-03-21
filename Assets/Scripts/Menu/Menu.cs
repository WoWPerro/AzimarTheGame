using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindObjectOfType<AudioManager>().Play("Desert", 1, .05f));
    }

}
