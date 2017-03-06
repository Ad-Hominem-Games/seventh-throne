using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchSword : MonoBehaviour {

	// Use this for initialization
	void Start () {

          transform.localPosition = new Vector3(Random.Range(-40, 40),150);    
        
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition -= new Vector3(0,3);

        if (this.gameObject.transform.localPosition.y < -130)
        {
            this.GetComponentInParent<CatchGame>().lostGame();
        }
    }
}
