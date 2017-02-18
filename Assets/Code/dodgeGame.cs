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
            player.GetComponent<player_Component>().Combo++;
            player.GetComponent<player_Component>().PlayPathos();

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
        player.GetComponent<player_Component>().madeMistake = true;
        ResetGame();
        player.GetComponent<player_Component>().PlayEthos();

    }

    public void ResetGame()
    {
        print(player);
        WinTime = Time.time + 10f;
        SpawnRate = 0.5f - player.GetComponent<player_Component>().GameNo * .05f;
        foreach (DodgeThis bolt in GetComponentsInChildren<DodgeThis>())
        {
            Destroy(bolt.gameObject);
        }
        this.gameObject.SetActive(false);
    }
}
