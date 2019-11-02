using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
	public GameObject victoryCanvas;
	public Text scoreText;
	public Text rankText;
	public Text buttonText;
	public gameManager manager;
	private float score = 0;
	public bool isLastLevel = false;
    void Update()
    {
        if (manager.playerHp <= 0)
			lossScreen();
		if (manager.lastWave && score == 0)
			victoryScreen();
    }
	private void lossScreen()
	{
		score = 0;
		manager.pause(true);
		buttonText.text = "Retry";
		scoreText.text = "0000";
		rankText.text = "F";
		victoryCanvas.SetActive(true);
	}
	private void victoryScreen()
	{
		manager.pause(true);
		computeScore();
		buttonText.text = isLastLevel ? "Conclude" : "Next Level";
		scoreText.text = score.ToString();
		rankText.text = computeRank();
		victoryCanvas.SetActive(true);
	}
	public void OnGameEndButtonClick()
	{
		if (manager.playerHp <= 0)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		else if (isLastLevel)
			SceneManager.LoadScene(0);
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	}
	private void computeScore()
	{
		float healthDiff = manager.playerMaxHp - manager.playerHp;
		if (healthDiff == 0)
			score += 3000;
		else if (healthDiff <= 4)
			score += 2500;
		else if (healthDiff <= 8)
			score += 2000;
		else if (healthDiff <= 13)
			score += 1000;
		else
			score += 500;
		if (manager.playerEnergy > 800)
			score += 2000;
		else if (manager.playerEnergy > 550)
			score += 1500;
		else if (manager.playerEnergy > 400)
			score += 1000;
		else if (manager.playerEnergy > 200)
			score += 500;
		else
			score += 0;
	}

	private string computeRank()
	{
		if (score == 5000)
			return ("SSS+");
		else if (score >= 4000)
			return ("S");
		else if (score > 3000)
			return ("A");
		else if (score > 2500)
			return ("B");
		else if (score > 2000)
			return ("C");
		else if (score > 1000)
			return ("D");
		else
			return ("E");
	}
}
