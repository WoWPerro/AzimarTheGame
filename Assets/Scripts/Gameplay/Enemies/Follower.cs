using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Enemy
{
    public Follower(int level)
    {
        health = 1;
        MaxHealth = 1;
        speed = 6 * level;
        rewardExp = 15;
        isAlive = true;
        enemyType = EnemyType.FOLLOWER;
        damage = level * damage;
    }

    public override float GetDamage()
    {
        return damage;
    }

}
