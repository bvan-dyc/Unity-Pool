using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public Animator door;
	public AudioClip openFailClip;
	public AudioClip openSuccessClip;
	private AudioSource audioSource;
	private bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (!opened && collision.gameObject.tag == "Player")
		{
			if (collision.gameObject.GetComponent<PlayerController>().playerHasKey())
				openDoor();
			else
				audioSource.PlayOneShot(openFailClip);
		}
	}

	private void openDoor()
	{
		door.SetBool("isOpen", true);
		opened = true;
		audioSource.PlayOneShot(openSuccessClip);
	}
}
