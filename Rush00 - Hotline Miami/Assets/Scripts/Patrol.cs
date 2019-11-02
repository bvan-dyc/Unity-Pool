using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	[SerializeField] private float speed = 5;
	[SerializeField] private Node currentNode = null;
	private Enemy unit;
	private Rigidbody2D rbody;
	private float tolerance = 0.1f;
	
	private void Start()
	{
		unit = GetComponent<Enemy>();
		rbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (unit.state == Enemy.EnemyState.Patrol)
		{
			float distance = Vector2.Distance((Vector2)transform.position, (Vector2)currentNode.gameObject.transform.position);
			rbody.velocity = speed * -((Vector2)transform.position - (Vector2)currentNode.gameObject.transform.position).normalized;
			Turn();
			if (distance < tolerance)
				SwitchNode();
		}
	}
	private void SwitchNode()
	{
		transform.position = currentNode.transform.position;
		currentNode = currentNode.getNextNode();
		rbody.velocity = speed * -((Vector2)transform.position - (Vector2)currentNode.gameObject.transform.position).normalized;
		Turn();
	}
	private void Turn()
	{
		Vector2 lookAtDirection = -((Vector2)currentNode.gameObject.transform.position - (Vector2)transform.position);
		float angle = -Mathf.Atan2(lookAtDirection.x, lookAtDirection.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
