using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
	[Header("Shooting")]
	[SerializeField] private GameObject bullet = null;
	[SerializeField] private float bulletSpeed = 10f;
	[SerializeField] private float range = 20f;
	[SerializeField] private float shootDelay_s = 0.2f;
	[SerializeField] private float nextShotTime_s = 0;
	[SerializeField] private Transform caster = null;
	public bool infiniteAmmo = false;

	void Start() {
		ammunition = 15;
	}
	public override float getRange()
	{
		return (range);
	}

    public void delayFirstShot(float amount_s) {
        nextShotTime_s += amount_s;
    }
	public override Weapon.WeaponType getType()
	{
		return (Weapon.WeaponType.ranged);
	}
	public override bool Attack()
	{
		if (Time.time < nextShotTime_s)
			return false;
		int bulletCost = bullet.GetComponent<Bullet>().getCost();
		if (ammunition < bulletCost)
		{
			return false;
		}
		if (!infiniteAmmo)
			ammunition -= bulletCost;
		AudioManager.instance.PlayPool(shotAudio);
		GameObject newBullet = Instantiate(bullet);
		bullet.GetComponent<Bullet>().setLongevity_s(range / bulletSpeed);
		newBullet.layer = gameObject.layer;
		newBullet.transform.position = caster.position;
		newBullet.GetComponent<Rigidbody2D>().velocity = -transform.up * bulletSpeed;
		nextShotTime_s = Time.time + shootDelay_s;
		float angle = Mathf.Atan2(-transform.up.x, -transform.up.y) * Mathf.Rad2Deg;
		newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return true;
	}
}
