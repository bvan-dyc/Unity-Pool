using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
	public int deathCount = 0;
	public int ringCount = 0;
	public int angelIsland_score = 0;
	public int oilOcean_score = 0;
	public int flyingBattery_score = 0;
	public int totalLevelsUnlocked = 1;
	public string levelName = "angelIsland";

	void Update()
	{
		deathCount = PlayerPrefs.GetInt("deathCount");
		ringCount = PlayerPrefs.GetInt("ringCount");
		angelIsland_score = PlayerPrefs.GetInt("angelIsland_score");
		oilOcean_score = PlayerPrefs.GetInt("oilOcean_score");
		flyingBattery_score = PlayerPrefs.GetInt("flyingBattery_score");
		totalLevelsUnlocked = PlayerPrefs.GetInt("totalLevelsUnlocked", 1);
	}

	public void resetData()
	{
		PlayerPrefs.SetInt("deathCount", 0);
		PlayerPrefs.SetInt("ringCount", 0);
		PlayerPrefs.SetInt("angelIsland_score", 0);
		PlayerPrefs.SetInt("oilOcean_score", 0);
		PlayerPrefs.SetInt("flyingBattery_score", 0);
		PlayerPrefs.SetInt("totalLevelsUnlocked", 1);
	}

	public void updateScore(int newScore, int newRings, int newDeaths)
	{
		PlayerPrefs.SetInt("deathCount", deathCount + newDeaths);
		PlayerPrefs.SetInt("ringCount", ringCount + newRings);
		PlayerPrefs.SetInt(levelName + "_score", newScore);
		if (SceneManager.GetActiveScene().buildIndex - 1 >= totalLevelsUnlocked)
			PlayerPrefs.SetInt("totalLevelsUnlocked", totalLevelsUnlocked++);

	}
}
