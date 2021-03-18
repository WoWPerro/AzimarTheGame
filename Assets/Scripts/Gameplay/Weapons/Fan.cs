public class Fan : Weapon
{
    public Fan()
    {
        type = 0;
        range = 10;
        damage = 25;
        speed = 5;
    }

    public override int GetDamage()
    {
        return damage * damagelvl;
    }

    public override float GetRange()
    {
        return range + (rangelvl/10);
    }

    public override float GetSpeed()
    {
        return speed * speedlvl;
    }

    public override void Upgrade(ability a)
    {
        if(a == ability.DAMAGE)
        {
            damagelvl++;
        }
        else if(a == ability.SPEED)
        {
            speedlvl++;
        }
        else if(a == ability.RANGE)
        {
            rangelvl++;
        }
    }

     public override void ChangeType(int n)
    {
        if(n == 0) //Veloz
        {
            type = 0;
            range = 10;
            damage = 25;
            speed = .5f;
        }
        else if(n == 1) //Fino
        {
            type = n;
            range = 1;
            damage = 75;
            speed = 10;
        }
        else if(n == 2) //Enorme
        {
            type = n;
            range = 10;
            damage = 30;
            speed = 5;
        }
    }
}
