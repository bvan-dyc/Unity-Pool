using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance {get; private set;}
    public int  score = 0;
	private int numberOfEnemies;

    public int getNumberEnemies() {return numberOfEnemies;}
    public void IncreaseScore() {
        score += 500;
        numberOfEnemies -= 1;
    }
    void Start()
    {
        if (instance == null)
			instance = this;
    	numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
