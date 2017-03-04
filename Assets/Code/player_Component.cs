using System.Collections;
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
    public GameObject currentGame;
    public GameObject opponentGame;
    public int gameType;
    public int boardShift;
    public int whatMess;
    public bool upsidedown = false;
    public Vector3 defaultPosition = new Vector3(61, 70);

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
            if (opponentGame != null)
            {
                opponentGame.transform.localPosition = new Vector3(61, 70);
                opponentGame.transform.localRotation = Quaternion.identity;
                if (opponentGame.GetComponent<JumpGame>() != null)
                {
                    opponentGame.GetComponent<JumpGame>().player.GetComponent<player2Component>().upsidedown = false;
                }
            }
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

        //attacks
        if (GameObject.FindGameObjectsWithTag("game") != null)
        {
            currentGame = GameObject.FindGameObjectWithTag("game");
            Attacks();
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
            OpinionFill.fillAmount -= 0.05f;
        }
        ComposureBar.fillAmount = 1.0f;
    }

    public void EndPoint()
    {
        //damage to opinion
        OpinionFill.fillAmount += GameNo * Combo * 0.005f;

        //pathos->logos->ethos
        foreach (GameObject symbol in GameObject.FindGameObjectsWithTag("symbol"))
        {
            symbol.SetActive(false);
        }
        foreach (GameObject bubble in GameObject.FindGameObjectsWithTag("speech"))
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
        if (GameObject.FindGameObjectWithTag("game2") != null)
        {
            opponentGame = GameObject.FindGameObjectWithTag("game2");
            switch (gameType)
            {
                case 1:
                    if (opponentGame.GetComponent<CatchGame>() != null)
                    {
                        opponentGame.GetComponent<CatchGame>().player.GetComponent<player2Component>().Shift();
                    }
                    break;
                case 2:
                    if (opponentGame.GetComponent<JumpGame>() != null)
                    {
                        opponentGame.GetComponent<JumpGame>().player.GetComponent<player2Component>().Flip();
                    }
                    break;
                case 3:
                    if (opponentGame.GetComponent<dodgeGame>() != null)
                    {
                        opponentGame.GetComponent<dodgeGame>().player.GetComponent<player2Component>().Spin();
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
            if (SpamPathos.GetComponent<CatchGame>().transform.localPosition.x >= -61)
            {
                boardShift = 2;
            }
            if (SpamPathos.GetComponent<CatchGame>().transform.localPosition.x <= -301)
            {
                boardShift = 1;
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
            if (DodgeEthos.GetComponent<dodgeGame>().transform.localPosition.x >= -61)
            {
                boardShift = 2;
            }
            if (DodgeEthos.GetComponent<dodgeGame>().transform.localPosition.x <= -301)
            {
                boardShift = 1;
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
            if (IncantorumLogos.GetComponent<JumpGame>().transform.localPosition.x >= -61)
            {
                boardShift = 2;
            }
            if (IncantorumLogos.GetComponent<JumpGame>().transform.localPosition.x <= -301)
            {
                boardShift = 1;
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
                if (IncantorumLogos.GetComponent<JumpGame>().transform.localPosition.x > -75)
                {
                    IncantorumLogos.GetComponent<JumpGame>().transform.position -= new Vector3(30, 0, 0);
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
            if (this.DodgeEthos.GetComponent<dodgeGame>().transform.localPosition.x >= -180)
            {
                this.DodgeEthos.GetComponent<dodgeGame>().transform.position -= new Vector3(8, 0, 0);
            }
            this.DodgeEthos.GetComponent<dodgeGame>().transform.Rotate(new Vector3(0, 0, -0.5f));
        }
    }
}
