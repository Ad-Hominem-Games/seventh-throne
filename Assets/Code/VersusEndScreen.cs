using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VersusEndScreen : MonoBehaviour {

    public Text winnertext;
    private int winner;
	// Use this for initialization
	void Start () {
        winner = PlayerPrefs.GetInt("winner");
        if (winner == 1)
        {
            winnertext.text = "Leaf (Player 1)"; 
        } 
        if (winner == 2)
        {
            winnertext.text = "Leaf (Player 2)";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BackStart()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    void Rematch()
    {
        SceneManager.LoadScene("Debate_Scene");
    }

}
