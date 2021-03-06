﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

// what happens when you click the "Next Level" button at end-of-level
public class LevelEndButton : MonoBehaviour
{
	private Text t;
	private Button b;

	void Start () {
		b = this.gameObject.GetComponent<Button> ();
		t = this.gameObject.GetComponentInChildren<Text> ();
		if (LevelData.won)
        {
            if (string.Equals(LevelData.currentLevel.ToString(), "3"))
            {
                t.text = "Won";
            }
            else
            {
                t.text = "Next Level";
            }
            
		}
       
        else
        {
			t.text = "Retry"; 
		}
        

		b.onClick.AddListener (buttonClick);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			buttonClick ();
		}
	}

	void buttonClick(){
		Time.timeScale = 1;
		// reset LevelData
		LevelData.ended = false;
		LevelData.timePlaying = 0;
		LevelData.numDeath = 0;
		LevelData.currentLevel += 1;
        ScoreTextScript.coinAmount = ScoreTextScript.coinAmount + 0;
            SceneManager.LoadScene(LevelData.nextLevel, LoadSceneMode.Single);
       
	}
}
