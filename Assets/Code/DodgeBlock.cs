using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBlock : MonoBehaviour {

    public GameObject Parent;

	// Use this for initialization
	void Start () {
		
	}
	
   
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z) && this.gameObject.transform.localPosition.x > -45)
        {
            this.gameObject.transform.position -= new Vector3(5, 0);
        }
        if (Input.GetKey(KeyCode.C) && this.gameObject.transform.localPosition.x < 45)
        {
            this.gameObject.transform.position += new Vector3(5, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("When worlds collide");
    }
}
