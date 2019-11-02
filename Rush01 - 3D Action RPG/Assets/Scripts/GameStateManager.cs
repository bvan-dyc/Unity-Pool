using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
	[SerializeField] private Text mainText = null;
	[SerializeField] private float reloadDelay = 5f;
	[SerializeField] private string lossString = "YOU DIED";
	[SerializeField] private UserInput inputManager = null;
	[SerializeField] private Image fadeScreen = null;
	[SerializeField] private float fadeDuration = 1f;
	[SerializeField] private bool fadeInOnLoad = false;
	private string currentText;
	[SerializeField] private Transform spawnPoint;
	public void Start()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Respawn(spawnPoint.position);
		if (fadeInOnLoad)
		{
			fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 1);
			StartCoroutine(UIExtensions.ImageFadeOutRoutine(fadeScreen, fadeDuration));
		}
	}
	public void GameOver()
	{
		inputManager.canControl = false;
		StartCoroutine(ReloadRoutine(reloadDelay));
		StartCoroutine(UIExtensions.TypeTextRoutine(lossString, mainText, 0.2f));
		StartCoroutine(UIExtensions.ImageFadeInRoutine(fadeScreen, fadeDuration));
	}

	IEnumerator ReloadRoutine(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
