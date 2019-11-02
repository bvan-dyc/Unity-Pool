using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
	[SerializeField] private Enemy unit = null;
	[SerializeField] private float detectRange = 8f;
	[SerializeField] private float detectAngle = 20f;

	private void Update()
	{
		Vector2 directionToTarget = unit.target.position - transform.position;
		float angle = Vector2.Angle(directionToTarget, -Vector2.up);
		float distance = Vector2.Distance(unit.target.position, transform.position);
		if (unit.state != Enemy.EnemyState.Chase && angle < detectAngle && distance < detectRange)
		{
			if (Physics2D.Raycast(transform.position, directionToTarget))
				unit.state = Enemy.EnemyState.Chase;
		}
	}
}
