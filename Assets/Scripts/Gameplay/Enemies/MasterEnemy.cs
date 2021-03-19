using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEnemy : MonoBehaviour
{
    public Enemy enemy;
    public EnemyType enemyType;
    public GameObject player;
    public GameObject cameragame;

    public float Mass = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 4;
    private Vector3 velocity;

    void Awake()    
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameragame = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Start is called before the first frame update
    void Start()
    {
        switch(enemyType)
        {
            case EnemyType.FOLLOWER:
                    enemy = new Follower(1);
                break;
        }

        velocity = Vector3.zero;
        MaxVelocity = enemy.speed;
    }

    private void Update() 
    {
        if(!enemy.isAlive)
        {
            gameObject.SetActive(false);
            player.GetComponent<PlayerController>().Exp += (int)enemy.rewardExp;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("ME PEGARON");
        if(other.tag == "Weapon")
        {
            enemy.Damage(player.GetComponent<PlayerController>().currentWeapon.GetDamage());         
        }
    } 

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().DealDamageToPlayer((int)enemy.GetDamage());
            cameragame.GetComponent<CameraShake>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
