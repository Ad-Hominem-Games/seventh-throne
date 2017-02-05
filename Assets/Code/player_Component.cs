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
        if (isPlayingGame == false)
        {
            switch (input)
            {
                case "z":     //pathos
                              //start a pathos minigame
                    break;

                case "x":     //logos
                              //start a logos minigame
                    break;

                case "c":     //ethos
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
}
