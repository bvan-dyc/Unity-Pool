using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ManaPool : MonoBehaviour
{
	[System.Serializable]
	public class ManaEvent : UnityEvent<ManaPool>
	{ }
	[HideInInspector] public int currentMana = 100;
	[HideInInspector] public int maxMana = 100;
	[SerializeField]
	private CharacterData data;
	[SerializeField] private ManaEvent OnManaSet;
	[SerializeField] private bool infiniteMana = false;
	private void OnEnable()
	{
		data = GetComponent<CharacterData>();
		currentMana = data.maxMana;
		maxMana = data.maxMana;
    }

    void Update()
    {
		maxMana = data.maxMana;
    }

	public bool	SpendMana(int amount)
	{
		if (amount > currentMana && !infiniteMana)
			return (false);
		currentMana -= amount;
		OnManaSet.Invoke(this);
		return (true);
	}
	public void GainMana(int amount)
	{
		currentMana += amount;
		if (currentMana > maxMana)
			currentMana = maxMana;
		OnManaSet.Invoke(this);
	}

	public void toggleInfiniteMana()
	{
		infiniteMana = infiniteMana == true ? false : true;
	}
}
