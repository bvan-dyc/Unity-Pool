﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedController : MonoBehaviour
{
	public gameManager manager;

	public void pause()
	{
		manager.pause(true);
	}

	public void play()
	{
		manager.pause(false);
	}

	public void speedUp(float speedMult)
	{
		manager.pause(false);
		manager.changeSpeed(speedMult);
	}
}
