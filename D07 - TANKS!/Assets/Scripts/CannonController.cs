using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
	[Header("Rotation")]
	[SerializeField] private float mouseSensitivity = 5.0f;
	[SerializeField] private float smoothFactor = 2.0f;
	[SerializeField] private Vector2 maxRotation;
	[SerializeField] private Vector2 minRotation;
	private Vector2 mouseLook;
	private Vector2 smoothV;
	[Header("Shooting")]
	[SerializeField] private AudioSource shootingAS;
	[SerializeField] private AudioClip gunClip;
	[SerializeField] private AudioClip rocketClip;
	[SerializeField] private GameObject gunParticle;
	[SerializeField] private GameObject rocketParticle;
	[SerializeField] private float range = 10f;
	[SerializeField] private int rocketAmmo = 10;
	[SerializeField] private float shootDelay = 0.1f;
	[SerializeField] private float rocketDelay = 0.5f;
	[SerializeField] private int shootDamage = 1;
	[SerializeField] private int rocketDamage = 50;
	private float nextShotTime = 0f;
	public void lookAt(float posX, float posY)
	{
		Vector2 mouseLookAt = new Vector2(posX, posY);
		mouseLookAt = Vector2.Scale(mouseLookAt, new Vector2(mouseSensitivity * smoothFactor, mouseSensitivity * smoothFactor));
		smoothV.x = Mathf.Lerp(smoothV.x, mouseLookAt.x, 1f / smoothFactor);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseLookAt.y, 1f / smoothFactor);
		mouseLook += smoothV;
		mouseLook.x = Mathf.Clamp(mouseLook.x, minRotation.x, maxRotation.x);
		mouseLook.y = Mathf.Clamp(mouseLook.y, minRotation.y, maxRotation.y);
		transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.right);
		transform.localRotation *= Quaternion.AngleAxis(mouseLook.x, transform.parent.transform.up);
	}

	public void Shoot(bool isRocket = false)
	{
		if (Time.time < nextShotTime)
			return;
		if (isRocket)
		{
			if (rocketAmmo <= 0)
				return;
			rocketAmmo--;
		}
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, range))
		{
			Instantiate(isRocket ? rocketParticle : gunParticle, hit.point, Quaternion.identity);
			if (hit.transform != null)
				Debug.DrawLine(transform.position, hit.point, Color.red);
		}
		shootingAS.PlayOneShot(isRocket ? rocketClip : gunClip);
		nextShotTime = Time.time + (isRocket ? rocketDelay : shootDelay);
	}
}
