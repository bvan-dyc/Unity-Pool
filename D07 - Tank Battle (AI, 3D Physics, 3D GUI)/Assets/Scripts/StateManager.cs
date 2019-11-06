using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
	public float reloadDelay = 2;
	public void gameEnd()
	{
		Invoke("reload", reloadDelay);
	}
	private void reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
