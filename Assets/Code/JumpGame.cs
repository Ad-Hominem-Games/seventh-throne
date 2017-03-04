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
    public float SpawnRate = 1f;
    public float WinTime;
    public float spawngoal;
    public float currentspawn;
    public Vector3 defaultPosition = new Vector3(-61, 50);

    // Use this for initialization
    void Start()
    {
        Spawntime = Time.time + 0.01f;
        WinTime += Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > Spawntime)
        {
            spawnPlatform();
        }

        //if (Time.time > WinTime)
        //{
        //   ResetGame();
        //    player.GetComponent<player_Component>().Combo++;
        //    player.GetComponent<player_Component>().PlayLogos();

        //}
        TimeBar.fillAmount = (WinTime - Time.time) / 10f;
    }

    public void spawnPlatform()
    {

        Instantiate(platform, this.gameObject.transform);
        Spawntime = Time.time + SpawnRate;

    }

    public void lostGame()
    {
        player.GetComponent<player_Component>().madeMistake = true;
        ResetGame();
        player.GetComponent<player_Component>().PlayLogos();

    }

    public void ResetGame()
    {
        WinTime = Time.time + 10f;
        JumpPlayer.transform.localPosition = new Vector3(0, 180);
        foreach (JumpPlatform Platform in GetComponentsInChildren<JumpPlatform>())
        {
            Destroy(Platform.gameObject);
        }
        this.gameObject.SetActive(false);
    }
}
