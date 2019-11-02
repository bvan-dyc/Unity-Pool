using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEEffect : MonoBehaviour
{
	[HideInInspector] public float damage;
	[HideInInspector] public float radius;
	[HideInInspector] public GameObject particleEffect;
	private Vector3 dropPosition;
	private UserInput inputManager;
	public float destroyAfterTime = 3;
	private bool wasTriggered = false;
	private void OnEnable()
	{
		inputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<UserInput>();
		inputManager.canControl = false;
	}

	private void Update()
	{
		if (wasTriggered)
			return;
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, LayerMask.NameToLayer("Terrain")))
			{
				dropPosition = hit.point;
				triggerAOE();
				wasTriggered = true;
			}
		}
	}
	private void triggerAOE()
	{
		GameObject newEffect = Instantiate(particleEffect, gameObject.transform);
		newEffect.transform.position = dropPosition;
		Collider[] colliders = Physics.OverlapSphere(dropPosition, radius);
		foreach (Collider enemy in colliders)
		{
			if (enemy.tag == "enemy")
				enemy.GetComponent<Damageable>().TakeDamage(Mathf.RoundToInt(damage), 100);
		}
		Invoke("giveBackControl", 0.1f);
		Invoke("destroyThis", destroyAfterTime);
	}
	private void giveBackControl()
	{
		inputManager.canControl = true;
		inputManager.resetPlayerState();
	}
	private void destroyThis()
	{
		Destroy(gameObject);
	}
}
