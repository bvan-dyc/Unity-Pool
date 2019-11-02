using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public PlayerData pData;
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			loadLevelSelect();
		}
	}

	public void quitGame()
	{
		Application.Quit();
	}

	public void loadLevelSelect()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
