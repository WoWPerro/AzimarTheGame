using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCanvas : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public AnimationCurve curve;
    private Vector3 pos;
    private Vector3 scale;
    RectTransform rectTransform;

    void Start()
    {   
        scale = gameObject.transform.localScale;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector2(0,0), 0f);
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), scale, .5f).setEase(curve).setOnComplete(EnebleChilds);
        //gameObject.LeanScaleX(1,1).setEase(curve);
        //gameObject.LeanScaleY(1,1).setEase(curve).setOnComplete(EnebleChilds);
    }

    void OnDisable()
    {

    }

    void EnebleChilds()
    {
        foreach(GameObject g in objectsToActivate)
        {
            g.SetActive(true);
        }
    }
}
