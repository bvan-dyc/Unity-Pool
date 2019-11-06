using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solidRing : MonoBehaviour
{
	private Rigidbody2D rbody;
	private float timer = 0;
    public Collider2D coinCollider;

    void Start()
    {
        Invoke("makeCoin", 0.5f);
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
			Destroy(gameObject);
		}
    }
    private void makeCoin()
    {
        coinCollider.enabled = true;
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
