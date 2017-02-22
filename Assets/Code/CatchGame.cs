using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchGame : MonoBehaviour
{

    public GameObject player;
    public GameObject sword;
    public Image TimeBar;
    public float Spawntime;
    public float SpawnRate = 0.15f;
    public float WinTime;
    public float spawngoal;
    public float currentspawn;

    // Use this for initialization
    void Start()
    {
        Spawntime = Time.time + 1f;
        WinTime += Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > Spawntime)
        {
            spawnSword();
        }

        if (Time.time > WinTime)
        {
            ResetGame();
            if (player.GetComponent<player_Component>() != null)
            {
                player.GetComponent<player_Component>().Combo++;
                player.GetComponent<player_Component>().PlayPathos();
            }
            if (player.GetComponent<player2Component>() != null)
            {
                player.GetComponent<player2Component>().Combo++;
                player.GetComponent<player2Component>().PlayPathos();
            }

        }
        TimeBar.fillAmount = (WinTime - Time.time) / 10f;
    }

    public void spawnSword()
    {

        Instantiate(sword, this.gameObject.transform);
        Spawntime = Time.time + SpawnRate;

    }

    public void lostGame()
    {
        if (player.GetComponent<player_Component>() != null)
        {
            player.GetComponent<player_Component>().madeMistake = true;
            ResetGame();
            player.GetComponent<player_Component>().PlayPathos();
        }
        if (player.GetComponent<player2Component>() != null)
        {
            player.GetComponent<player2Component>().madeMistake = true;
            ResetGame();
            player.GetComponent<player2Component>().PlayPathos();
        }
    }

    public void ResetGame()
    {
        if (player.GetComponent<player_Component>() != null)
        {
            WinTime = Time.time + 10f;
            SpawnRate = 0.15f - player.GetComponent<player_Component>().GameNo * .005f;
            foreach (CatchSword sword in GetComponentsInChildren<CatchSword>())
            {
                Destroy(sword.gameObject);
            }
            this.gameObject.SetActive(false);
        }
        if (player.GetComponent<player2Component>() != null)
        {
            WinTime = Time.time + 10f;
            SpawnRate = 0.15f - player.GetComponent<player2Component>().GameNo * .005f;
            foreach (CatchSword sword in GetComponentsInChildren<CatchSword>())
            {
                Destroy(sword.gameObject);
            }
            this.gameObject.SetActive(false);
        }
    }
}
