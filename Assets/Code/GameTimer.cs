using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {


    public GameObject p1;
    public GameObject p2;
    public GameObject TopicWeb;
    public float timeLeft = 60;
    public int matchNo;
    public int nodenumber;
    public float p1fill;
    public float p2fill;
    public float p1compfill;
    public float p2compfill;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        text.text = ""+Mathf.Round(timeLeft);
        if (timeLeft <= 0)
        {
            GameOver();
        }
        p1.GetComponent<player_Component>().TopicActive = false;
        p2.GetComponent<player2Component>().TopicActive = false;
        p1.GetComponent<player_Component>().nodenumber = nodenumber;
        p2.GetComponent<player2Component>().nodenumber = nodenumber;
    }

    //end state
    public void GameOver()
    {
        p1.GetComponent<player_Component>().TopicActive = true;
        p2.GetComponent<player2Component>().TopicActive = true;
        p1compfill = p1.GetComponent<player_Component>().ComposureBar.fillAmount;
        p2compfill = p2.GetComponent<player2Component>().ComposureBar.fillAmount;
        matchNo++;
        if (matchNo > 3)
        {
            SetOver();
        }
        if (p1compfill == p2compfill)
        {
            int temp = (int)Mathf.Round(Random.Range(0, 1));
            if (temp == 0)
            {
                p1.GetComponent<player_Component>().EndPoint();
                p2.GetComponent<player2Component>().EndPoint();
                TopicWeb.SetActive(true);
                TopicWeb.GetComponent<TopicWeb>().current_node.GetComponent<TopicWebNode>().winning_player_number = 1;
            }
            else
            {
                p1.GetComponent<player_Component>().EndPoint();
                p2.GetComponent<player2Component>().EndPoint();
                TopicWeb.SetActive(true);
                TopicWeb.GetComponent<TopicWeb>().current_node.GetComponent<TopicWebNode>().winning_player_number = 2;
            }
        }
        else if (p1compfill > p2compfill)
        {
            p1.GetComponent<player_Component>().EndPoint();
            p2.GetComponent<player2Component>().EndPoint();
            TopicWeb.SetActive(true);
            TopicWeb.GetComponent<TopicWeb>().current_node.GetComponent<TopicWebNode>().winning_player_number = 1;
        }
        else if (p2compfill > p1compfill)
        {
            p1.GetComponent<player_Component>().EndPoint();
            p2.GetComponent<player2Component>().EndPoint();
            TopicWeb.SetActive(true);
            TopicWeb.GetComponent<TopicWeb>().current_node.GetComponent<TopicWebNode>().winning_player_number = 2;
        }
        timeLeft = 60;
        this.gameObject.SetActive(false);
    }
    public void SetOver()
    {
        p1fill = p1.GetComponent<player_Component>().OpinionFill.fillAmount;
        p2fill = p2.GetComponent<player2Component>().OpinionFill.fillAmount;
        if (p1fill >= p2fill)
        {
            PlayerPrefs.SetInt("winner", 1);
        }
        else if (p2fill > p1fill)
        {
            PlayerPrefs.SetInt("winner", 2);
        }
        //freeze game
        SceneManager.LoadScene("WinnerScreen");
        
    }
}
