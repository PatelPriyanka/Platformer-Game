using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndOfLevelRendering : MonoBehaviour {

	public Vector3 movement;
	public GameObject blob;
	public Text titleText;
	public Text infoText;
	public Text scoreboardText;

	[HideInInspector] public string[] scores;

	private float dest;
	private Vector3 startPos;

    int s;
    

	void Start () {
		scores = new string[10];
		ComputeScore (); // find out what score we got on this level

		// if we've played this level before, update the best score of this current run (for end-of-game leaderboard purposes)
		LevelData.bestScores[LevelData.currentLevel] = Mathf.Max (LevelData.score, LevelData.bestScores [LevelData.currentLevel]);
        
		startPos = blob.transform.position;
		dest = (240f) * (LevelData.mass / LevelData.maxMass);
		if (dest > 240)
        { 
    		dest = 240;
		}
        s = ScoreTextScript.coinAmount;
        float m = LevelData.mass;
        float f = ( s + 100 + m )- (LevelData.timePlaying / 10) ;
        
        if(string.Equals(LevelData.currentLevel.ToString(),"3"))
        {
            f = f + 50;
            infoText.text = "Congretulation! You Won!"
              +  "\nMASS: " + LevelData.mass.ToString()
             + "\nTIME: " + LevelData.timePlaying.ToString()
             + "\nNUMBER OF TRIES: " + (1 + LevelData.numDeath).ToString()
             + "\n\nCOIN SCORE:" + s
             + "\n\nFINAL SCORE: " + f;
            titleText.text = "All Level Completed!";
            scoreboardText.text = "Final Winning SCORE\n" + f;

        }
        else if(string.Equals(LevelData.currentLevel.ToString(), "2"))
        {
            f = f + 50;
            infoText.text = "MASS: " + LevelData.mass.ToString()
             + "\nTIME: " + LevelData.timePlaying.ToString()
             + "\nNUMBER OF TRIES: " + (1 + LevelData.numDeath).ToString()
             + "\n\nCOIN SCORE:" + s
             + "\n\nFINAL SCORE: " + f;
            titleText.text = "Level " + LevelData.currentLevel.ToString() + " Completed!";
            scoreboardText.text = "YOUR SCORE\n\n" + f;

        }
        else
        {
            infoText.text = "MASS: " + LevelData.mass.ToString()
            + "\nTIME: " + LevelData.timePlaying.ToString()
            + "\nNUMBER OF TRIES: " + (1 + LevelData.numDeath).ToString()
            + "\n\nCOIN SCORE:" + s
            + "\n\nFINAL SCORE: " + f;
            titleText.text = "Level " + LevelData.currentLevel.ToString() + " Completed!";
            scoreboardText.text = "YOUR SCORE\n\n" + f;
        }

       

        AddScore(LevelData.playerName, f);
    }


	void Update () {
		if (transform.localPosition.y < -245 + dest) {
			transform.Translate (movement);
			blob.transform.position = startPos;
		}
	}

	void ComputeScore () {
		LevelData.score = LevelData.mass / LevelData.maxMass * 100f
			* Mathf.Pow(LevelData.targetTime / LevelData.timePlaying, 0.2f) // use 0.2 pow to smooth out scoring so it's always around 2 digits
			/ Mathf.Sqrt (LevelData.numDeath + 1);
	}

	// this adds the current score to player preferences and updates the top-10 leaderboard
	// the key is LevelData.currentLevel + "_" + i + "HScore"
	public void AddScore(string name, float score){
		float newScore;
		string newName;
	//	float oldScore;
	//	string oldName;
		newScore = score;
		newName = name;
       

        
	}
}
