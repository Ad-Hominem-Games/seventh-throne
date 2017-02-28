using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{

    public float gravity = 1.2f;
    private bool touching = false;
    // Use this for initialization
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.localPosition.x > -45)
        {
            this.gameObject.transform.position -= new Vector3(5, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.localPosition.x < 45)
        {
            this.gameObject.transform.position += new Vector3(5, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && touching == true)
        {
            this.gameObject.transform.position += new Vector3(0, 100);
            touching = false;
            gravity = 1.2f;
        }
        this.gameObject.transform.position -= new Vector3(0, gravity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
        gravity = 0.7f;
    }
}
