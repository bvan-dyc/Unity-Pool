using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour
{
	private float timer = 0;
	private int score = 0;
	public Sonic sonic;
	public GameObject victoryScreen;
	public PlayerData pData;
	public Text scoreText;
	private bool gameHasEnded;
	private bool victoryScreenIsOpen;

    void Update()
    {
		timer += Time.deltaTime;
		if (!victoryScreenIsOpen && gameHasEnded && timer >= 6)
		{
			victoryScreen.SetActive(true);
			scoreText.text = score.ToString();
			victoryScreenIsOpen = true;
			pData.updateScore(score, sonic.rings, sonic.deathCount);
			Time.timeScale = 0;
		}
		if (victoryScreenIsOpen)
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				Time.timeScale = 1;
				SceneManager.LoadScene(1);
			}
		}
    }

	public void levelEnd()
	{
		if (!gameHasEnded)
			computeScore();
		gameHasEnded = true;
	}
	private void computeScore()
	{
		if (timer < 200)
			score = 20000 - 10 * Mathf.RoundToInt(timer);
		score += sonic.rings * 100;
		timer = 0;
	}
}
