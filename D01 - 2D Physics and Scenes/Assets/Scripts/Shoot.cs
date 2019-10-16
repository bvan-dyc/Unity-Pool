using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public Transform	bulletSpawnPoint;
	public GameObject	bulletPrefab;
	public float	bulletSpeed = 5f;
	public float	nextShotTime = 1f;
	public float nextShotSpawnGap = 1f;

	public void Update()
	{
		if (nextShotTime <= 0)
		{
			Fire(); 
		}
		nextShotTime -= Time.deltaTime;
	}

	public void Fire()
	{
		SpawnBullet();
		nextShotTime = nextShotSpawnGap;
	}

	public void SpawnBullet()
	{
		bulletPrefab.transform.position = bulletSpawnPoint.position;
		GameObject bullet = Instantiate(bulletPrefab);
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
	}
}
