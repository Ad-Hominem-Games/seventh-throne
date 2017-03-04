using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {


    public GameObject p1;
    public GameObject p2;
    public float timeLeft = 60;
    public int matchNo;
    public float p1fill;
    public float p2fill;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    //end state
    public void GameOver()
    {
        Debug.Log("Game Over");
        p1fill = p1.GetComponent<player_Component>().ComposureBar.fillAmount;
        p2fill = p2.GetComponent<player2Component>().ComposureBar.fillAmount;
        matchNo++;
        if (matchNo > 3)
        {
            SetOver();
        }
        if (p1fill == p2fill)
        {
            //...tie game, need to figure that out
        }
        else if (p1fill > p2fill)
        {
            //trigger topic web, but with p1 in control
        }
        else if (p2fill > p1fill)
        {
            //trigger topic web, but with p2 in control
        }
        timeLeft = 60;
    }
    public void SetOver()
    {
        if (p1fill > p2fill)
        {
            print("Player One Wins!!");
        }
        else if (p2fill > p1fill)
        {
            print("Player Two Wins!");
        }
        //freeze game
        print("Now Go Home");
    }
}
