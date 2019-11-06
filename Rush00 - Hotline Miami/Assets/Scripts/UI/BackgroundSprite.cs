using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSprite : MonoBehaviour {
	private Animator	animator;
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("translate", true);
	}
}
