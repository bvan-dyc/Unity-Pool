using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTank : MonoBehaviour
{
	[SerializeField] public CannonController canon;
	[SerializeField] private float detectRadius = 200f;
	public GameObject nearestTarget;
	private float distanceToTarget = 0f;

    // Update is called once per frame
    void Update()
    {
		Collider[] colliders = Physics.OverlapSphere(transform.position, detectRadius, 1 << 9);
		foreach (Collider enemy in colliders)
		{
			float distance = Vector3.Distance(transform.position, enemy.gameObject.transform.position);
			if ((!nearestTarget || distance < distanceToTarget) && distance > 8)
			{
				distanceToTarget = distance;
				nearestTarget = enemy.gameObject;
				canon.lookAtTarget(nearestTarget.transform);
				GetComponent<NavMeshAgent>().destination = nearestTarget.transform.position;
			}
		}
		if (nearestTarget && distanceToTarget < canon.range)
		{
			canon.Shoot(true);
		}
	}

	public void Shoot(bool isRocket)
	{
		canon.Shoot(isRocket);
	}
}
