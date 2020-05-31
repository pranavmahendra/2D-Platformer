using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLevel : MonoBehaviour
{
    //Code in 3 back buttons.

    public List<Button> MainMenuButtons;

    [SerializeField]
    private List<GameObject> Canvas;

    private void Start()
    {
        //Start button click.
        MainMenuButtons[0].onClick.AddListener(StartGame);

        //On Application Quit click
        MainMenuButtons[2].onClick.AddListener(OnApplicationQuit);

        //Options button click
        MainMenuButtons[1].onClick.AddListener(LoadOptions);

        //Controls button click
        MainMenuButtons[3].onClick.AddListener(LoadControls);

        //Back Buttons click
        MainMenuButtons[4].onClick.AddListener(LoadStart);

    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    //Load options box
    public void LoadOptions()
    {
       
        //Start canvas will switch off
        Canvas[1].gameObject.SetActive(false);
        //Options canvas will load.
        Canvas[0].gameObject.SetActive(true);


    }

    //load control box
    public void LoadControls()
    {
        Canvas[2].gameObject.SetActive(true);
    }

    //Load start menu
    public void LoadStart()
    {
        Canvas[0].gameObject.SetActive(false);

        Canvas[1].gameObject.SetActive(true);
    }


}
