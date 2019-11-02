using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
	public bool victory = false;
	public Stealth stealthManager;
	public PlayerController player;
	public UserInput inputManager;
	public Text mainText;
	public Text subtext;
	public float reloadDelay = 5f;
	public string lossString = "GAME OVER";
	public string victoryString = "COMPLETE";
	public string lossSubString = "JOHNNY? JOHNNY!? JOHNNYYYYYYYYY!!!";
	public string victorySubString = "Great job Johnny, you truly are nation best.";
	public AudioSource audioSource;
	public AudioClip mainTheme;
	public AudioClip alertTheme;
	public AudioClip endClip;
	public Image fadeScreen;
	private string currentText;
	private bool gameEnded = false;
	private playerState nextTarget = playerState.Start;
	private bool alert = false;
	public enum playerState
	{
		Start,
		hasKey,
		hasDocuments,
		Escaped
	}
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	void Update()
    {
		if (gameEnded)
			return;
		computeNextState();
		if (!alert && stealthManager.getAlertLevel() >= 75)
		{
			audioSource.clip = alertTheme;
			audioSource.Play();
			alert = true;
		}
		else if (alert && stealthManager.getAlertLevel() < 75)
		{
			audioSource.clip = mainTheme;
			audioSource.Play();
			alert = false;
		}
        if (stealthManager.getAlertLevel() >= 100)
			gameLoss();
		else if (player.playerHasEscaped())
			gameVictory();
    }
	private void computeNextState()
	{
		if (nextTarget == playerState.Start)
		{
			StartCoroutine(showTextThenFade("The blueprints are hidden in this building. Find them.", subtext, 0.07f, 7));
			nextTarget = playerState.hasKey;
		}
		else if (nextTarget == playerState.hasKey && player.playerHasKey())
		{
			StartCoroutine(showTextThenFade("Well done Johnny, now go open that door.", subtext, 0.07f, 7));
			nextTarget = playerState.hasDocuments;
		}
		else if (nextTarget == playerState.hasDocuments && player.playerHasDocuments())
		{
			StartCoroutine(showTextThenFade("Great! There should be an elevator nearby that will lead you right out.", subtext, 0.07f, 7));
			nextTarget = playerState.Escaped;
		}
	}

	private void reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void gameLoss()
	{
		subtext.color = new Color(subtext.color.r, subtext.color.g, subtext.color.b, 1);
		gameEnd();
		StartCoroutine(ShowText(lossString, mainText, 0.15f));
		StartCoroutine(ShowText(lossSubString, subtext, 0.1f));
		Invoke("reload", reloadDelay);
	}

	public void gameVictory()
	{
		subtext.color = new Color(subtext.color.r, subtext.color.g, subtext.color.b, 1);
		gameEnd();
		StartCoroutine(ShowText(victoryString, mainText, 0.15f));
		StartCoroutine(ShowText(victorySubString, subtext, 0.1f));
		Invoke("reload", reloadDelay * 2);
	}

	public void gameEnd()
	{
		inputManager.canControl = false;
		player.freeze();
		StartCoroutine(ImageFadeIn(fadeScreen, 4f));
	}

	public void clearSubText()
	{
		subtext.text = "";
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

	IEnumerator TextFade(Text textToFade)
	{
		float fadeOutDuration = 0.5f;
		Color mColor = textToFade.color;
		for (float t = 0.01f; t < fadeOutDuration; t += Time.deltaTime)
		{
			textToFade.color = Color.Lerp(mColor, new Color(mColor.r, mColor.g, mColor.b, 0), Mathf.Min(1, t / fadeOutDuration));
			yield return null;
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

	IEnumerator showTextThenFade(string fullText, Text textToChange, float showCdelay, float delay)
	{
		StartCoroutine(ShowText(fullText, textToChange, showCdelay));
		yield return new WaitForSeconds(delay);
		StartCoroutine(TextFade(textToChange));
	}
}
