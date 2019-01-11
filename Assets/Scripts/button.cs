using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
    public GameObject window;
	void Start () {
        //window = GameObject.Find("ウィンドウ");
	}
    public void wopen(){
        window.SetActive(true);
    }
    public void wclose()
    {
        window.SetActive(false);
    }
	void Update () {
		
	}
}
