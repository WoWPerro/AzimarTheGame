public class Bow : Weapon
{
     public Bow()
    {
        type = 0;
        range = 1;
        damage = 75;
        speed = 5;
    }

    public override int GetDamage()
    {
        return damage * damagelvl;
    }

    public override float GetRange()
    {
        return range + rangelvl;
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
            type = 0;
            range = 1;
            damage = 75;
            speed = 5;
        }
        else if(n == 1) //Pesado
        {
            type = n;
            range = 1;
            damage = 75;
            speed = 10;
        }
        else if(n == 2) //Cortante
        {
            type = n;
            range = 4;
            damage = 30;
            speed = 5;
        }
    }

}