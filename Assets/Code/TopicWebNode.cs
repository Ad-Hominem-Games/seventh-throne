using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicWebNode : MonoBehaviour {

    public Color not_yet_contested_color = Color.gray;
    public Color player_one_victory_color = Color.blue;
    public Color player_two_victory_color = Color.red;

    public int winning_player_number = 0;

    public enum Status { Uncontested, Contesting, PlayerOneVictory, PlayerTwoVictory }

    public Status status = Status.Uncontested;

    public List<TopicWebNode> neighbors;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<SpriteRenderer>().color = GetColor();
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
}
