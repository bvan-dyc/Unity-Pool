using UnityEngine;
using System.Collections;

public class playermove01 : MonoBehaviour
{
	public float speed;
	private bool canControl = false;
	public float jumpPower;
	public LayerMask groundLayers;
	public Transform groundCheck;
	private const float GROUNDED_RADIUS = 0.2f;
	private Rigidbody2D rbody;
	public bool escaped = false;
	[SerializeField] [Range(0, 10)] private float fallMultiplier = 2f;
	[SerializeField] [Range(0, 10)] private float lowJumpMultiplier = 2f;
	private float gravityScale;
	bool isGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, GROUNDED_RADIUS, groundLayers);
	}

	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		gravityScale = rbody.gravityScale;
	}
	void Update()
	{
		gravityRig();
		if (!canControl)
			rbody.velocity = new Vector2(0, rbody.velocity.y);

	}

	public void disableControl()
	{
		canControl = false;
		rbody.velocity = new Vector2(0, rbody.velocity.y);
	}

	public void enableControl()
	{
		canControl = true;
	}

	void FixedUpdate()
	{
		float movement = Input.GetAxis("Horizontal");
		if (canControl)
			rbody.velocity = new Vector2(movement * speed, rbody.velocity.y);
		if (canControl && Input.GetKey("space") && isGrounded())
		{
			rbody.velocity = new Vector2(rbody.velocity.x, jumpPower);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Exit")
			escaped = true;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Exit")
			escaped = false;
	}

	private void gravityRig()
	{
		if (rbody.velocity.y < 0)
		{
			rbody.gravityScale = fallMultiplier * gravityScale;
		}
		else if (rbody.velocity.y > 0 && !Input.GetKey("space"))
		{
			rbody.gravityScale = lowJumpMultiplier * gravityScale;
		}
		else
			rbody.gravityScale = gravityScale;
	}
}
