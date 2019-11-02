using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
	public PlayerData pData;
	public Text deathCount;
	public Text coinCount;
	public Text levelName;
	public Text levelScore;
	public int selectedLevelID = 0;
	private int levelMaxID = 2;
	public Image levelIcon;
	public string[] levelNames;
	public Sprite[] levelIcons;

    void Update()
    {
		deathCount.text = 'x' + pData.deathCount.ToString();
		coinCount.text = 'x' + pData.ringCount.ToString();
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			nextLevel();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			previousLevel();
		}
        switch(selectedLevelID)
		{
			case 0:
				levelScore.text = pData.angelIsland_score.ToString();
				break;
			case 1:
				levelScore.text = pData.oilOcean_score.ToString();
				break;
			case 2:
				levelScore.text = pData.flyingBattery_score.ToString();
				break;
		}
		levelName.text = levelNames[selectedLevelID];
		levelIcon.sprite = levelIcons[selectedLevelID];
	}

	public void loadLevel()
	{
		if (selectedLevelID < pData.totalLevelsUnlocked)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + selectedLevelID);
	}
	public void nextLevel()
	{
		selectedLevelID = selectedLevelID < levelMaxID ? selectedLevelID + 1 : 0;
	}

	public void previousLevel()
	{
		selectedLevelID = selectedLevelID > 0 ? selectedLevelID - 1 : levelMaxID;
	}
}
