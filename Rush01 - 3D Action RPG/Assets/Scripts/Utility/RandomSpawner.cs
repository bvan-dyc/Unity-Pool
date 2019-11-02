using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] objects = null;
	[SerializeField] private float spawnDelay = 5f;
	[SerializeField] private float detectRadius = 30f;
	[SerializeField] private bool unique = true;
	private int length;
	private float timer = 0;
	private GameObject spawn = null;
	private GameObject player;
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		length = objects.Length;
	}

    void Update()
    {
		if ((!unique || spawn == null) && Vector3.Distance(player.transform.position, transform.position) < detectRadius)
		{
			timer += Time.deltaTime;
			if (timer >= spawnDelay)
			{
				spawn = Instantiate(objects[Random.Range(0, length)], transform);
				spawn.transform.position = gameObject.transform.position;
				spawn.GetComponent<Enemy>().setLevel(player.GetComponent<Hero>().data.level);
				timer = 0;
			}
		}
    }
}
