using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject MainMenu;
    public GameObject CharacterSelectMenu;
    public GameObject TutorialMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        StartMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    void VersusMode()
    {
        MainMenu.SetActive(false);
        CharacterSelectMenu.SetActive(true);
    }

    void ReturnMain()
    {
        CharacterSelectMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    void TutorialBegin()
    {
        MainMenu.SetActive(false);
        TutorialMenu.SetActive(true);
    }

    void TutorialBack()
    {
        TutorialMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    void GameBegin()
    {
        SceneManager.LoadScene("Debate_Scene");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
