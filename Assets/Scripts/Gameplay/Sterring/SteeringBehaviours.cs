using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringData
{
	public Vector3 linear;
	public float angular;
	public SteeringData()
	{
		linear = Vector3.zero;
		angular = 0f;
	}
}

public class SteeringBehaviours : MonoBehaviour
{
	MasterEnemy enemyref;
	private Rigidbody2D rb;
	private Steering[] steerings;
	public float maxAcceleration = 10f;
	public float maxAngularAcceleration = 3f;
	public float drag = .5f;
	void Start()
	{
		enemyref = GetComponent<MasterEnemy>();
		rb = GetComponent<Rigidbody2D>();
		steerings = GetComponents<Steering>();
		rb.drag = drag;	
		maxAcceleration = enemyref.enemy.speed;
		maxAngularAcceleration = maxAcceleration/3;
	}

	void FixedUpdate()
	{
		Vector3 accelaration = Vector3.zero;
		float rotation = 0f;
		foreach (Steering behavior in steerings)
		{
			SteeringData steering = behavior.GetSteering(this);
			accelaration += steering.linear;
			rotation += steering.angular;
		}
		if (accelaration.magnitude > maxAcceleration)
		{
			accelaration.Normalize();
			accelaration *= maxAcceleration;
		}
		rb.AddForce(accelaration);
		
		Vector2 moveDirection = rb.velocity;
		moveDirection.Normalize();
        if 	(moveDirection != Vector2.zero) 
		{
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
        }
	}
}

