using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryScript02 : MonoBehaviour
{
	public GameObject playerA;
	public GameObject playerB;
	public GameObject playerC;
	private bool victory = false;
	private bool gameOver = false;
	public bool isFinalScene = false;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (victory == false && playerA.GetComponent<playermove02>().escaped && 
								playerB.GetComponent<playermove02>().escaped && 
								playerC.GetComponent<playermove02>().escaped)
		{
			Debug.Log("Congratulations! You cleared the puzzle!");
			if (!isFinalScene)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
			victory = true;
		}
		if (victory = true && !(playerA.GetComponent<playermove02>().escaped && 
								playerB.GetComponent<playermove02>().escaped && 
								playerC.GetComponent<playermove02>().escaped))
			victory = false;
		if (gameOver == false && (playerA.GetComponent<playermove02>().isDead ||
								playerB.GetComponent<playermove02>().isDead ||
                                  playerC.GetComponent<playermove02>().isDead))
		{
			Debug.Log("One of your rectangles is dead... Reload with 'r'");
			gameOver = true;
		}
		if (Input.GetKey("r"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
