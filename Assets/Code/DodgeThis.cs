using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeThis : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(Random.Range(-45, 45), 150);
        GetComponent<BoxCollider2D>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
       this.gameObject.transform.localPosition -= new Vector3(0, 6);

        if (this.gameObject.transform.localPosition.y < -130)
        {
            Destroy(this.gameObject);
        }
	}
}
