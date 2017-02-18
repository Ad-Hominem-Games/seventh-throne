using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
      //  transform.localPosition = new Vector3(Random.Range(-30, 30), 150);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= new Vector3(0, 0);

        if (this.gameObject.transform.localPosition.y < -140)
        {
            Destroy(this.gameObject);
        }
    }
}
