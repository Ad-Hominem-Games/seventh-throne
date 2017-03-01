using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour {

    public float gravity = 1.7f;
    private bool touching = false;
    // Use this for initialization
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        //player1
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.localPosition.x > -45)
        {
            if (this.GetComponentInParent<JumpGame>().player.GetComponent<player_Component>() != null)
            {
                this.gameObject.transform.localPosition -= new Vector3(5, 0);
            }
        }
        if (Input.GetKey(KeyCode.D) && this.gameObject.transform.localPosition.x < 45)
        {
            if (this.GetComponentInParent<JumpGame>().player.GetComponent<player_Component>() != null)
            {
                this.gameObject.transform.localPosition += new Vector3(5, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && touching == true)
        {
            if (this.GetComponentInParent<JumpGame>().player.GetComponent<player_Component>() != null)
            {
                this.gameObject.transform.localPosition += new Vector3(0, 100);
                touching = false;
                gravity = 1.7f;
            }
        }
        //player2
        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.localPosition.x > -45)
        {
            if (this.GetComponentInParent<JumpGame>().player.GetComponent<player2Component>() != null)
            {
                this.gameObject.transform.localPosition -= new Vector3(5, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.localPosition.x < 45)
        {
            if (this.GetComponentInParent<JumpGame>().player.GetComponent<player2Component>() != null)
            {
                this.gameObject.transform.localPosition += new Vector3(5, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && touching == true)
        {
            if (this.GetComponentInParent<JumpGame>().player.GetComponent<player2Component>() != null)
            {
                this.gameObject.transform.localPosition += new Vector3(0, 100);
                touching = false;
                gravity = 1.7f;
            }
        }
        this.gameObject.transform.localPosition -= new Vector3(0, gravity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
        gravity = 0.7f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
        gravity = 1.7f;
    }
}
