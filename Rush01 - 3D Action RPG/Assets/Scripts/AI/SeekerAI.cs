using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeekerAI : MonoBehaviour
{
	[SerializeField] [Range(1, 100)] private int detectRadius = 15;
	[SerializeField] [Range(1, 15)] private int attackRadius = 5;
	[SerializeField] [Range(0, 10)] private float attackDelay = 3;
	[SerializeField] [Range(0, 10)] private float nextAttackTime = 0;
	[SerializeField] private Collider[] colliders = null;

	private GameObject player;
	private NavMeshAgent agent;
	private Animator animator;
	private enemyStates state = enemyStates.idle;
	private Enemy enemy;
	private enum enemyStates
	{
		idle,
		chase,
		attack,
		dead
	}
	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		animator = GetComponent<Animator>();
		enemy = GetComponent<Enemy>();
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (state == enemyStates.dead)
			return;
		float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		if (distanceToPlayer < detectRadius)
			transform.LookAt(player.transform.position);
		if (distanceToPlayer < attackRadius)
		{
			if (Time.time > nextAttackTime)
			{
				animator.SetBool("attack", true);
				animator.SetBool("run", false);
				agent.isStopped = true;
				agent.ResetPath();
				nextAttackTime = Time.time + attackDelay;
			}
		}
		else if (state == enemyStates.idle && distanceToPlayer < detectRadius)
		{
			state = enemyStates.chase;
		}
		else if (state == enemyStates.chase)
		{
			animator.SetBool("attack", false);
			if (distanceToPlayer < detectRadius)
			{
				animator.SetBool("run", true);
				agent.SetDestination(player.transform.position);
			}
			else
			{
				state = enemyStates.idle;
				animator.SetBool("run", false);
				agent.isStopped = true;
				agent.ResetPath();
			}
		}
	}

	public void DealDamage()
	{
		player.GetComponent<Damageable>().TakeDamage(enemy.computeDamage(), enemy.computeHitChance());
	}

	public void OnDeath()
	{
		animator.SetTrigger("death");
		agent.isStopped = true;
		agent.ResetPath();
		agent.enabled = false;
		foreach (Collider collider in colliders)
		{
			collider.enabled = false;
		}
		state = enemyStates.dead;
		player.GetComponent<Hero>().GainXP(enemy.data.xp);
		StartCoroutine(SinkRoutine());
	}

	IEnumerator SinkRoutine()
	{
		yield return new WaitForSeconds(2);
		for (int i = 0; i < 20; i++)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
			yield return new WaitForSeconds(0.1f);
		}
		Destroy(gameObject);
	}
}
