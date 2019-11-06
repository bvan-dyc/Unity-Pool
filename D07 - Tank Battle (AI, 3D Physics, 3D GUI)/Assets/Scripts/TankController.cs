using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
	private Rigidbody rbody;
	public CannonController canon;
	[SerializeField] private float tankSpeed = 5f;
	[SerializeField] private float rotationSpeedMult = 0.8f;
	[Header("Boost")]
	[SerializeField] private Slider boostSlider = null;
	[SerializeField] private float maxBoost = 100f;
	[SerializeField] private float boostCost = 1f;
	[SerializeField] private float boostRegen = 0.4f;
	[SerializeField] private float boostMult = 1.7f;
	public Image crosshair;
	private float boostGauge;
	public float mouseSensitivity = 1f;
	void Start()
	{
		boostGauge = maxBoost;
		rbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (canon.didHit)
			crosshair.color = Color.red;
		else
			crosshair.color = Color.white;
	}
	public void MoveTank(float vertical, float horizontal, bool boost = false)
	{
		if (boostGauge < boostCost)
			boost = false;
		boostGauge = (boost ? boostGauge - boostCost : (boostGauge >= maxBoost ? maxBoost : boostGauge + boostRegen));
		boostSlider.value = boostGauge;
		transform.Rotate(horizontal * rotationSpeedMult * transform.up);
		Vector3 newVelocity = transform.forward * vertical * tankSpeed * (boost ? boostMult : 1);
		newVelocity.y = rbody.velocity.y;
		rbody.velocity = newVelocity;
	}

	public void MoveCannon(float mouseX, float mouseY)
	{
		canon.lookAt(mouseX, mouseY);
	}

	public void Shoot(bool isRocket)
	{
		canon.Shoot(isRocket);
	}
}
