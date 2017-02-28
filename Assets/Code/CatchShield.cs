using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchShield : MonoBehaviour {
    public GameObject Parent;

    // Use this for initialization
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.localPosition.x > -40)
        {
            if (this.Parent.GetComponentInParent<CatchGame>().player.GetComponent<player2Component>() != null)
            {
                this.gameObject.transform.localPosition -= new Vector3(3, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.localPosition.x < 40)
        {
            if (this.Parent.GetComponentInParent<CatchGame>().player.GetComponent<player2Component>() != null)
            {
                this.gameObject.transform.localPosition += new Vector3(3, 0);
            }
        }
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.localPosition.x > -40)
        {
            if (this.Parent.GetComponentInParent<CatchGame>().player.GetComponent<player_Component>() != null)
            {
                this.gameObject.transform.localPosition -= new Vector3(3, 0);
            }
        }
        if (Input.GetKey(KeyCode.D) && this.gameObject.transform.localPosition.x < 40)
        {
            if (this.Parent.GetComponentInParent<CatchGame>().player.GetComponent<player_Component>() != null)
            {
                this.gameObject.transform.localPosition += new Vector3(3, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

