using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Player;

public class LevelService : Monosingleton<LevelService>
{
    public GameObject GameOverCanvas;

    private int Currentindex;

    public List<Button> GameOverButtons;

    // Start is called before the first frame update
    void Start()
    {
        //Ellen Dead event.
        PlayerService.Instance.EllenDead += level_ellenDead;

        Currentindex = SceneManager.GetActiveScene().buildIndex;

  

        //Restart button
        GameOverButtons[0].onClick.AddListener(RestartButton);
        GameOverButtons[1].onClick.AddListener(MainMenu);
    }

    private void level_ellenDead()
    {
        StartCoroutine(GameOver(3));
    }

    //Game over canvas to be loaded after 3 seconds.
    //If died in pool this should come up immediately
    IEnumerator GameOver(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameOverCanvas.SetActive(true);
        
    }

    //Restart Button
    public void RestartButton()
    {
        SceneManager.LoadScene(Currentindex);
    }

    //Main Menu button
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
