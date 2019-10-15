using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
	public gameManager manager;
	public GameObject pauseCanvas;
	public GameObject confirmationWindow;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			pauseGame();
	}
	public void pauseGame()
	{
		pauseCanvas.SetActive(true);
		manager.pause(true);

	}
	public void onContinue()
	{
		pauseCanvas.SetActive(false);
		manager.pause(false);
	}

	public void onQuit()
	{
		confirmationWindow.SetActive(true);
	}

	public void closeConfirmationWindow()
	{
		confirmationWindow.SetActive(false);
	}
	public void onConfirmQuit()
	{
		SceneManager.LoadScene("ex00");
	}
}
