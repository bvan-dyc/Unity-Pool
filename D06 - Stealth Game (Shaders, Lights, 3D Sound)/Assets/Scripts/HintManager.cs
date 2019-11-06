
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public Text Hint;
   
    public void displayHint(string newHint)
    {
        Hint.text = newHint;
        StartCoroutine(fadeInAndOut(Hint, 0.3f, 1.5f));
    }

    private IEnumerator fadeInAndOut(Text textToFade, float fadeDuration, float delay)
    {
        StartCoroutine(TextFadeOut(textToFade, fadeDuration));
        yield return new WaitForSeconds(delay);
        StartCoroutine(TextFadeIn(textToFade, fadeDuration));
    }

    private IEnumerator TextFadeOut(Text textToFade, float fadeOutDuration)
    {
        Color mColor = textToFade.color;
        for (float t = 0.01f; t < fadeOutDuration; t += Time.deltaTime)
        {
            textToFade.color = Color.Lerp(mColor, new Color(mColor.r, mColor.g, mColor.b, 0), Mathf.Min(1, t / fadeOutDuration));
            yield return null;
        }
    }

    private IEnumerator TextFadeIn(Text textToFade, float fadeDuration)
    {
        Color mColor = textToFade.color;
        for (float t = 0.01f; t < fadeDuration; t += Time.deltaTime)
        {
            textToFade.color = Color.Lerp(mColor, new Color(mColor.r, mColor.g, mColor.b, 1), Mathf.Min(1, t / fadeDuration));
            yield return null;
        }
    }
}
