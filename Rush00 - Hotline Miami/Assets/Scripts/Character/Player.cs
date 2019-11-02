using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[Header("Weapon")]
	[SerializeField] private GameObject currentWeapon = null;
    [SerializeField] private GameObject deadBody = null;
    [SerializeField] private Transform weaponHolder = null;
	[SerializeField] private float throwingStrength = 10;
    [SerializeField] private GameObject sprites = null;
	private GameObject throwableWeapon;
	[Header("Score")]
	public bool dead = false;
	public bool win = false;
	public AudioClip[] deathAudio;
	public AudioClip pickUpAudio;

	public void Start()
	{
		if (currentWeapon)
		{
			GameObject weapon = Instantiate(currentWeapon.gameObject, transform);
			weapon.transform.position = weaponHolder.transform.position;
			weapon.transform.rotation = transform.rotation;
			currentWeapon = weapon;
		}
	}
	public Weapon getWeapon()
	{
		if (currentWeapon)
			return (currentWeapon.GetComponent<Weapon>());
		else
			return null;
	}

	public void pickUpWeapon(Weapon newWeapon, GameObject weaponPickup)
	{
		AudioManager.instance.Play(pickUpAudio, false, false, 1f);
		if (currentWeapon)
		{
			throwableWeapon.SetActive(true);
			throwableWeapon.transform.position = weaponHolder.transform.position;
			Destroy(currentWeapon.gameObject);
			currentWeapon = null;
			throwableWeapon = null;
		}
		currentWeapon = Instantiate(newWeapon.gameObject, transform);
		currentWeapon.name = newWeapon.gameObject.name;
		currentWeapon.transform.position = weaponHolder.transform.position;
		currentWeapon.transform.rotation = transform.rotation;
		currentWeapon.layer = LayerMask.NameToLayer("PlayerBullet");
		throwableWeapon = weaponPickup;
		throwableWeapon.SetActive(false);
	}

	public void throwWeapon()
	{
		if (currentWeapon)
		{
			throwableWeapon.SetActive(true);
			throwableWeapon.transform.position = weaponHolder.transform.position;
			throwableWeapon.transform.rotation = transform.rotation;
			throwableWeapon.GetComponent<WeaponPickup>().Throw(-transform.up, throwingStrength, currentWeapon.GetComponent<Weapon>().getType() == Weapon.WeaponType.melee);
			Destroy(currentWeapon);
		}
	}

	public void OnDie()
	{
		dead = true;
        if (deadBody)
        {
            GameObject corpse = Instantiate(deadBody);
            corpse.transform.position = transform.position;
            sprites.SetActive(false);
        }
		AudioManager.instance.PlayPool(deathAudio);
	}
	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Car")
			win = true;
	}
}
