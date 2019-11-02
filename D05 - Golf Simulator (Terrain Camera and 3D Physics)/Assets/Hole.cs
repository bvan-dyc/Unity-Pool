using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
	public Hole nextHole;
	public HoleManager manager;
	public bool isFinalHole = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		manager.toNextHole();
	}
}
