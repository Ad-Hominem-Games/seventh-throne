using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeThis : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(Random.Range(-45, 45), 150);
	}
	
	// Update is called once per frame
	void Update () {
       this.gameObject.transform.position -= new Vector3(0, 2);

        if (this.gameObject.transform.position.y < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
