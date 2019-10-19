using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	public int boostX = 0;
	public int boostY = 0;
	public Animator animator;
	public AudioSource aBumper;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Sonic>().bumper(boostX, boostY);
			animator.SetTrigger("expand");
			aBumper.Play();
		}
	}
}
