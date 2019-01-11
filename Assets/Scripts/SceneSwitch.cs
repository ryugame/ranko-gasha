using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    ResultScore result;

    void Start () {
        result = GameObject.Find("Resultmanager").GetComponent<ResultScore>();
    }

    // メソッドに「public」が付いていることを確認する（ポイント）
    public void GameScene(){
        SceneManager.LoadScene("GameScene");
    }
    public void Result()
    {
        SceneManager.LoadScene("Result");
    }
    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void SceneClose()
    {
        Application.Quit();
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
Application.OpenURL("http://www.yahoo.co.jp/");
#else
Application.Quit();
#endif
    }
}
