using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceRandomizer : MonoBehaviour
{
	[SerializeField] private SpriteRenderer head = null;
	[SerializeField] private SpriteRenderer body = null;
	[SerializeField] private Sprite[] headParts = null;
	[SerializeField] private Sprite[] bodyParts = null;

	private void Awake()
	{
		head.sprite = headParts[Random.Range(1, headParts.Length)];
		body.sprite = bodyParts[Random.Range(1, bodyParts.Length)];
	}
}
