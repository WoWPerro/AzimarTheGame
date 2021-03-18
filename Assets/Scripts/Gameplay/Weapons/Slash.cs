using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    public GameObject player;
    public GameObject startpoint;
    private float sum = 0;
    public float speed = 1000;
    private bool left = true;
    // Update is called once per frame
    void Update()
    {
        if(left)
        {
            transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
            sum += speed*Time.deltaTime;
            if(sum >= 180)
            {
                transform.position = startpoint.transform.position;
                //transform.RotateAround(player.transform.position, Vector3.forward, -90);
                float range = player.GetComponent<PlayerController>().currentWeapon.GetRange()*.05f;
                transform.localScale = new Vector3(range, range, 1);
                WithForLoop();
                setRandom();
                this.gameObject.SetActive(false);
                sum = 0;
            }
        }
        else
        {
            transform.RotateAround(player.transform.position, -Vector3.forward, speed * Time.deltaTime);
            sum += speed*Time.deltaTime;
            if(sum >= 180)
            {
                transform.position = startpoint.transform.position;
                float range = player.GetComponent<PlayerController>().currentWeapon.GetRange()*.05f;
                transform.localScale = new Vector3(range, range, 1);
                WithForLoop();
                setRandom();
                this.gameObject.SetActive(false);
                sum = 0;
            }
        }
    }

    void setRandom()
    {
        int r = Random.Range(0,2);
        if(r == 0)
        {
            left = true;
            transform.RotateAround(player.transform.position, Vector3.forward, -90);
        }
        else
        {
            left = false;
            transform.RotateAround(player.transform.position, Vector3.forward, 90);
        }
    }

    void WithForLoop()
     {
         int children = transform.childCount;
         float range = player.GetComponent<PlayerController>().currentWeapon.GetRange();
         for (int i = 0; i < children; ++i)         
            transform.GetChild(i).localScale = new Vector3(range, range, 1);
     }
}
