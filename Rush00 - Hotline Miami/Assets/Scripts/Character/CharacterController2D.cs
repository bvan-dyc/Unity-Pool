using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterController2D : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] [Range(0, 50)] private float speed = 10.0f;
	[SerializeField] [Range(0, 50)] private float meleeDashSpeed = 30.0f;
	[SerializeField] [Range(0, 50)] private float meleeDashDuration = 0.2f;
	private Player player;
	private Rigidbody2D rbody;
    private bool dashing = false;
	private Animator animator;
	[Header("PickUp")]
	[SerializeField] private float pickUpRadius = 1f;
	[SerializeField] private LayerMask pickupLayer = 0;
	private float cspeed = 0;

	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		player = GetComponent<Player>();
		cspeed = speed;
	}

	private void Update()
	{
		lookAtMouse();
	}
	public void Move(float movementX, float movementY)
	{
        if (dashing)
            rbody.velocity = -transform.up * cspeed;
        else
        {
            rbody.velocity = new Vector2(movementX, movementY) * cspeed;
            animator.SetFloat("movementX", Mathf.Abs(movementX));
            animator.SetFloat("movementY", Mathf.Abs(movementY));
        }
	}

	public void triggerAttack()
	{
		if (player.getWeapon())
		{
		    bool attacked = player.getWeapon().Attack();
			if (attacked && player.getWeapon().getType() == Weapon.WeaponType.melee)
				meleeDash();
		}
	}
	public void meleeDash()
	{
		cspeed = meleeDashSpeed;
		rbody.velocity = -transform.up * cspeed;
		Invoke("stopDashing", meleeDashDuration);
        dashing = true;
	}

	public void stopDashing()
	{
		cspeed = speed;
        dashing = false;
	}
	public void lookAtMouse()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookAtDirection = -(mousePosition - (Vector2)transform.position);
		float angle = -Mathf.Atan2(lookAtDirection.x, lookAtDirection.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void pickUp()
	{
		Collider2D hit = Physics2D.OverlapCircle(transform.position, pickUpRadius, pickupLayer);
		if (hit)
		{
			Pickup pickup = hit.gameObject.GetComponent<Pickup>();
			if (pickup.getType() == Pickup.pickupType.weapon)
			{
				player.pickUpWeapon(((WeaponPickup)pickup).getWeapon(), pickup.gameObject);
			}
		}
	}

	public void Throw()
	{
		player.throwWeapon();
	}
}
