using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] [Range(0, 100)] public int ammunition;
	public AudioClip[]	shotAudio;
	public enum WeaponType
	{
		melee,
		ranged,
		other,
	}
	public virtual bool Attack()
	{
        return (false);
	}

	public virtual float getRange()
	{
		return (0);
	}

	public virtual WeaponType getType()
	{
		return (WeaponType.other);
	}
}
