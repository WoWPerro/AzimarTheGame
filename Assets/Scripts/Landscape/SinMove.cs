using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    public int movementx;
    public int movementy;

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) * movementx, Mathf.Sin(Time.time) * movementy, 0);
    }
}
