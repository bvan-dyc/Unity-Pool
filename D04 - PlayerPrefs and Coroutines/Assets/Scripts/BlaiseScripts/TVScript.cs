using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
	public TVType type;
	public Sonic sonic;
	public AudioSource mainAS;
	public Animator animator;
	public enum TVType
	{
		ring,
		superShoes,
		shield
	}

    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (sonic.isJumpball == true || sonic.isRolling == true)
			{
				breakTV();
			}
		}
	}
	private void breakTV()
	{
		switch (type) {
			case TVType.ring:
			{
				sonic.rings += 10;
				break;
			}
			case TVType.superShoes:
			{
				superSpeed();
				break;
			}
			case TVType.shield:
			{
				GameObject newShield = Instantiate(sonic.currentShield, sonic.gameObject.transform);
				sonic.isShielded = true;
				break;
			}
		}
		sonic.destroy();
		Destroy(GetComponent<Collider2D>());
		animator.SetTrigger("break");
	}

	private void superSpeed()
	{
		mainAS.pitch *= 1.2f;
		sonic.maxSpeed = 30;
		Invoke("returnSpeedToNormal", 15);
	}
	private void returnSpeedToNormal()
	{
		mainAS.pitch /= 1.2f;
		sonic.maxSpeed = 20;
	}
}
