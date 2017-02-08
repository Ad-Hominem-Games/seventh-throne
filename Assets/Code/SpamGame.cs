using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamGame : MonoBehaviour {

    public GameObject Player;
    public GameObject Background;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0, 0.75f);
        if (Input.GetKeyDown(KeyCode.X))
        {
            this.transform.position += new Vector3(0, 15);
        }
        if (this.transform.localPosition.y < -140)
        {
            this.transform.localPosition = new Vector3(0, -140);
        }
        if (this.transform.localPosition.y > 135)
        {
            this.transform.localPosition = new Vector3(0, 135);
            WinGame();
        }
	}

    private void WinGame()
    {
        this.transform.localPosition = new Vector3(0, -100);
        Background.gameObject.SetActive(false);
        Player.GetComponent<player_Component>().Combo++;
        Player.GetComponent<player_Component>().PlayPathos();
    }
}
