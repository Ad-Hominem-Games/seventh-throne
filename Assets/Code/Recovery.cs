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
        if (this.transform.localPosition.y <= -135)
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
        //try a switch instead (1 or 2, motion changes based on which one
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (this.transform.localPosition.y < 90 &&
                this.transform.localPosition.y > 60)
            {
                CalmDown();
            }
        }
	}

    public void CalmDown()
    {
        player.GetComponent<player_Component>().ComposureBar.fillAmount += 0.1f;
    }
}
