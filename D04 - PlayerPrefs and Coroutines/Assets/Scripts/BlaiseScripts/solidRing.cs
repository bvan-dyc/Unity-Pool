using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solidRing : MonoBehaviour
{
	private Rigidbody2D rbody;
	public int impulsePower = 1;
	private float timer = 0;
    void Start()
    {
		Random.seed = System.DateTime.Now.Millisecond;
		rbody = GetComponent<Rigidbody2D>();
		Vector2 randomDirection = new Vector2(Random.Range(-0.9f, 0.9f), Random.Range(0.3f, 1f));
		rbody.AddForce(impulsePower * randomDirection, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if (timer >= 2)
		{
			StartCoroutine(isBlinking());
		}
		if (timer >= 4)
		{
			GameObject.Destroy(gameObject);
		}
    }

	IEnumerator isBlinking()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		for (int i = 0; i < 15; i++)
		{
			sr.color = Color.clear;
			yield return new WaitForSeconds(0.1f);
			sr.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
