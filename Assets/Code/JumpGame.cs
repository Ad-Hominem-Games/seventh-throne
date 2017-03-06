using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpGame : MonoBehaviour {

    public GameObject player;
    public GameObject platform;
    public GameObject JumpPlayer;
    public Image TimeBar;
    public float Spawntime;
    public float SpawnRate = 0.8f;
    public float WinTime;
    public float spawngoal;
    public float currentspawn;
    private int SpawnNumber = 0;
    public Vector3 defaultPosition = new Vector3(-61, 50);

    // Use this for initialization
    void Start()
    {
        spawnPlatform();
        spawnPlatform();
        WinTime = Time.time + 6f;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > Spawntime)
        {
            spawnPlatform();
        }

        if (Time.time > WinTime)
        {
           ResetGame();
            if (player.GetComponent<player_Component>() != null)
            {
                player.GetComponent<player_Component>().Combo++;
                player.GetComponent<player_Component>().PlayLogos();
            }
            if (player.GetComponent<player2Component>() != null)
            {
                player.GetComponent<player2Component>().Combo++;
                player.GetComponent<player2Component>().PlayLogos();
            }

            }
        TimeBar.fillAmount = (WinTime - Time.time) / 6f;
    }

    public void spawnPlatform()
    {

        GameObject Clone = Instantiate(platform, this.gameObject.transform);
        Clone.GetComponent<JumpPlatform>().PlatNumber = SpawnNumber;
        SpawnNumber++;
        Spawntime = Time.time + SpawnRate;

    }

    public void lostGame()
    {
        if (player.GetComponent<player_Component>() != null)
        {
            player.GetComponent<player_Component>().madeMistake = true;
            ResetGame();
            player.GetComponent<player_Component>().PlayLogos();
        }
        if (player.GetComponent<player2Component>() != null)
        {
            player.GetComponent<player2Component>().madeMistake = true;
            ResetGame();
            player.GetComponent<player2Component>().PlayLogos();
        }
    }

    public void ResetGame()
    {
            WinTime = Time.time + 6f;
            JumpPlayer.transform.localPosition = new Vector3(0, 10);
            SpawnNumber = 0;
            Spawntime = Time.time;
            foreach (JumpPlatform Platform in GetComponentsInChildren<JumpPlatform>())
            {
                Destroy(Platform.gameObject);
            }
            spawnPlatform();
            spawnPlatform();
            spawnPlatform();
            this.gameObject.SetActive(false);
    }
}
