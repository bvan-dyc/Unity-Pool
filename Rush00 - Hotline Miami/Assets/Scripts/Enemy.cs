using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Death")]
	[SerializeField] private GameObject deadBody = null;
	[SerializeField] private EnemyState initialState = EnemyState.Wait;
	[HideInInspector] public EnemyState state = EnemyState.Wait;
	public bool isShooting = false;
	public Weapon weapon = null;
	[SerializeField] private float followRange = 10f;
    [SerializeField] private float followDuration = 5f;
    private Rigidbody2D rbody;
	public Transform target;
    private float followTimer = 0f;
	private float speed = 3;
	private float chaseMultiplier = 1.3f;
    private Animator animator;
	public enum EnemyState
	{
		Wait,
		Patrol,
		Chase,
	}
	public AudioClip[]	deathAudio;

	private void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		initialState = state;
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	private void Update()
	{
        animator.SetFloat("movementX", Mathf.Abs(rbody.velocity.x));
        animator.SetFloat("movementY", Mathf.Abs(rbody.velocity.y));
        if (state == Enemy.EnemyState.Chase)
		{
            followTimer += Time.deltaTime;
            if (Vector2.Distance(transform.position, target.position) > followRange || followTimer >= followDuration)
			{
				stopShooting();
				state = initialState;
                followTimer = 0;
			}
			Chase();
			TurnTowards(target);
			if (Vector2.Distance(transform.position, target.position) < weapon.getRange() + 1)
			{
				startShooting();
			}
			else
			{
				stopShooting();
			}
		}
		if (weapon && isShooting)
			weapon.Attack();
	}
	private void Chase()
	{
		if (Vector2.Distance(transform.position, target.position) > 1)
			rbody.velocity = (target.position - transform.position).normalized * speed * chaseMultiplier;
		else
			rbody.velocity = new Vector2(0, 0);
	}

	public void startShooting()
	{
		isShooting = true;
	}
	public void stopShooting()
	{
		isShooting = false;
	}

	public void OnDie()
	{
		if (deadBody)
		{
			GameObject corpse = Instantiate(deadBody);
			corpse.transform.position = transform.position;
		}
		AudioManager.instance.PlayPool(deathAudio);
		ScoreManager.instance.IncreaseScore();
		Destroy(gameObject);
	}

	private void TurnTowards(Transform lookAtTarget)
	{
		Vector2 lookAtDirection = -((Vector2)lookAtTarget.position - (Vector2)transform.position);
		float angle = -Mathf.Atan2(lookAtDirection.x, lookAtDirection.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
    public void delayShot() {
        if (weapon.getType() == Weapon.WeaponType.ranged)
            ((RangedWeapon)weapon).delayFirstShot(0.2f);
    }
}
