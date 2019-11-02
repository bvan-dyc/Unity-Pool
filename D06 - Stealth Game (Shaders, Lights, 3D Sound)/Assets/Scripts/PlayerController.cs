using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 8f;
	public float runMult = 1.5f;
	public float jumpPower = 10f;
	private Rigidbody rbody;
	private Animator animator;
	public float mouseSensitivity = 1f;
	public AudioSource footstepsAS;
	public AudioSource audioSource;
	public AudioClip footstepsAudio;
	public AudioClip cardPickupAudio;
	private bool hasKey = false;
	private bool hasDocuments = false;
	private bool isRunning = false;
	private bool escaped = false;
	private bool isDetected = false;
	private bool inSmoke = false;
	void Start()
    {
		rbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update()
	{
		if (rbody.velocity.x != 0 || rbody.velocity.z != 0)
		{
			animator.SetBool("isRunning", true);
			footstepsAS.UnPause();
		}
		else
		{
			animator.SetBool("isRunning", false);
			footstepsAS.Pause();
		}
    }

	public void freeze()
	{
		rbody.velocity = Vector3.zero;
		footstepsAS.Stop();
		isRunning = false;
		animator.SetBool("isRunning", false);
	}
	public void Move(float vertical, float horizontal)
	{
		Vector3 newVelocity = transform.forward * vertical * speed + transform.right * horizontal * speed;
		newVelocity.y = rbody.velocity.y;
		rbody.velocity = newVelocity;
		footstepsAS.pitch = 0.8f;
		animator.speed = 1;
		isRunning = false;
	}

	public void Run(float vertical, float horizontal)
	{
		Vector3 newVelocity = transform.forward * vertical * speed * runMult + transform.right * horizontal * speed * runMult;
		newVelocity.y = rbody.velocity.y;
		rbody.velocity = newVelocity;
		footstepsAS.pitch = 0.8f * runMult;
		animator.speed = runMult;
		isRunning = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Key")
		{
			hasKey = true;
			Destroy(other.gameObject);
			audioSource.PlayOneShot(cardPickupAudio);
		}
		if (other.tag == "Documents")
		{
			hasDocuments = true;
			Destroy(other.gameObject);
			audioSource.PlayOneShot(cardPickupAudio);
		}
		if (other.tag == "Escape" && hasDocuments)
			escaped = true;
		if (other.tag == "Detect")
			isDetected = true;
		if (other.tag == "Smoke")
			inSmoke = true;
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Detect")
		{
			isDetected = false;
		}
		if (other.tag == "Smoke")
			inSmoke = false;
	}
	public bool playerHasKey()
	{
		return (hasKey);
	}

	public bool playerHasDocuments()
	{
		return (hasDocuments);
	}

	public bool isPlayerRunning()
	{
		return (isRunning);
	}

	public bool playerHasEscaped()
	{
		return (escaped);
	}

	public bool playerIsDetected()
	{
		return (isDetected);
	}

	public bool playerInSmoke()
	{
		return (inSmoke);
	}
}
