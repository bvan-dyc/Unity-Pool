using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private int ammoCost = 1;
	[SerializeField] private float timeBeforeAutodestruct_s = 5f;
	private float adTimer = 0;
	void FixedUpdate()
	{
		if (timeBeforeAutodestruct_s > 0)
		{
			adTimer += Time.deltaTime;
			if (adTimer > timeBeforeAutodestruct_s)
			{
				GameObject.Destroy(gameObject);
			}
		}
	}

	public int getCost()
	{
		return (ammoCost);
	}

	public void destroyThis()
	{
		GameObject.Destroy(gameObject);
	}

	public void setLongevity_s(float newLongevity_s)
	{
		timeBeforeAutodestruct_s = newLongevity_s;
	}
}
