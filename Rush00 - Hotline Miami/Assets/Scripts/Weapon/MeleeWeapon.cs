using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	[SerializeField] private float range = 3f;
	[SerializeField] private float attackDelay_s = 0.2f;
	[SerializeField] private float nextAttackTime_s = 0;
	[SerializeField] private float attackDuration_s = 0.3f;
	[SerializeField] private Damager damager = null;
	private Rigidbody2D rbody;

	public void Start()
	{
		ammunition = int.MaxValue;
		damager.DisableDamage();
	}
	public override float getRange()
	{
		return (range);
	}
	public override Weapon.WeaponType getType()
	{
		return (Weapon.WeaponType.melee);
	}
	public override bool Attack()
	{
		if (Time.time < nextAttackTime_s)
			return (false);
		AudioManager.instance.PlayPool(shotAudio);
		nextAttackTime_s = Time.time + attackDelay_s;
		damager.EnableDamage();
		Invoke("stopAttack", attackDuration_s);
        return (true);
	}

	private void stopAttack()
	{
		damager.DisableDamage();
	}
}
