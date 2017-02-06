﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_Component : MonoBehaviour
{

    public string input;
    public Image OpinionFill;
    public Image ComposureBar;
    public bool madeMistake = false;
    public bool isPlayingGame = false;
    public GameObject ethosSymbol;
    public GameObject pathosSymbol;
    public GameObject logosSymbol;
    public int GameNo = 0;
    public GameObject BalloonOne;
    public GameObject BalloonTwo;
    public GameObject BalloonThree;
    public GameObject BalloonFour;
    public GameObject BalloonFive;
    public GameObject BalloonSix;


    // Use this for initialization
    void Start()
    {
        ComposureBar.fillAmount = 1.0f;
        OpinionFill.fillAmount = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        //gaffe mechanic
        if (ComposureBar.fillAmount <= 0.0)
        {
            gaffe();
        }

        //mistake, as in messed up a minigame
        if (madeMistake == true)
        {
            ComposureBar.fillAmount -= 0.2f;
            madeMistake = false;
        }

        //different argument types (points)
        input = Input.inputString;
        if (isPlayingGame == true && input == "b")
        {
            isPlayingGame = false;
            EndPoint();
        }
        if (isPlayingGame == false)
        {
            switch (input)
            {
                case "z":     //pathos
                    pathosSymbol.SetActive(true);
                    isPlayingGame = true;
                    //start a pathos minigame
                    break;

                case "x":     //logos
                    logosSymbol.SetActive(true);
                    isPlayingGame = true;
                    //start a logos minigame
                    break;

                case "c":     //ethos
                    ethosSymbol.SetActive(true);
                    isPlayingGame = true;
                    //start an ethos minigame
                    break;
            }
        }
    }

    public void gaffe()
    {
        if (OpinionFill.fillAmount <= 0.025f)
        {
            OpinionFill.fillAmount = 0.0f;
        }
        else
        {
            OpinionFill.fillAmount -= 0.025f;
        }
        ComposureBar.fillAmount = 1.0f;
    }

    public void EndPoint()
    {
            ethosSymbol.SetActive(false);
            pathosSymbol.SetActive(false);
            logosSymbol.SetActive(false);
        BalloonOne.SetActive(false);
        BalloonTwo.SetActive(false);
        BalloonThree.SetActive(false);
        BalloonFour.SetActive(false);
        BalloonFive.SetActive(false);
        BalloonSix.SetActive(false);
    }

}