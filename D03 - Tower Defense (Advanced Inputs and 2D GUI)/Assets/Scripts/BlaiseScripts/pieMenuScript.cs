using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieMenuScript : MonoBehaviour
{
	public GameObject PieMenu;
	private GameObject tower;
	private towerScript towerData;
	private int upgradeCost = 0;
	public gameManager manager;
	private bool opened = false;
	public Text sellText;
	public Text upgradeText;
	void Update()
    {
        if (Input.GetMouseButtonDown(1))
		{
			bool hit = checkHitTower();
			if (hit && !opened)
				openPieMenu();
			else if (hit && opened)
				PieMenu.transform.position = tower.transform.position;
			else if (!hit && opened)
				closePieMenu();
		}
		if (opened)
		{
			if (manager.playerEnergy >= upgradeCost)
				upgradeText.color = new Color(0.8f, 0.8f, 0.05f);
			else
				upgradeText.color = new Color(0.8f, 0.1f, 0.05f);
		}
    }

	public bool checkHitTower()
	{
		RaycastHit2D hit;
		var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (hit = Physics2D.Raycast(ray, transform.position))
		{
			if (hit.collider.tag == "tower")
			{
				tower = hit.collider.gameObject.transform.parent.gameObject;
				computeTowerData();
				return (true);
			}
		}
		return (false);
	}
	private void computeTowerData()
	{
		towerData = tower.GetComponent<towerScript>();
		if (towerData.upgrade != null)
			upgradeCost = towerData.upgrade.GetComponent<towerScript>().energy;
		else
			upgradeCost = 0;
		sellText.text = towerData.energy.ToString();
		upgradeText.text = upgradeCost > 0 ? upgradeCost.ToString() : "NONE";
		
	}
	public void openPieMenu()
	{
		PieMenu.SetActive(true);
		PieMenu.transform.position = tower.transform.position;
		opened = true;
	}

	public void closePieMenu()
	{
		PieMenu.SetActive(false);
		opened = false;
	}
	public void sellTower()
	{
		closePieMenu();
		manager.playerEnergy += towerData.energy / 2;
		if (towerData.downgrade)
		{
			GameObject upgradedTower = Instantiate(towerData.downgrade);
			upgradedTower.transform.position = tower.transform.position;
		}
		GameObject.Destroy(tower);
	}

	public void upgradeTower()
	{
		if (manager.playerEnergy >= upgradeCost && towerData.upgrade)
		{
			closePieMenu();
			manager.playerEnergy -= upgradeCost;
			GameObject upgradedTower = Instantiate(towerData.upgrade);
			upgradedTower.transform.position = tower.transform.position;
			GameObject.Destroy(tower);
		}
	}
}
