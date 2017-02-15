using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dodgeGame : MonoBehaviour {

    public GameObject block;
    public float Spawntime;
    public float SpawnRate = 2f;
    public float WinTime = 4f;

    // Use this for initialization
    void Start()
    {
        Spawntime = Time.time + 1f;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > Spawntime)
        {
            spawnBlock();
        }

        if (Time.time > WinTime && SpawnRate > 0.15f)
        {
            WinTime = Time.time + 2f;
            //GetComponentInParent<player_Component>().GameNo++;
            Reset();

        }

    }

    public void spawnBlock()
    {

        Instantiate(block, this.gameObject.transform);
        Spawntime = Time.time + SpawnRate;

    }

    public void lostGame()
    {
        //composure--;
        foreach (DodgeThis block in GetComponentsInChildren<DodgeThis>())
        {
            Destroy(block.gameObject);
        }
        spawnBlock();
        if (SpawnRate > 0.15f)
        {
            Reset();
        }

    }

    public void Reset()
    {
        print("I Reset!");
        SpawnRate -= 0.1f;
    }

    public void ResetGame()
    {
        SpawnRate = 2f;
    }
}
