using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundCamera : MonoBehaviour
{
	[SerializeField] private bool limitToBounds = false;
	private Collider levelBounds;
	private Vector3 minXYZ;
	private Vector3 maxXYZ;
	private float camHeight;
	private float camLength;
	// Start is called before the first frame update
	void Awake()
    {
		levelBounds = GameObject.FindGameObjectWithTag("Bounds").GetComponent<Collider>();
		minXYZ = levelBounds.bounds.min;
		maxXYZ = levelBounds.bounds.max;
	}

	private void Start()
	{
		camHeight = GetComponent<Camera>().orthographicSize;
		camLength = camHeight * Screen.width / Screen.height;
	}
	// Update is called once per frame
	void Update()
    {
		if (limitToBounds)
		{
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minXYZ.x, maxXYZ.x),
								 Mathf.Clamp(transform.position.y, minXYZ.y, maxXYZ.y),
								 Mathf.Clamp(transform.position.z, minXYZ.z, maxXYZ.z));
		}
	}
}
