using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
	public int currentHealth = 30;
	public int maxHealth = 30;
	public AudioSource audioSource;
	public AudioClip deathSound;
	public bool wincon = false;
	public void takeDamage(int damage)
	{
		Debug.Log(gameObject.name + " [" + currentHealth + "/" + maxHealth + "]HP "+ "has been attacked.");
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Debug.Log(gameObject.name + " has been destroyed.");
			Destroy(gameObject);
			audioSource.PlayOneShot(deathSound);
			if (wincon)
			{
				Debug.Log("The Human Team wins.");
			}
		}
	}
}
