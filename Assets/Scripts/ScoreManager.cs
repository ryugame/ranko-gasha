using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager: MonoBehaviour {
    Character character;
    public int GetChance;
    public static int score = 0;
    public static int sterp = 0;
    public Text textScore;
    public Text textSterp;
    public Text getchance;

    const string hutou = "刺繍封筒排出率";
     
    void Start () {
        SceneManager.sceneLoaded += OnSceneLoaded;
        character = GameObject.Find("蘭子_fly").GetComponent<Character>();
        GetChance = character.GetChance;
        textScore = GameObject.Find("Score").GetComponent<Text>();
        textSterp = GameObject.Find("Sterpiece").GetComponent<Text>();
        getchance = GameObject.Find("Getchance").GetComponent<Text>();

        getchance.text = hutou + GetChance + "％";
        textScore.text = "スコア" + score;
        textSterp.text = "スターピース" + sterp;

	}
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        sterp = 0;
        score = 0;
    }
    public void gc  (ref int GetChance) {
        getchance.text = hutou + GetChance + "％";
    }

    public void AddScoresp (int amount) {
        sterp += amount;
        textSterp.text = "スターピース" + sterp;
    }

    public void AddScore(int amount) {
        score += amount;
        textScore.text = "スコア" + score;
    }

    public static int ResultScore() {
        return score;
    }
	
    public static int ResultSterp(){
        return sterp;
    }

	void Update () {
        GetChance = character.GetChance;
        getchance.text = hutou + GetChance + "％";
        if(sterp >= 300){
            SceneManager.LoadScene("Result");
        }

	}
}
