﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviourSingleton<UIManager> {

    [SerializeField]
    private Image[] lives;
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private GameObject ingameScreen;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject looseScreen;
    // Use this for initialization

	private bool isPaused;

    void Start () {
        Time.timeScale = 1;
        ingameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        winScreen.SetActive(false);
        looseScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		foreach (Image img in lives)
        {
            img.gameObject.SetActive(false);
        }

        for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().HEALTH_POINT; i++)
        {
            lives[i].gameObject.SetActive(true);
        }

		if (Input.GetButtonDown("Cancel")) {
			if (isPaused) {
				isPaused = false;
				resume();
			} else {
				isPaused = true;
				pause();
			}
		}
	}

    public void pause()
    {
        Time.timeScale = 0;
        ingameScreen.SetActive(false);
        pauseScreen.SetActive(true);
        winScreen.SetActive(false);
        looseScreen.SetActive(false);
    }

    public void resume()
    {
        Time.timeScale = 1;
        ingameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        winScreen.SetActive(false);
        looseScreen.SetActive(false);
    }

    public void win()
    {
        Time.timeScale = 0;
        ingameScreen.SetActive(false);
        pauseScreen.SetActive(false);
        winScreen.SetActive(true);
        looseScreen.SetActive(false);
    }

    public void loose()
    {
        Time.timeScale = 0;
        ingameScreen.SetActive(false);
        pauseScreen.SetActive(false);
        winScreen.SetActive(false);
        looseScreen.SetActive(true);
    }

    public void retry()
    {
       GameManager.Instance.NewGame();
    }

	public void mainMenu() {
		GameManager.Instance.GoToTitleScene();
	}

}
