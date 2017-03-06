using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour {

    public float gravity = 3f;
    private bool touching = false;
    private Vector3 jump;
    private bool jumpcomplete = true;
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
                jump = this.gameObject.transform.localPosition + new Vector3(0, 100);
                jumpcomplete = false;
                touching = false;
                gravity = 3f;
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
                jump = this.gameObject.transform.localPosition + new Vector3(0, 100);
                jumpcomplete = false;
                touching = false;
                gravity = 3f;
            }
        }
        if (jumpcomplete == false)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x,(Mathf.Lerp(this.gameObject.transform.localPosition.y, jump.y, 0.2f)));
            if (jump.y - this.gameObject.transform.localPosition.y <= 20f)
            {
                jumpcomplete = true;
            }
        }
        this.gameObject.transform.localPosition -= new Vector3(0, gravity);
        if (this.gameObject.transform.localPosition.y <= -140)
        {
            this.GetComponentInParent<JumpGame>().lostGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
        gravity = 1.5f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
        gravity = 3f;
    }
}
