using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Steering
{
	[SerializeField] private GameObject target;
	public override SteeringData GetSteering(SteeringBehaviours steeringbase)
	{
		MasterEnemy enemyref = GetComponent<MasterEnemy>();
		target = enemyref.player;
		SteeringData steering = new SteeringData();
		steering.linear = target.transform.position - transform.position;
		steering.linear.Normalize();
		steering.linear *= steeringbase.maxAcceleration;
		steering.angular = 0;
		return steering;

	}
}
