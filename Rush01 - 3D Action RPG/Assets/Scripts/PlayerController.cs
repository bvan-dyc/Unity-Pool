using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject target;
	[SerializeField] private float attackRadius = 5;
	[SerializeField] private float attackDelay = 3;
	[SerializeField] private float nextAttackTime = 0;
	[SerializeField] private float castingDuration = 1f;

	private static PlayerController _instance;
	private Animator animator;
	private NavMeshAgent agent;
	private ManaPool manaPool;
	private Hero character;
	public PlayerState state = PlayerState.idle;
	public enum PlayerState
	{
		chase,
		attacking,
		idle,
		casting,
	}
	public static PlayerController instance
	{
		get
		{
			if (PlayerController._instance == null)
			{
				PlayerController._instance = UnityEngine.Object.FindObjectOfType<PlayerController>();
				if (PlayerController._instance == null)
				{
					UnityEngine.Debug.LogError("Couldn't find a Hero, make sure one exists in the scene.");
				}
				else
				{
					UnityEngine.Object.DontDestroyOnLoad(PlayerController._instance.gameObject);
				}
			}
			return (PlayerController._instance);
		}
	}
	private void Start()
	{
		character = GetComponent<Hero>();
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		manaPool = GetComponent<ManaPool>();
	}

	private void Update()
	{
		if (agent.velocity.magnitude < 0.15)
			animator.SetBool("run", false);
		else
			animator.SetBool("run", true);
		if (target)
		{
			transform.LookAt(target.transform.position);
			float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
			if (distanceToTarget <= attackRadius)
			{
				animator.speed = character.data.attackSpeed;
				if (Time.time > nextAttackTime)
				{
					animator.SetBool("attack", true);
					agent.isStopped = true;
					agent.ResetPath();
					nextAttackTime = Time.time + attackDelay;
				}
			}
			else
			{
				animator.SetBool("attack", false);
				animator.speed = 1;
			}
		}
		else
			animator.SetBool("attack", false);
	}
	public void moveTo(Vector3 newDestination)
	{
		if (state == PlayerState.casting)
			return;
		transform.LookAt(newDestination);
		agent.destination = newDestination;
	}
	public void DealDamage()
	{
		if (!target)
			return;
		if (target.GetComponent<Damageable>().currentHealth > 0)
		{
			target.GetComponent<Damageable>().TakeDamage(character.computeDamage(), character.computeHitChance());
		}
		if (target.GetComponent<Damageable>().currentHealth <= 0)
		{
			resetTarget();
		}
		if (!Input.GetMouseButton(0))
		{
			resetTarget();
		}
	}

	public void TriggerSkill(int index)
	{
		if (index > 0 && index < character.activeSkills.Length)
		{
			if (manaPool.SpendMana(character.activeSkills[index].GetComponent<ActiveSkill>().cost))
			{
				state = PlayerState.casting;
				agent.isStopped = true;
				agent.ResetPath();
				character.activeSkills[index].GetComponent<ActiveSkill>().target = target;
				character.activeSkills[index].GetComponent<ActiveSkill>().Activate();
				if (character.activeSkills[index].GetComponent<ActiveSkill>().activeType != ActiveSkill.activeSkillType.AOE)
				{
					Invoke("EndCasting", castingDuration);
				}
			}
		}
	}

	public void EndCasting()
	{
		state = PlayerState.idle;
	}
	public GameObject getTarget()
	{
		return (target);
	}
	public void setTarget(GameObject newTarget)
	{
		target = newTarget;
		transform.LookAt(newTarget.transform.position);
		if (state != PlayerState.casting)
		{
			agent.destination = newTarget.transform.position;
		}
	}
	public void resetTarget()
	{
		agent.isStopped = true;
		agent.ResetPath();
		target = null;
	}
	public void OnDie()
	{
		animator.SetTrigger("death");
		agent.isStopped = true;
		agent.ResetPath();
		target = null;
	}
	// CHEATS
	public void forceLevelUp()
	{
		character.LevelUp();
	}
	public void makeInvincible()
	{
		GetComponent<Damageable>().toggleInvulnerability();
		manaPool.toggleInfiniteMana();
	}
	public void Respawn(Vector3 respawnLocation)
	{
		agent.isStopped = true;
		agent.ResetPath();
		target = null;
		transform.position = respawnLocation;
		GetComponent<Damageable>().SetHealth(character.data.maxHP);
		character.data.xp = 0;
		character.data.credits = 0;
		// animator.settrigger("respawn");
	}
}
