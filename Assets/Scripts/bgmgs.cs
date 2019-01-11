using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmgs : MonoBehaviour {
    bool fesactive;
    private GameObject feslogo;
    public AudioSource AudioSource;
    AudioSource bgmAudio;
    bgm bgm;
	void Start () {
        feslogo = GameObject.Find("シンデレラフェス");
        bgm = GameObject.Find("fesbgm").GetComponent<bgm>();
	}

    void wait() {
        bgm.stop();
        this.AudioSource.UnPause();
        fesactive = true;
    }
    void fes () {
        if((feslogo.activeSelf == true) && (fesactive == true)) {
            fesactive = false;
            this.AudioSource.Pause();
            bgm.play();
            Invoke("wait",10f);
        }
    }

	void Update () {
		
	}
}
