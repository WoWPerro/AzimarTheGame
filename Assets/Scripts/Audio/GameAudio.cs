using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private char zone = 'A';
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

    void PlayPlayerSong()
    {
        string code = "";
        code += zone;
        if(killer)
        {
            code += "1";
        }
        else
        {
            code += "0";
        }
        if(achiever)
        {
            code += "1";
        }
        else
        {
            code += "0";
        }
        if(explorer)
        {
            code += "1";
        }
        else
        {
            code += "0";
        }
        if(socializer)
        {
            code += "1";
        }
        else
        {
            code += "0";
        }
        Debug.Log(code);
        FindObjectOfType<AudioManager>().Play(code);
    }

    void PlaySongs()
    {
        string song = "";
        song += zone;
        if(killer)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(song += 1, 1, .01f));
        }
        if(achiever)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(song += 1, 1, .01f));
        }
        if(explorer)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(song += 1, 1, .01f));
        }
        if (socializer)
        {
            StartCoroutine(FindObjectOfType<AudioManager>().Play(song += 1, 1, .01f));
        }
    }
}
