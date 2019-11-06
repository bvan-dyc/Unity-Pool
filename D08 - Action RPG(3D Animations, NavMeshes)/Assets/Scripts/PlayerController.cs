using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[Header("Sliders")]
	[SerializeField] private Slider xpSlider = null;
	[SerializeField] private Text xptext = null;
	[SerializeField] private Text lvltext = null;
	private Animator animator;
	private NavMeshAgent agent;
	public GameObject target;
	[SerializeField] private float attackRadius = 5;
	[SerializeField] private float attackDelay = 3;
	[SerializeField] private float nextAttackTime = 0;
	private CharacterData data;
	private bool interrupt = false;

	private void Start()
	{
		data = GetComponent<CharacterData>();
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		xptext.text = data.xp + " / " + data.xpToNextLevel;
		lvltext.text = data.level.ToString();
	}

	private void FixedUpdate()
	{
		xptext.text = data.xp + " / " + data.xpToNextLevel;
		if (agent.remainingDistance < agent.stoppingDistance && animator.GetBool("run") == true)
		{
			animator.SetBool("run", false);
		}
		if (target)
		{
			transform.LookAt(target.transform.position);
			float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
			if (distanceToTarget <= attackRadius)
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
		}
	}
	public void moveTo(Vector3 newDestination)
	{
		transform.LookAt(newDestination);
		agent.destination = newDestination;
		animator.SetBool("run", true);
	}

	public void setTarget(GameObject newTarget)
	{
		target = newTarget;
		transform.LookAt(newTarget.transform.position);
		agent.destination = newTarget.transform.position;
		animator.SetBool("run", true);
	}
	public void DealDamage()
	{
		if (target && target.GetComponent<Damageable>().dead != true)
		{
			target.GetComponent<Damageable>().takeHit(data.computeDamage(), data.computeHitChance());
		}
		if (target && target.GetComponent<Damageable>().dead == true)
		{
			resetTarget();
		}
		if (!Input.GetMouseButton(0))
			resetTarget();
	}

	public void resetTarget()
	{
		animator.SetBool("attack", false);
		animator.SetBool("run", false);
		agent.isStopped = true;
		agent.ResetPath();
		target = null;
	}
}
