using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Incantorum : MonoBehaviour
{
    public Text FirstKey;
    public Text SecKey;
    public Text ThiKey;
    public Text FouKey;
    public Text FivKey;

    public Image TimeBar;
    public GameObject Player;
    public float timer;
    public float difficulty;

    public void Start()
    {
        SelectKeys();
        timer = Time.time;
        difficulty = 10f - Player.GetComponent<player_Component>().GameNo;
    }

    public void Update()
    {
        if (Input.GetKey(FirstKey.text))
        {
            FirstKey.color = Color.green;
            if (Input.GetKey(SecKey.text))
            {
                SecKey.color = Color.green;
                if (Input.GetKey(ThiKey.text))
                {
                      ThiKey.color = Color.green;
                    if (Input.GetKey(FouKey.text))
                    {
                        FouKey.color = Color.green;
                        if (Input.GetKey(FivKey.text))
                        {
                            FivKey.color = Color.green;
                            WinIncantorum();
                        }
                    }
                }
            }
        }
        TimeBar.fillAmount = (difficulty - (Time.time - timer)) / difficulty;
        if (timer + difficulty < Time.time)
        {
            LoseIncantorum();
        }
    }

    public void SelectKeys()
    {
        char Temp = (char)('a' + Random.Range(0, 26));
        FirstKey.text = Temp.ToString();
        char Temp2 = (char)('a' + Random.Range(0, 26));
        SecKey.text = Temp2.ToString();
        char Temp3 = (char)('a' + Random.Range(0, 26));
        ThiKey.text = Temp3.ToString();
        char Temp4 = (char)('a' + Random.Range(0, 26));
        FouKey.text = Temp4.ToString();
        char Temp5 = (char)('a' + Random.Range(0, 26));
        FivKey.text = Temp5.ToString();
    }

    public void WinIncantorum()
    {
        ResetGame();
        this.gameObject.SetActive(false);
        Player.GetComponent<player_Component>().Combo++;
        Player.GetComponent<player_Component>().PlayLogos();
    }

    public void LoseIncantorum()
    {
        ResetGame();
        this.gameObject.SetActive(false);
        Player.GetComponent<player_Component>().madeMistake = true;
        Player.GetComponent<player_Component>().PlayLogos();
    }

    public void ResetGame()
    {
        SelectKeys();
        FirstKey.color = Color.white;
        SecKey.color = Color.white;
        ThiKey.color = Color.white;
        FouKey.color = Color.white;
        FivKey.color = Color.white;
        difficulty = 10f - Player.GetComponent<player_Component>().GameNo;
        timer = Time.time;
    }

}
