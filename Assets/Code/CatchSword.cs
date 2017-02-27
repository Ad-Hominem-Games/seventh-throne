using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchSword : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float temp = GetComponentInParent<CatchGame>().currentspawn;
        float goal = GetComponentInParent<CatchGame>().spawngoal;
        temp += Random.Range(2, 5) * Mathf.Sign(goal - temp);
        transform.localPosition = new Vector3(temp, 100);
        GetComponentInParent<CatchGame>().currentspawn = temp;
        if (Mathf.Abs(goal - temp)<2f)
        {
            GetComponentInParent<CatchGame>().spawngoal = Random.Range(-40, 40);    
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition -= new Vector3(0,4);

        if (this.gameObject.transform.localPosition.y < -130)
        {
            this.GetComponentInParent<CatchGame>().lostGame();
        }
    }
}
