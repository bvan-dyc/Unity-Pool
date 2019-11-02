using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIExtensions
{
	public static IEnumerator TypeTextRoutine(string fullText, Text textToChange, float delay)
	{
		string currentText;
		for (int i = 0; i <= fullText.Length; i++)
		{
			currentText = fullText.Substring(0, i);
			textToChange.text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
	public static IEnumerator ImageFadeInRoutine(Image imageToFadeIn, float fadeInDuration)
	{
		Color mColor = imageToFadeIn.color;
		for (float t = 0.01f; t < fadeInDuration; t += Time.deltaTime)
		{
			imageToFadeIn.color = Color.Lerp(mColor, new Color(mColor.r, mColor.g, mColor.b, 1), Mathf.Min(1, t / fadeInDuration));
			yield return null;
		}
	}
	public static IEnumerator ImageFadeOutRoutine(Image imageToFadeOut, float fadeInDuration)
	{
		Color mColor = imageToFadeOut.color;
		for (float t = 0.01f; t < fadeInDuration; t += Time.deltaTime)
		{
			imageToFadeOut.color = Color.Lerp(mColor, new Color(mColor.r, mColor.g, mColor.b, 1), Mathf.Min(1, t / fadeInDuration));
			yield return null;
		}
	}
}
