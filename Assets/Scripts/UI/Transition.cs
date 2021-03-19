using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public AnimationCurve curve;
    int sceneindex;
    public void ChangeScene(int index)
    {
        sceneindex = index;
        LeanTween.scaleX(gameObject, 3, 1f).setEase(curve).setOnComplete(TransitionScene);
    }

    void TransitionScene()
    {
        FindObjectOfType<LevelManager>().LoadSceneAsync(sceneindex);
    }
}
