using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceHUD : MonoBehaviour
{
	[SerializeField] private CharacterData representedData = null;
	[SerializeField] private Slider expGauge = null;
	[SerializeField] private Text currentLevelText = null;
	[SerializeField] private Text currentExpText = null;
	[SerializeField] private Text maxExpText = null;
	private void Start()
	{
		representedData = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterData>();
		RefreshValues();
	}

	public void RefreshValues()
	{
		expGauge.maxValue = representedData.xpToNextLevel;
		expGauge.value = representedData.xp;
		currentLevelText.text = representedData.level.ToString();
		currentExpText.text = representedData.xp.ToString();
		maxExpText.text = representedData.xpToNextLevel.ToString();
	}
}
