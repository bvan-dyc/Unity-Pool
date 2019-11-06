using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    private Button  play;
    private Button  exit;
    private GameObject[]    title;
    public GameObject  menu;
    private Player      player;
    public AudioClip    winAudio;
    public AudioClip    loseAudio;

	void Retry() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	void NextLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
	}
    void Start()
    {
        menu.SetActive(true);
        title = GameObject.FindGameObjectsWithTag("Title");
        play = GameObject.FindGameObjectWithTag("Play").GetComponent<Button>();
        exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<Button>();
        menu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void SetButtonValues(string titleValue, string playValue, UnityAction status, AudioClip clip) {
        menu.SetActive(true);
        AudioManager.instance.Play(clip, false, false, 1f);
        Time.timeScale = 0f;
        foreach (GameObject titleText in title)
            titleText.GetComponent<Text>().text = titleValue;
        Text[] playText = play.GetComponentsInChildren<Text>();
        foreach (Text text in playText)
            text.text = playValue;
		play.onClick.AddListener(status);
		exit.onClick.AddListener(QuitGame);
		exit.GetComponentInChildren<Text>().text = "Back to main menu";
    }
    void Update()
    {
        if (menu.activeSelf == false && player.dead)
            SetButtonValues("You're dead", "I'm not, I will prove it", Retry, loseAudio);
        else if (menu.activeSelf == false && (player.win || ScoreManager.instance.getNumberEnemies() == 0))
            SetButtonValues("Victory !", "Let's do next level", NextLevel, winAudio);
    }
}
