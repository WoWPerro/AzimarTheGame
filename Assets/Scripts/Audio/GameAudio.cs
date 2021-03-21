using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private string zone = "A";
    public bool killer = true;
    public bool achiever = false;
    public bool explorer = false;
    public bool socializer = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Stop("Desert");
        PlaySongs();
    }

    void PlaySongs()
    {
        if(killer)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(zone + "1", 1, .01f));
        }
        if(achiever)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(zone + "2", 1, .01f));
        }
        if(explorer)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(zone + "3", 1, .01f));
        }
        if (socializer)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(zone + "4", 1, .01f));
        }
    }
}
