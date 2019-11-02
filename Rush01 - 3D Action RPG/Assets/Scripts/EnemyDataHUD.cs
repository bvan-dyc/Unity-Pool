using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDataHUD : MonoBehaviour
{
	private PlayerController player;
	[SerializeField] GameObject canvas = null;
	[SerializeField] float refreshFrequency = 1f;
	[SerializeField] Text nameText = null;
	[SerializeField] Text currentHealthText = null;
	[SerializeField] Text maxHealthText = null;
	[SerializeField] Slider healthSlider = null;
	private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

	private void Update()
	{
		if (player.getTarget())
			{
				canvas.SetActive(true);
				Damageable representedDamageable = player.getTarget().GetComponent<Damageable>();
				nameText.text = representedDamageable.name;
				currentHealthText.text = representedDamageable.currentHealth.ToString();
				maxHealthText.text = representedDamageable.maxHealth.ToString();
				healthSlider.maxValue = representedDamageable.maxHealth;
				healthSlider.value = representedDamageable.currentHealth;
			}
			else if (canvas.activeSelf == true)
				canvas.SetActive(false);
	}
}
