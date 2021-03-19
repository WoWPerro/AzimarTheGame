using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorChanger : MonoBehaviour
{
    private TextMeshProUGUI tmpObj;
    // Start is called before the first frame update
    void Start()
    {
        tmpObj = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void ChangeColorToWhite()
    {
        tmpObj.color = Color.white;
    }

    public void ChangeColorToBlack()
    {
        tmpObj.color = Color.black;
    }

    public void PLayUIEffect(string s)
    {
        FindObjectOfType<AudioManager>().Play(s);
    }
}
