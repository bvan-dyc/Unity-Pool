using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CannonController : MonoBehaviour
{
	[Header("Rotation")]
	[SerializeField] private float mouseSensitivity = 5.0f;
	[SerializeField] private float smoothFactor = 2.0f;
	[SerializeField] private Vector2 maxRotation = Vector2.zero;
	[SerializeField] private Vector2 minRotation = Vector2.zero;
	private Vector2 mouseLook;
	private Vector2 smoothV;
	[Header("Shooting")]
	[SerializeField] private TextMeshProUGUI ammoData = null;
	[SerializeField] private AudioSource shootingAS = null;
	[SerializeField] private AudioClip gunClip = null;
	[SerializeField] private AudioClip rocketClip = null;
	[SerializeField] private AudioClip rocketNoHitClip = null;
	[SerializeField] private GameObject gunParticle = null;
	[SerializeField] private GameObject rocketParticle = null;
	[SerializeField] private int hitChance = 100;
	public float range = 10f;
	[SerializeField] private int rocketAmmo = 10;
	[SerializeField] private float shootDelay = 0.1f;
	[SerializeField] private bool randomHits = false;
	[SerializeField] private float rocketDelay = 0.5f;
	[SerializeField] private int shootDamage = 1;
	[SerializeField] private int rocketDamage = 50;
	private float nextShotTime = 0f;
	public bool didHit = false;
	private float timer = 0f;
	private float hitDuration = 3f;

	public void Start()
	{
		if (ammoData)
		{
			ammoData.text = rocketAmmo.ToString();
		}
	}

	public void Update()
	{
		if (didHit == true)
		{
			timer += Time.deltaTime;
			if (timer > hitDuration)
			{
				didHit = false;
				timer = 0;
			}
		}
	}
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

	public void lookAtTarget(Transform target)
	{
		transform.LookAt(target);
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
			if (ammoData)
				ammoData.text = rocketAmmo.ToString();
		}
		RaycastHit hit;
		Vector3 target = transform.forward;
		if (randomHits)
		{
			if (Random.Range(0, 100) > hitChance)
			{
				target.x += Random.Range(-3, 4);
				target.y += Random.Range(-3, 4);
			}
		}
		if (Physics.Raycast(transform.position, target, out hit, range))
		{
			Instantiate(isRocket ? rocketParticle : gunParticle, hit.point, Quaternion.identity);
			if (hit.transform != null)
				Debug.DrawLine(transform.position, hit.point, Color.red);
			if (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Player")
			{
				hit.transform.gameObject.GetComponent<Damageable>().takeHit(isRocket ? rocketDamage : shootDamage);
				didHit = true;
			}
		}
		shootingAS.PlayOneShot(isRocket ? (hit.transform ? rocketClip : rocketNoHitClip) : gunClip);
		nextShotTime = Time.time + (isRocket ? rocketDelay : shootDelay) + (randomHits ? Random.Range(-0.3f, 0.3f) : 0);
	}
}
