using UnityEngine;

public class Cube : MonoBehaviour {
	public float	lifetime_s = 20f;
	public float	minSpeed = 1.0f;
	public float	maxSpeed = 5.0f;
	private float	speed;
	// Use this for initialization
	void Start () {
        speed = -Random.Range(minSpeed, maxSpeed);
        speed /= 100;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector3(0, speed, 0));
		lifetime_s -= Time.deltaTime;
		if (lifetime_s <= 0)
			GameObject.Destroy(gameObject);
	}
}
