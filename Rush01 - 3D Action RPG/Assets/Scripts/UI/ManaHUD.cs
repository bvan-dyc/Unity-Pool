using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaHUD : MonoBehaviour
{
	[SerializeField] private ManaPool representedManaPool = null;
	[SerializeField] private Slider ManaGauge = null;
	[SerializeField] private Text currentManaText = null;
	[SerializeField] private Text maxManaText = null;
	private void Start()
	{
		representedManaPool = GameObject.FindGameObjectWithTag("Player").GetComponent<ManaPool>();
		RefreshValues();
	}

	public void RefreshValues()
	{
		ManaGauge.maxValue = representedManaPool.maxMana;
		ManaGauge.value = representedManaPool.currentMana;
		currentManaText.text = representedManaPool.currentMana.ToString();
		maxManaText.text = representedManaPool.maxMana.ToString();
	}
}
