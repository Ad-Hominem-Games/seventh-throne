using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dodgeGame : MonoBehaviour {

    public GameObject block;
    public bool hitBlock = false;
    public float Spawntime;

	// Use this for initialization
	void Start () {
        Spawntime = Time.time + 5f;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Time.time > Spawntime)
        {
            spawnBlock();
        }

        if (hitBlock == true)
        {
            Reset();
        }
	}

    public void spawnBlock()
    {

        Instantiate(block, this.gameObject.transform);
        Spawntime = Time.time + 2f;

    }


    public void Reset()
    {
        hitBlock = false;
        print("I Reset!");
    }
}
