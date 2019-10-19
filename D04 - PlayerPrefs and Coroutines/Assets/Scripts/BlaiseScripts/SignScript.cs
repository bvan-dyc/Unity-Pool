using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
	public AudioSource aMain;
	public AudioClip levelEndMusic;
	public LevelEndScript lvlManager;
	public bool passed = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!passed && collision.gameObject.tag == "Player")
		{
			aMain.Stop();
			aMain.clip = levelEndMusic;
			aMain.Play();
			lvlManager.levelEnd();
			passed = true;
		}
	}
}
