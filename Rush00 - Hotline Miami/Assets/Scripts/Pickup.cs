using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	protected pickupType type = pickupType.other;
	public enum pickupType
	{
		weapon,
		other
	}

	public pickupType getType()
	{
		return (type);
	}
}
