using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour {

    public int PlatNumber;

    // Use this for initialization
    void Start()
    {
        if (PlatNumber == 0)
        {
            this.gameObject.transform.localPosition = new Vector3(0, 0);
        }
        else if (PlatNumber == 1)
        {
            this.gameObject.transform.localPosition = new Vector3(0, 80);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(Random.Range(-30, 30), 150);
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition -= new Vector3(0, 1.5f);

        if (this.gameObject.transform.localPosition.y < -140)
        {
            Destroy(this.gameObject);
        }
    }
}
