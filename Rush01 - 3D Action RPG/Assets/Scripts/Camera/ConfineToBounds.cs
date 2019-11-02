using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfineToBounds : MonoBehaviour
{
	private Collider levelBounds;
	private Vector3 minXYZ;
	private Vector3 maxXYZ;
	void Start()
    {
		levelBounds = GameObject.FindGameObjectWithTag("Bounds").GetComponent<Collider>();
		minXYZ = levelBounds.bounds.min;
		maxXYZ = levelBounds.bounds.max;
	}

    void Update()
    {
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXYZ.x, maxXYZ.x),
										 Mathf.Clamp(transform.position.y, minXYZ.y, maxXYZ.y), 
										 Mathf.Clamp(transform.position.z, minXYZ.z, maxXYZ.z));

	}
}
