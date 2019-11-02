using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicOnAlert : MonoBehaviour
{
	[SerializeField] private float alertRange = 5f;
	[SerializeField] private float updateFrequency = 1f;
	public bool enemyWasDetected = false;
	public void Start()
	{
		StartCoroutine(DetectRoutine());
	}

	private IEnumerator DetectRoutine()
	{
		enemyWasDetected = false;
		Collider[] colliders = Physics.OverlapSphere(transform.position, alertRange, LayerMask.NameToLayer("Default"));
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "enemy")
			{
				enemyWasDetected = true;
			}
				
		}
		yield return new WaitForSeconds(updateFrequency);
	}
}
