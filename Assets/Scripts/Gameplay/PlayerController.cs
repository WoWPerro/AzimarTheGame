using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character Atributtes")]
    public float MOVEMENT_BASE_SPEED = 1;
    public float MOVEMENT_DASH_SPEED = 1;
    [Space]
    [Header("Characer Statics:")]
    public Vector2 movementDirection;
    public float movementSpeed;
    [Space]
    public float attackRange;

    public int Exp;
    private int health;
    private int maxHealth;
    
    [Space]
    [Header("References")]
    public Rigidbody2D rb;
    public Transform attackPoint;
    public GameObject swordEffect;
    public GameObject Menu;
    private bool menuactive = false;

    private bool dashing = false;

    [Space]
    [Header("References weapons")]
    public Weapon currentWeapon;
    Bow Bow;
    Sword Sword;
    Fan Fan;
    private List<GameObject> BulletPool;
    public GameObject bullet;
    //public GameObject BulletParent;


    // Start is called before the first frame update
    void Start()
    {
        Bow = new Bow();
        Sword = new Sword();
        Fan = new Fan();
        currentWeapon = Sword;
        Exp = 10000;
        BulletPool = new List<GameObject>();
        maxHealth = 100;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
        Dash();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        //Check Dash
        if(Input.GetKeyDown(KeyCode.Space))
        {
            dashing = true;
        }

         //Check Atack
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            menuactive = !menuactive;
            Menu.SetActive(menuactive);
        }

        // if(Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     SwapWeapon(1);
        // }

        // if(Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     SwapWeapon(2);
        // }

        // if(Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     SwapWeapon(3);
        // }
    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Rotate()
    {
        Vector2 moveDirection = rb.velocity;
         if (moveDirection != Vector2.zero) {
             float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         }
    }

    void Dash()
    {
        if(dashing)
        {
            rb.AddForce(movementDirection * MOVEMENT_DASH_SPEED);
            dashing = false;
        }
    }

    void Attack()
    {
        //Espada
        if(currentWeapon == Sword)
        {
            //float xd = swordEffect.transform.position.x;
            //float yd = swordEffect.transform.position.y;
            //float zd = swordEffect.transform.position.z;
            //yd -= (currentWeapon.GetRange()/10);
            //swordEffect.transform.position = new Vector3(xd,yd,zd);
            swordEffect.SetActive(true);
        }
        else if (currentWeapon == Bow)
        {
            if(BulletPool.Count < 30)
            {
                //GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity, BulletParent.transform);
                GameObject bull = Instantiate(bullet, attackPoint.position, Quaternion.identity);
                bull.transform.localScale = new Vector3(currentWeapon.GetRange() * 0.1f, currentWeapon.GetRange() * 0.1f, 1);
                bull.GetComponent<Proyectile>().player = gameObject.transform.right;
                ScaleChilds(bull, 0.5f);
                BulletPool.Add(bull);
            }
            else
            {
                foreach(GameObject g in BulletPool)
                {
                    if(!g.activeSelf)
                    {
                        g.transform.position = attackPoint.position;
                        g.transform.localScale = new Vector3(currentWeapon.GetRange() * 0.1f, currentWeapon.GetRange() * 0.1f, 1);
                        g.GetComponent<Proyectile>().player = gameObject.transform.right;
                        ScaleChilds(g, 0.5f);
                        g.SetActive(true);
                        break;
                    }
                }
            }
           
        }
        else if(currentWeapon == Fan)
        {

        }
        
    }

    void ScaleChilds(GameObject g, float modifier)
     {
         int children = g.transform.childCount;
         float range = currentWeapon.GetRange();
         for (int i = 0; i < children; ++i)         
            g.transform.GetChild(i).localScale = new Vector3(range * modifier, range * modifier, 1);
     }

    public void UpgradeCurrentWeapon(int a)
    {
        switch(a)
        {
            case 1:
                if(Exp >= currentWeapon.damagelvl*50)
                {
                    Exp -= currentWeapon.damagelvl*50;
                    currentWeapon.Upgrade(ability.DAMAGE);
                    Debug.Log("Mejoraste Daño: " + currentWeapon.damagelvl);
                    Debug.Log("GetDamage(): " + currentWeapon.GetDamage());
                    //Debug.Log(Exp);
                }
                break;
            case 2:
                if(Exp >= currentWeapon.speedlvl*50)
                {
                    Exp -= currentWeapon.speedlvl*50;
                    currentWeapon.Upgrade(ability.SPEED);
                    Debug.Log("Mejoraste Velocidad: " + currentWeapon.speedlvl);
                    Debug.Log("GetSpeed(): " + currentWeapon.GetSpeed());
                    //Debug.Log(Exp);
                }
                break;
            case 3:
                if(Exp >= currentWeapon.rangelvl*50)
                {
                    if(currentWeapon == Sword)
                    {
                        attackPoint.position = gameObject.transform.position + gameObject.transform.right * currentWeapon.GetRange()/2;
                    }
                    

                    Exp -= currentWeapon.rangelvl*50;
                    currentWeapon.Upgrade(ability.RANGE);
                    Debug.Log("Mejoraste Rango: " + currentWeapon.rangelvl);
                    Debug.Log("GetRange(): " + currentWeapon.GetRange());
                    //Debug.Log(Exp);
                }
                break;
        }
    }

    public void SwapWeapon(int a)
    {
        switch(a)
        {
            case 1:
                    currentWeapon = Sword;
                    Debug.Log("Sword, DMGLVL: " + currentWeapon.GetDamage() + " SPEEDLVL: " + currentWeapon.GetSpeed() + " RANGELVL: " + currentWeapon.GetRange());
                    attackPoint.position = gameObject.transform.position + gameObject.transform.right * currentWeapon.GetRange()/2;
                break;
            case 2:
                    currentWeapon = Bow;
                    Debug.Log("Bow, DMGLVL: " + currentWeapon.GetDamage() + " SPEEDLVL: " + currentWeapon.GetSpeed() + " RANGELVL: " + currentWeapon.GetRange());
                    attackPoint.position = gameObject.transform.position + gameObject.transform.right * .8f;
                break;
            case 3:
                    currentWeapon = Fan;
                    Debug.Log("Fan, DMGLVL: " + currentWeapon.GetDamage() + " SPEEDLVL: " + currentWeapon.GetSpeed() + " RANGELVL: " + currentWeapon.GetRange());
                break;
        }
       
    }

    public void SwapAspect(int a)
    {
        switch(a)
        {
            case 1:
                    currentWeapon.ChangeType(0);
                    Debug.Log("Current Tyoe: " + currentWeapon.type);
                break;
            case 2:
                    currentWeapon.ChangeType(1);
                    Debug.Log("Current Tyoe: " + currentWeapon.type);
                break;
            case 3:
                    currentWeapon.ChangeType(2);
                    Debug.Log("Current Tyoe: " + currentWeapon.type);
                break;
        }
    }

    public void DealDamageToPlayer(int damage)
    {
        health -= damage;
    }
}
