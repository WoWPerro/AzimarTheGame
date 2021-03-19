using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleX : MonoBehaviour
{
    private float x;
    private float xpos;
    public AnimationCurve curve;
    public float duration = 1f;
    public float durationclose = .5f;
     // Start is called before the first frame update
    void Start()
    {
        x = gameObject.transform.localScale.x;
        xpos = gameObject.transform.position.x;
        LeanTween.scaleX(gameObject, 0, 0);
    }

    public void ScaleDown()
    {
        LeanTween.scaleX(gameObject, 0, duration).setEase(curve);
    }

    public void ScaleUp()
    {
        LeanTween.scaleX(gameObject, x, duration).setEase(curve);
    }
}
