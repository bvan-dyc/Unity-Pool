using UnityEngine;
using System.Collections;
public class CubeSpawner : MonoBehaviour
{
    public GameObject	cubePrefab;
	public float spawnDelay_s = 0.5f;
	public float inputY = 0.0f;
	private float timer_s = 0f;
	private GameObject cube = null;
	private void Start()
	{
		timer_s = spawnDelay_s;
	}
	// Update is called once per frame
	void Update()
	{
		timer_s -= Time.deltaTime;
		if (timer_s <= 0 && !cube)
		{
			cube = GameObject.Instantiate(cubePrefab, transform);
		}
		if (cube && (cubePrefab.name == "CubeA" && Input.GetKeyDown("a") ||
					 cubePrefab.name == "CubeS" && Input.GetKeyDown("s") ||
					 cubePrefab.name == "CubeD" && Input.GetKeyDown("d")))
		{
			float inputPrecision = cube.transform.position.y;
			Debug.Log("Precision: " + round(inputY - inputPrecision));
			GameObject.Destroy(cube);
			timer_s = spawnDelay_s;
		}
	}

	private float round(float numberToRound)
	{
		if (numberToRound < 0)
			return (-numberToRound);
		return (numberToRound);
	}
}
