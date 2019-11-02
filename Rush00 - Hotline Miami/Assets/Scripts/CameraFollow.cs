using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private bool followTarget = true;
	[SerializeField] private bool limitToBounds = false;
	[SerializeField] [Range(0, 3)] private float damping = 1;

	private Transform target;

	private float zOffset;
	private Vector3 lastTargetPosition;
	private Vector3 currentVelocity;

	private Collider2D levelBounds;
	private Vector2 minXAndY;
	private Vector2 maxXAndY;
	private float camHeight;
	private float camLength;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		levelBounds = GameObject.FindGameObjectWithTag("Bounds").GetComponent<Collider2D>();
		minXAndY = levelBounds.bounds.min;
		maxXAndY = levelBounds.bounds.max;
	}

	private void Start()
	{
		zOffset = (transform.position - target.position).z;
		transform.parent = null;
		camHeight = GetComponent<Camera>().orthographicSize;
		camLength = camHeight * Screen.width / Screen.height;
	}

	private void LateUpdate()
	{
		if (followTarget)
			FollowTarget();
	}

	private void FollowTarget()
	{
		Vector3 targetPos = target.position + Vector3.forward * zOffset;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, damping);
		if (limitToBounds)
		{
			newPos.x = Mathf.Clamp(newPos.x, minXAndY.x + camLength, maxXAndY.x - camLength);
			newPos.y = Mathf.Clamp(newPos.y, minXAndY.y + camHeight, maxXAndY.y - camHeight);
		}
		transform.position = newPos;
	}

	public void StopFollowing()
	{
		followTarget = false;
	}

	public void StartFollowing()
	{
		followTarget = true;
	}
}
