using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    FOLLOWER,
    RANGER,
    MAGICIAN,
    EVOKER,
    BOSS1,
}

public abstract class Enemy
{
    public float health;
    public float MaxHealth;
    public float speed;
    public float rewardExp;
    public bool isAlive = true;
    public EnemyType enemyType;
    public float damage;

    public abstract float GetDamage();

    public void Damage(int dm)
    {
        health = health - dm;
        if(health <= 0)
        {
            isAlive = false;
        }
    }
}
