using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour {
    public Text Score;
    public Text Sterp;
     int score = ScoreManager.score;
     int sterp = ScoreManager.sterp;

	// Use this for initialization
	void Start () {

        Score.text = "スコア" + score;
        Sterp.text = "スターピース" + sterp;

        Score = GameObject.Find("Score").GetComponent<Text>();
        Sterp = GameObject.Find("Sterpiece").GetComponent<Text>();
	}

    public void AddScoresp(int amount)
    {
        sterp += amount;
        Sterp.text = "スターピース" + sterp;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Score.text = "スコア" + score;
    }

    public void rescore()
     {
        sterp = 0;
        score = 0;
    }
    public void restert () {
        rescore();
    }
}
