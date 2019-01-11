using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ちひろさん : MonoBehaviour
{
    bgm bgm;
    //private AudioSource audiosource;
    //public AudioClip gasyabgm;
    //public AudioClip fesbgm;
    public bool flag;
    public int GetChance;
    Character character;
    public int hp;
    public GameObject feslogo;
    Bullet bullet;
    private ScoreManager sm;
    void Start() {
        bgm = GameObject.Find("fesbgm").GetComponent<bgm>();
        //audiosource = GameObject.Find("ガチャBGM").GetComponent<AudioSource>();
    }

    void Delay () {
        if(flag){
            hp += 50;
            feslogo.SetActive(false);
            //bgm.gsbgm.
        }
        flag = false;
    }
    void OnTriggerEnter2D(Collider2D c) {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        if (layerName != "Bullet (Player)") return;

        // ヒットポイントを減らす
        hp = hp - 1;
            Debug.Log("納税");
            feslogo.SetActive(false);
            GetChance = 3;

            if (hp <= 0)
            {
            flag = true;
                feslogo.SetActive(true);
                GetChance = 6;
            //audiosource.clip = fesbgm;
            //audiosource.Play();
            Invoke("Delay", 10f);
        }
    }
}
