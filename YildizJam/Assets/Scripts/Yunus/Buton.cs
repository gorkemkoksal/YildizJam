using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{

    AudioSource au;

    private void Start() {
        au = GetComponent<AudioSource>();
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");

    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");

    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");

    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");

    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;

    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("StopCanvas").SetActive(false);
    }
    public void Audio()
    {
        au.mute = !au.mute;
    }
    
        
    
}
