using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
