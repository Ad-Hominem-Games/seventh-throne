using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dodgeGame : MonoBehaviour {

    public GameObject player;
    public GameObject Bolt;
    public Image TimeBar;
    public float Spawntime;
    public float SpawnRate = 0.5f;
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
            spawnBolt();
        }

        if (Time.time > WinTime)
        {
            ResetGame();
            if (player.GetComponent<player_Component>() != null)
            {
                player.GetComponent<player_Component>().Combo++;
                player.GetComponent<player_Component>().PlayEthos();
            }
            if (player.GetComponent<player2Component>() != null)
            {
                player.GetComponent<player2Component>().Combo++;
                player.GetComponent<player2Component>().PlayEthos();
            }

        }
        TimeBar.fillAmount = (WinTime - Time.time) / 10f;
    }

    public void spawnBolt()
    {

        Instantiate(Bolt, this.gameObject.transform);
        Spawntime = Time.time + SpawnRate;

    }

    public void lostGame()
    {
        if (player.GetComponent<player_Component>() != null)
        {
            player.GetComponent<player_Component>().madeMistake = true;
            ResetGame();
            player.GetComponent<player_Component>().PlayEthos();
        }
        if (player.GetComponent<player2Component>() != null)
        {
            player.GetComponent<player2Component>().madeMistake = true;
            ResetGame();
            player.GetComponent<player2Component>().PlayEthos();
        }
    }

    public void ResetGame()
    {
        if (player.GetComponent<player_Component>() != null)
        {
            WinTime = Time.time + 10f;
            SpawnRate = 0.5f - player.GetComponent<player_Component>().Combo * 0.05f;
            foreach (DodgeThis bolt in GetComponentsInChildren<DodgeThis>())
            {
                Destroy(bolt.gameObject);
            }
            this.gameObject.SetActive(false);
        }
        if (player.GetComponent<player2Component>() != null)
        {
            WinTime = Time.time + 10f;
            SpawnRate = 0.5f - player.GetComponent<player2Component>().Combo * .05f;
            foreach (DodgeThis bolt in GetComponentsInChildren<DodgeThis>())
            {
                Destroy(bolt.gameObject);
            }
            this.gameObject.SetActive(false);
        }
    }
}
