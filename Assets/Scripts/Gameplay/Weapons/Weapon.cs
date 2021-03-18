using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ability
{
    DAMAGE,
    SPEED,
    RANGE
}

public abstract class Weapon
{
    public int type;
    public float range;
    public int rangelvl = 1;
    public int damage;
    public int damagelvl = 1;
    public float speed;
    public int speedlvl = 1;
    public abstract int GetDamage();
    public abstract float GetRange();
    public abstract float GetSpeed();
    public abstract void Upgrade(ability a);
    public abstract void ChangeType(int n);
}
