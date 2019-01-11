using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour {
    public AudioSource AudioSource;
    //public AudioClip gsbgm;
    public AudioClip fesbgm;
    public bool isPlay = false;
    void Start () {
        AudioSource AudioSourceComponent = GameObject.Find("シンデレラフェス").GetComponent<AudioSource>();
    }
    public void play () {
        AudioSource.Play();
    }

    public void stop () {
        AudioSource.Stop();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
