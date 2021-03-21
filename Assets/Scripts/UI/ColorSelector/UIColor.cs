using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIColor : MonoBehaviour
{
    (bool owned, int price)[] buyedSkins;
    int currentindex = 0;
    public GameObject player;
    public  RectTransform Palettes;

    public TextMeshProUGUI TextBuy;

    public Material white;
    public Material black;
    public Material red;
    public Material magenta;
    public Material blue;
    public Material green;
    public Camera camera;
    public AnimationCurve curve;
    public List<PaleteColor> colorpalettes;

    private void Start()
    {
        buyedSkins = new (bool owned, int price)[]
        {//white, blue, green, black, magenta, red, bk
            (true, 100),
            (false, 100),
            (false, 100),
            (false, 100),
            (false, 100),
            (false, 100),
            (false, 100)
        };
    }

    public void Buy()
    {
        if(buyedSkins[currentindex].owned)
        {
            ApplyPalette(currentindex);
        }
        else
        {
            if(player.GetComponent<PlayerController>().Exp > buyedSkins[currentindex].price)
            {
                buyedSkins[currentindex].owned = true;
                ApplyPalette(currentindex);
            }
        }
    }

    private void ApplyPalette(int index)
    {
        white.SetColor("_ColorTo", colorpalettes[index].white);
        blue.SetColor("_ColorTo", colorpalettes[index].blue);
        green.SetColor("_ColorTo", colorpalettes[index].green);
        black.SetColor("_ColorTo", colorpalettes[index].black);
        magenta.SetColor("_ColorTo", colorpalettes[index].magenta);
        red.SetColor("_ColorTo", colorpalettes[index].red);
        camera.backgroundColor = colorpalettes[index].Background;
    }

    public void Next()
    {
        if(currentindex < 6)
        {
            currentindex++;
            LeanTween.moveX(Palettes, -1920 * currentindex, .5f).setEase(curve);
        }
        
    }

    public void Prev()
    {
        if(currentindex > 0)
        {
            currentindex--;
            LeanTween.moveX(Palettes, -1920 * currentindex, .5f).setEase(curve);
        }
        
    }

    public void updateText()
    {
        if(buyedSkins[currentindex].owned)
        {
            TextBuy.text = "Equip!";
        }
        else
        {
            TextBuy.text = "Buy!";
        }
    }

    public void PLayUIEffect(string s)
    {
        FindObjectOfType<AudioManager>().Play(s);
    }

    public void ChangeColorToWhite(TextMeshProUGUI text)
    {
        text.color = Color.white;
    }

    public void ChangeColorToBlack(TextMeshProUGUI text)
    {
        text.color = Color.black;
    }
}

[System.Serializable]
public class PaleteColor
{
    [Header("Player")]
    public Color white;
    public Color blue;
    [Header("World")]
    public Color black;
    public Color green;
    [Header("Enemies")]
    public Color magenta;
    public Color red;
    [Header("BK")]
    public Color Background;
}