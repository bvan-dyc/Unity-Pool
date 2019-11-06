using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
	public Text mainText;
	public float reloadDelay = 5f;
	public string lossString = "YOU DIED";
	public UserInput inputManager;
	public Image fadeScreen;
	private string currentText;
	public void GameOver()
	{
		Invoke("reload", reloadDelay);
		inputManager.canControl = false;
		StartCoroutine(ShowText(lossString, mainText, 0.2f));
		StartCoroutine(ImageFadeIn(fadeScreen, 5f));
	}
	private void reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	IEnumerator ShowText(string fullText, Text textToChange, float delay)
	{
		for (int i = 0; i <= fullText.Length; i++)
		{
			currentText = fullText.Substring(0, i);
			textToChange.text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}

	IEnumerator ImageFadeIn(Image imageToFade, float fadeInDuration)
	{
		Color mColor = imageToFade.color;
		for (float t = 0.01f; t < fadeInDuration; t += Time.deltaTime)
		{
			imageToFade.color = Color.Lerp(mColor, new Color(mColor.r, mColor.g, mColor.b, 1), Mathf.Min(1, t / fadeInDuration));
			yield return null;
		}
	}
}
