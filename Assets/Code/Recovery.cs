using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour {

    public GameObject player;
    public int move = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localPosition.y >= 120)
        {
            move = 1;
        }
        if (this.transform.localPosition.y <= -130)
        {
            move = 2;
        }
        switch (move)
        {
            case 1:
                this.transform.position -= new Vector3(0, 10);
                break;
            case 2:
                this.transform.position += new Vector3(0, 10);
                break;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (player.GetComponent<player_Component>() != null)
            {

                if (this.transform.localPosition.y < 90 &&
                    this.transform.localPosition.y > 60)
                {
                    CalmDown();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (player.GetComponent<player2Component>() != null)
            {
                if (this.transform.localPosition.y < 90 &&
                    this.transform.localPosition.y > 60)
                {
                    CalmDown();
                }
            }
        }
	}

    public void CalmDown()
    {
        if (player.GetComponent<player_Component>() != null)
        {
            player.GetComponent<player_Component>().ComposureBar.fillAmount += 0.1f;
        }
        if (player.GetComponent<player2Component>() != null)
        {
            player.GetComponent<player2Component>().ComposureBar.fillAmount += 0.1f;
        }
    }
}
