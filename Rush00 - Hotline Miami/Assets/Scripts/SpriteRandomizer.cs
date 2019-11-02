using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
	[SerializeField] private Sprite[] sprites = null;
	[SerializeField] private SpriteRenderer spriteRenderer = null;

	private void Start()
	{
		spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
	}
}
