using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Unit : MonoBehaviour {
	[Range(0f, 10f)] public float speed = 0.5f;
	[Range(1, 100)] public int	attackPower = 5;
	[Range(0.1f, 30f)] float attackDelay = 0.5f;
	public LayerMask enemyLayer;
	public float attack_range = 1f;
	public float epsilon = 0.3f;
	public bool canAttack = true;
	public bool isPlayer = true;
	[HideInInspector] public float selected = 0;
	[HideInInspector] public bool isMoving = false;
	private float attackTimer_s = 0.0f;
	private bool attackOrder = false;
	public GameObject target;
	private Vector3 targetPosition;
	private AudioSource footsteps;
	private Animator animator;
	private float TOLERANCE = 0.5f;
	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
		animator = GetComponent<Animator>();
		footsteps = GetComponent<AudioSource>();
		animator.SetBool("down", true);
		animator.SetBool("right", true);
	}

	// Update is called once per frame
	void Update()
	{
		if (attackOrder && target)
		{
			targetPosition = target.transform.position;
			computeDirection(targetPosition);
		}
		if (isPlayer && Input.GetMouseButtonDown(0) && selected == 1)
		{
			var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray, transform.position);
			if (hit && hit.collider.gameObject.tag == "Enemy")
			{
				target = hit.collider.gameObject;
				attackOrder = true;
				startMoving();
			}
			else if (!hit || !(hit.collider.tag == "Ally"))
			{
				targetPosition = ray;
				targetPosition.z = transform.position.z;
				attackOrder = false;
				startMoving();
			}
		}
		if (isMoving)
		{
			Move();
		}
		else if (canAttack && attackTimer_s <= 0)
			Attack();
		if (isMoving && Vector3.Distance(transform.position, targetPosition) <= TOLERANCE)
		{
			stopMoving();
		}
		attackTimer_s -= Time.deltaTime;
		if (selected == 2)
			selected = 1;
	}

	void startMoving()
	{
		isMoving = true;
		animator.SetBool("running", true);
		footsteps.Play();
		computeDirection(targetPosition);
	}

	void stopMoving()
	{
		isMoving = false;
		animator.SetBool("running", false);
		footsteps.Stop();
	}
	private void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
	}

	void computeDirection(Vector3 targetPosition)
	{
		Vector3 direction = (targetPosition - transform.position).normalized;
		if (direction.y > epsilon)
		{
			animator.SetBool("up", true);
			animator.SetBool("down", false);
		}
		else if (direction.y < -epsilon)
		{
			animator.SetBool("up", false);
			animator.SetBool("down", true);
		}
		else
		{
			animator.SetBool("up", false);
			animator.SetBool("down", false);
		}
		if (direction.x > epsilon)
		{
			animator.SetBool("right", true);
			animator.SetBool("left", false);
		}
		else if (direction.x < -epsilon)
		{
			animator.SetBool("right", false);
			animator.SetBool("left", true);
		}
		else
		{
			animator.SetBool("right", false);
			animator.SetBool("left", false);
		}
	}

	private void Attack()
	{
		if (target && Vector3.Distance(transform.position, target.transform.position) <= attack_range)
		{
			stopMoving();
			animator.SetTrigger("attack");
			target.GetComponent<Damageable>().takeDamage(attackPower);
		}
		else if (target && Vector3.Distance(transform.position, target.transform.position) <= attack_range)
		{
			startMoving();
		}
		else if (!target || target.GetComponent<Damageable>().currentHealth == 0)
		{
			attackOrder = false;
		}
		attackTimer_s = attackDelay;
	}
}
