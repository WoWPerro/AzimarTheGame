using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public Vector2 player;
    public float vel = 1000;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(player * vel);
        StartCoroutine("WaitAndPrint");
    }

    void OnEnable()
    {
        rb.AddForce(player * vel);
        StartCoroutine("WaitAndPrint");
    }

     IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(transform.forward, 1);;
    }
}
