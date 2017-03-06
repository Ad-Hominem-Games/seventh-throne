using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicWebNode : MonoBehaviour {

    public Color not_yet_contested_color = Color.gray;
    public Color player_one_victory_color;
    public Color player_two_victory_color;
    public Image focusedCircle;
    public bool focused = false;

    public int nodenumber;

    public int winning_player_number = 0;

    public enum Status { Uncontested, Contesting, PlayerOneVictory, PlayerTwoVictory }

    public Status status = Status.Uncontested;

    public List<TopicWebNode> neighbors;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CheckStatus();
        this.gameObject.GetComponent<Image>().color = GetColor();
        if (focused == true && focusedCircle.gameObject.activeSelf == false)
        {
            focusedCircle.gameObject.SetActive(true);
        }
        if (focused == false && focusedCircle.gameObject.activeSelf == true)
        {
            focusedCircle.gameObject.SetActive(false);
        }
    }

    Color GetColor()
    {
        switch(status)
        {
            case Status.PlayerOneVictory:
                return player_one_victory_color;
            case Status.PlayerTwoVictory:
                return player_two_victory_color;
            default:
                return not_yet_contested_color;
        }
    }

    void CheckStatus()
    {
        switch (winning_player_number)
        {
            case 0:
                break;
            case 1:
                status = Status.PlayerOneVictory;
                break;
            case 2:
                status = Status.PlayerTwoVictory;
                break;
        }
    }
}
