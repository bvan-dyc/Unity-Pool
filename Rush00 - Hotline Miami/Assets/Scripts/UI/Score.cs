using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject  player;
    private int  score = 0;
    private GameObject[] scoreObjects;

    void EditScore(int newScore) {
        foreach (GameObject scoreGO in scoreObjects) {
            scoreGO.GetComponent<Text>().text = newScore + " pts";
        }
        score = newScore;
    }
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		scoreObjects = GameObject.FindGameObjectsWithTag("Score");
        EditScore(0);
    }

    void Update()
    {
        if (ScoreManager.instance.score != score)
            EditScore(ScoreManager.instance.score);
    }
}
