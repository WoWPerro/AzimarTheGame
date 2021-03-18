public class Sword : Weapon
{
    public Sword()
    {
        type = 0;
        range = 2;
        damage = 50;
        speed = 10;
    }

    public override int GetDamage()
    {
        return damage * damagelvl;
    }

    public override float GetRange()
    {
        return range + (rangelvl/2);
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
        if(n == 0) //Estándart
        {
            type = n;
            range = 2;
            damage = 50;
            speed = 10;
        }
        else if(n == 1) //Pesado
        {
            type = n;
            range = 2;
            damage = 75;
            speed = 15;
        }
        else if(n == 2) //Cortante
        {
            type = n;
            range = 10;
            damage = 30;
            speed = 10;
        }
    }
}
