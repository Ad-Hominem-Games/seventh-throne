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
    public int Combo = 0;
    public GameObject SpamPathos;
    public GameObject DodgeEthos;
    public GameObject IncantorumLogos;
    public GameObject Recovery;

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
        if (isPlayingGame == true && Input.GetKeyDown(KeyCode.Space))
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
                    PlayPathos();
                    //start a pathos minigame
                    break;

                case "x":     //logos
                    logosSymbol.SetActive(true);
                    PlayLogos();
                    //start a logos minigame
                    break;

                case "c":     //ethos
                    ethosSymbol.SetActive(true);
                    PlayEthos();
                    //start an ethos minigame
                    break;

                case "v":   //recover
                    PlayRecover();
                    break;
            }
        }
        SetBubble();
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
        //damage to opinion
        OpinionFill.fillAmount += GameNo * Combo * 0.005f;

        //pathos->logos->ethos
        /*if (current game (ie, the point just ended) -> other player current game
                           (if they are making one, activeSelf))
              { other player's minigame becomes harder, 
                proportional to strength of argument
              }
        */
        /* make a current game variable, only set to null at end of EndPoint()
         * when EndPoint is called, it checks said current game
         * then, see what other game is active (get component, set to a local variable)
         * then a switch on that. as in, switch on current game, each case offers
         * results for if super effective.
         * then, write the effects the game has
         * potentially sway screen, invert colors, flip upside down, etc)
        */
        /*foreach (GameObject bubble in GameObject.FindGameObjectsWithTag("speech"))
        {
            bubble.SetActive(false);
        }
        */
        /*foreach (GameObject symbol in GameObject.FindGameObjectsWithTag("symbol"))
        {
            symbol.SetActive(false);
        }
        */

        //set everything back to zero
        SpamPathos.SetActive(false);
        DodgeEthos.SetActive(false);
        IncantorumLogos.SetActive(false);
        Recovery.SetActive(false);
            ethosSymbol.SetActive(false);
            pathosSymbol.SetActive(false);
            logosSymbol.SetActive(false);
        BalloonOne.SetActive(false);
        BalloonTwo.SetActive(false);
        BalloonThree.SetActive(false);
        BalloonFour.SetActive(false);
        BalloonFive.SetActive(false);
        BalloonSix.SetActive(false);
        GameNo = 0;
        Combo = 0;
    }

    public void SetBubble()
    {
        switch (GameNo)
        {
            case 1:
                BalloonOne.SetActive(true);
                break;
            case 2:
                BalloonTwo.SetActive(true);
                break;
            case 3:
                BalloonThree.SetActive(true);
                break;
            case 4:
                BalloonFour.SetActive(true);
                break;
            case 5:
                BalloonFive.SetActive(true);
                break;
            case 6:
                BalloonSix.SetActive(true);
                break;
        }
    }
    public void PlayEthos()
    {
        isPlayingGame = true;
        GameNo++;
        //DodgeEthos.GetComponent<dodgeGame>().ResetGame();
        DodgeEthos.SetActive(true);
        ethosSymbol.SetActive(true);
    }
    public void PlayPathos()
    {
        isPlayingGame = true;
        GameNo++;
        SpamPathos.SetActive(true);
        pathosSymbol.SetActive(true);
    }
    public void PlayLogos()
    {
        isPlayingGame = true;
        GameNo++;
        //IncantorumLogos.GetComponent<Incantorum>().ResetGame();
        //IncantorumLogos.SetActive(true);
    }
    public void PlayRecover()
    {
        isPlayingGame = true;
        Recovery.SetActive(true);
    }
}
