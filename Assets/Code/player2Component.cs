﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2Component : MonoBehaviour {

    public string input;
    public Image OpinionFill;
    public Image OpinionShow;
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
    public GameObject currentGame;
    public GameObject opponentGame;
    public int gameType;
    public int boardShift;
    public int whatMess;
    public int nodenumber;
    private int playerdouble;
    private int ethosdouble;
    private int pathosdouble;
    private int logosdouble;
    private int attackdouble;
    private int gaffedouble;
    private int gamedouble;
    public bool upsidedown;
    public bool TopicActive = false;
    public Vector3 defaultPosition = new Vector3(-61, 70);

    // Use this for initialization
    void Start () {
        ComposureBar.fillAmount = 1.0f;
        OpinionFill.fillAmount = 0.15f;
	}

    // Update is called once per frame
    void Update()
    {
        NodeVariance();
        if (TopicActive == false)
        {
            //gaffe mechanic
            if (ComposureBar.fillAmount <= 0.1)
            {
                gaffe();
            }

            //mistake, as in messed up a minigame
            if (madeMistake == true)
            {
                ComposureBar.fillAmount -= 0.2f *  attackdouble;
                madeMistake = false;
            }

            //different argument types (points)
            input = Input.inputString;
            if (isPlayingGame == true && Input.GetKeyDown(KeyCode.Return))
            {
                EndPoint();
            }
            if (isPlayingGame == false)
            {
                switch (input)
                {
                    case "b":     //pathos
                        PlayPathos();
                        if (pathosdouble == 2)
                        {
                            gamedouble = 2;
                        }
                        //start a pathos minigame
                        break;

                    case "n":     //logos
                        PlayLogos();
                        if (logosdouble == 2)
                        {
                            gamedouble = 2;
                        }
                        //start a logos minigame
                        break;

                    case "m":     //ethos
                        PlayEthos();
                        if (ethosdouble == 2)
                        {
                            gamedouble = 2;
                        }
                        //start an ethos minigame
                        break;

                    case "j":     //recover
                        PlayRecover();
                        break;
                }
            }
            SetBubble();
            OpinionShow.fillAmount = OpinionFill.fillAmount + Combo * 0.02f * playerdouble * gamedouble;
            //attacks
            if (GameObject.FindGameObjectsWithTag("game2") != null)
            {
                currentGame = GameObject.FindGameObjectWithTag("game2");
                Attacks();
            }
        }
    }

    public void gaffe()
    {
        if (OpinionFill.fillAmount <= 0.05f)
        {
            OpinionFill.fillAmount = 0.0f;
        }
        else
        {
            OpinionFill.fillAmount = OpinionFill.fillAmount * 2/3/gaffedouble;
        }
        ComposureBar.fillAmount = 1.0f;
    }

    public void EndPoint()
    {
        isPlayingGame = false;
        //damage to opinion
        OpinionFill.fillAmount += Combo * 0.02f * playerdouble * gamedouble;


        if (opponentGame != null)
        {
            opponentGame.transform.localPosition = new Vector3(-61, 70);
            opponentGame.transform.localRotation = Quaternion.identity;
            if (opponentGame.GetComponent<JumpGame>() != null)
            {
                opponentGame.GetComponent<JumpGame>().player.GetComponent<player_Component>().upsidedown = false;
            }
        }


        //pathos->logos->ethos
        foreach (GameObject symbol in GameObject.FindGameObjectsWithTag("symbol2"))
        {
            symbol.SetActive(false);
        }
        foreach (GameObject bubble in GameObject.FindGameObjectsWithTag("speech2"))
        {
            bubble.SetActive(false);
        }
        

        //set everything back to zero
        SpamPathos.SetActive(false);
        DodgeEthos.SetActive(false);
        IncantorumLogos.SetActive(false);
        Recovery.SetActive(false);
        GameNo = 0;
        Combo = 0;
    }

    public void SetBubble()
    {
        switch (Combo)
        {
            case 1:
                BalloonOne.SetActive(true);
                if (currentGame == SpamPathos)
                {
                    pathosSymbol.SetActive(true);
                }
                if (currentGame == DodgeEthos)
                {
                    ethosSymbol.SetActive(true);
                }
                if (currentGame == IncantorumLogos)
                {
                    logosSymbol.SetActive(true);
                }
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

    public void NodeVariance()
    {
        playerdouble = 1;
        pathosdouble = 1;
        ethosdouble = 1;
        logosdouble = 1;
        gaffedouble = 1;
        attackdouble = 1;
        gamedouble = 1;
        switch (nodenumber)
        {
            case 0:
                break;
            case 1:
                logosdouble = 2;
                break;
            case 2:
                pathosdouble = 2;
                break;
            case 3:
                ethosdouble = 2;
                break;
            case 4:
                gaffedouble = 2;
                break;
            case 5:
                attackdouble = 2;
                break;
            case 6:
                break;
            case 7:
                playerdouble = 2;
                break;
        }
    }

    public void PlayEthos()
    {
        isPlayingGame = true;
        GameNo++;
        DodgeEthos.GetComponent<dodgeGame>().ResetGame();
        DodgeEthos.SetActive(true);
    }
    public void PlayPathos()
    {
        isPlayingGame = true;
        GameNo++;
        SpamPathos.GetComponent<CatchGame>().ResetGame();
        SpamPathos.SetActive(true);
    }
    public void PlayLogos()
    {
        isPlayingGame = true;
        GameNo++;
        IncantorumLogos.GetComponent<JumpGame>().ResetGame();
        IncantorumLogos.SetActive(true);
    }
    public void PlayRecover()
    {
        isPlayingGame = true;
        Recovery.SetActive(true);

    }

    //attacking
    public void Attacks()
    {
        if (currentGame == DodgeEthos)
        {
            gameType = 1;
        }
        else if (currentGame == SpamPathos)
        {
            gameType = 2;
        }
        else if (currentGame == IncantorumLogos)
        {
            gameType = 3;
        }
        if (GameObject.FindGameObjectWithTag("game") != null)
        {
            opponentGame = GameObject.FindGameObjectWithTag("game");
            switch (gameType)
            {
                case 1:
                    if (opponentGame.GetComponent<CatchGame>() != null)
                    {
                        opponentGame.GetComponent<CatchGame>().player.GetComponent<player_Component>().Shift();
                    }
                    break;
                case 2:
                    if (opponentGame.GetComponent<JumpGame>() != null)
                    {
                        opponentGame.GetComponent<JumpGame>().player.GetComponent<player_Component>().Flip();
                    }
                    break;
                case 3:
                    if (opponentGame.GetComponent<dodgeGame>() != null)
                    {
                        opponentGame.GetComponent<dodgeGame>().player.GetComponent<player_Component>().Spin();
                    }
                    break;
            }
        }
    }

    /*
    //game screw up catch-all
    public void Hurting()
    {
        //wacky business:
        whatMess = Random.Range(1, 4);
        switch (whatMess)
        {
            case 1:
                Shift();
                break;
            case 2:
                Flip();
                break;
            case 3:
                Spin();
                break;
        }
    }
    */

    //being attacked
    public void Shift()
    {
        if (this.SpamPathos.activeSelf == true &&
            opponentGame != null &&
            opponentGame.activeSelf == true)
        {
            if (SpamPathos.GetComponent<CatchGame>().transform.localPosition.x <= 61)
            {
                boardShift = 1;
            }
            if (SpamPathos.GetComponent<CatchGame>().transform.localPosition.x >= 301)
            {
                boardShift = 2;
            }
            switch (boardShift)
            {
                case 1:
                    SpamPathos.GetComponent<CatchGame>().transform.position += new Vector3(3f, 0);
                    break;
                case 2:
                    SpamPathos.GetComponent<CatchGame>().transform.position -= new Vector3(3f, 0);
                    break;

            }
        }

        if (this.DodgeEthos.activeSelf == true)
        {
            if (DodgeEthos.GetComponent<dodgeGame>().transform.localPosition.x <= 61)
            {
                boardShift = 1;
            }
            if (DodgeEthos.GetComponent<dodgeGame>().transform.localPosition.x >= 301)
            {
                boardShift = 2;
            }
            switch (boardShift)
            {
                case 1:
                    DodgeEthos.GetComponent<dodgeGame>().transform.position += new Vector3(3f, 0);
                    break;
                case 2:
                    DodgeEthos.GetComponent<dodgeGame>().transform.position -= new Vector3(3f, 0);
                    break;
            }
        }
        if (this.IncantorumLogos.activeSelf == true)
        {
            if (IncantorumLogos.GetComponent<JumpGame>().transform.localPosition.x <= 61)
            {
                boardShift = 1;
            }
            if (IncantorumLogos.GetComponent<JumpGame>().transform.localPosition.x >= 301)
            {
                boardShift = 2;
            }
            switch (boardShift)
            {
                case 1:
                    IncantorumLogos.GetComponent<JumpGame>().transform.position += new Vector3(3f, 0);
                    break;
                case 2:
                    IncantorumLogos.GetComponent<JumpGame>().transform.position -= new Vector3(3f, 0);
                    break;
            }
        }
    }

    public void Flip()
    {
        if (this.IncantorumLogos.activeSelf == true &&
            opponentGame != null &&
            opponentGame.activeSelf == true)
        {
            if (upsidedown == false)
            {
                 upsidedown = true;
                if (IncantorumLogos.GetComponent<JumpGame>().transform.localPosition.x < 75)
                {
                    IncantorumLogos.GetComponent<JumpGame>().transform.position += new Vector3(30, 0, 0);
                }
                IncantorumLogos.GetComponent<JumpGame>().transform.Rotate(new Vector3(0, 0, 180));
            }
        }
    }

    public void Spin()
    {
        if (this.DodgeEthos.activeSelf == true &&
            opponentGame != null &&
            opponentGame.activeSelf == true)
        {
            if (this.DodgeEthos.GetComponent<dodgeGame>().transform.localPosition.x <= 180)
            {
                this.DodgeEthos.GetComponent<dodgeGame>().transform.position += new Vector3(8, 0, 0);
            }
            this.DodgeEthos.GetComponent<dodgeGame>().transform.Rotate(new Vector3(0, 0, 0.5f));
        }
    }
}
