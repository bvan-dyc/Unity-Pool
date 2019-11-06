using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] private int detectRadius = 15;
	[SerializeField] private int attackRadius = 5;
	[SerializeField] private float attackDelay = 3;
	[SerializeField] private float nextAttackTime = 0;
	private GameObject player;
	[SerializeField] private Collider col ;
	private NavMeshAgent agent;
	private Animator animator;
	private enemyStates state = enemyStates.idle;
	private CharacterData data;
	private enum enemyStates
	{
		idle,
		chase,
		attack,
		dead
	}
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		animator = GetComponent<Animator>();
		data = GetComponent<CharacterData>();
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		if (distanceToPlayer < detectRadius)
			transform.LookAt(player.transform.position);
		if (distanceToPlayer < attackRadius && state != enemyStates.dead)
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
			if (distanceToPlayer < detectRadius)
			{
				animator.SetBool("attack", false);
				animator.SetBool("run", true);
				agent.SetDestination(player.transform.position);
			}
			else
			{
				animator.SetBool("attack", false);
				animator.SetBool("run", false);
				agent.isStopped = true;
				agent.ResetPath();
			}
		}
	}

	public void DealDamage()
	{
		player.GetComponent<Damageable>().takeHit(data.computeDamage(), data.computeHitChance());
	}

	public void OnDeath()
	{
		agent.isStopped = true;
		agent.ResetPath();
		agent.enabled = false;
		col.enabled = false;
		state = enemyStates.dead;
		player.GetComponent<CharacterData>().xp += data.xp;
		StartCoroutine(DeathCoroutine());
	}

	IEnumerator DeathCoroutine()
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
