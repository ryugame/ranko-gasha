using UnityEngine;
using System.Collections;

public class SceneMashutdownnager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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