using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class victoryScript : MonoBehaviour
{
	public GameObject playerA;
	public GameObject playerB;
	public GameObject playerC;
	private bool victory = false;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (victory == false && playerA.GetComponent<playermove01>().escaped && 
								playerB.GetComponent<playermove01>().escaped && 
								playerC.GetComponent<playermove01>().escaped)
		{
			Debug.Log("Congratulations! You cleared the puzzle!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
			victory = true;
		}
		if (victory = true && !(playerA.GetComponent<playermove01>().escaped && 
								playerB.GetComponent<playermove01>().escaped && 
								playerC.GetComponent<playermove01>().escaped))
			victory = false;
	}
}
