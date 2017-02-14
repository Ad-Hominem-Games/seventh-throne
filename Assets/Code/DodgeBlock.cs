using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBlock : MonoBehaviour {

    public GameObject Parent;

	// Use this for initialization
	void Start () {
        GetComponent<BoxCollider2D>().enabled = true;
	}
	
   
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.localPosition.x > -45)
        {
            this.gameObject.transform.position -= new Vector3(5, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.localPosition.x < 45)
        {
            this.gameObject.transform.position += new Vector3(5, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Parent.GetComponent<dodgeGame>().lostGame();
    }
}
