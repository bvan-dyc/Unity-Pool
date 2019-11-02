using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleManager : MonoBehaviour
{
	public int holeNumber = 0;
	public Text nHoleText;
	public Hole currentHole;

	public void Start()
	{
		nHoleText.text = holeNumber.ToString();
	}
	public void toNextHole()
	{
		currentHole = currentHole.nextHole;
		holeNumber++;
		nHoleText.text = holeNumber.ToString();
	}
}
