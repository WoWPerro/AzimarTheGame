using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDelay : MonoBehaviour
{
    private float rotation;
    private Vector3 scale;
    public float delay;
    void Start()
    {
        rotation = gameObject.transform.rotation.z;
        scale = gameObject.transform.localScale;
    }

    void OnEnable()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector2(0,0), 0f);
        LeanTween.rotateZ(gameObject, 45, 0f);
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), scale, .5f).setEaseInOutSine().setDelay(delay);
        LeanTween.rotateZ(gameObject, rotation, .5f).setEaseInOutSine().setDelay(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
