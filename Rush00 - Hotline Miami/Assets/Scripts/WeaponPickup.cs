using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
	[SerializeField] private Weapon pickUpWeapon = null;
	[SerializeField] private float deceleration = 3;
	[SerializeField] private bool spinOnThrow = true;
	[SerializeField] private GameObject spriteToRotate = null;
	[SerializeField] private float spinSpeed = 180;
	[SerializeField] private Damager damager = null;
	[SerializeField] private bool canDamage = false;
	private Rigidbody2D rbody;
	private float strength;
	private Vector2 direction;
	private void Awake()
	{
		type = pickupType.weapon;
		rbody = GetComponent<Rigidbody2D>();
		if (canDamage && damager)
		{
			damager.DisableDamage();
		}
	}

	private void Update()
	{
        if (strength > 0)
        {
            if (spinOnThrow)
                spriteToRotate.transform.Rotate(Vector3.forward * spinSpeed * strength * Time.deltaTime);
            rbody.velocity = direction * strength;
            strength -= deceleration * Time.deltaTime;
            if (strength <= 0)
                rbody.velocity *= 0;
        }
        else if (strength < 1 && canDamage && damager)
        {
            damager.DisableDamage();
            gameObject.layer = LayerMask.NameToLayer("Pickup");
        }
	}
	public Weapon getWeapon()
	{
		return (pickUpWeapon);
	}

	public void Throw(Vector2 throwDirection, float throwStrength, bool throwCanDamage = false)
	{
		direction = throwDirection;
		strength = throwStrength;
		if (throwCanDamage && damager)
		{
            gameObject.layer = LayerMask.NameToLayer("PlayerBullet");
			canDamage = throwCanDamage;
			damager.EnableDamage();
		}
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }
}
