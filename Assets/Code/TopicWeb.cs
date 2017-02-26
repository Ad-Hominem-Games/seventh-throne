using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicWeb : MonoBehaviour {

    public List<TopicWebNode> nodes;
    public TopicWebNode current_node;
    public List<TopicWebNode> explored;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (current_node.winning_player_number != 0)
        {
            explored.Add(current_node);
            List<TopicWebNode> possibilities = current_node.neighbors;
            List<TopicWebNode> valid_possibilities = new List<TopicWebNode>();
            foreach (TopicWebNode possibility in possibilities)
            {
                if (!explored.Contains(possibility))
                {
                    valid_possibilities.Add(possibility);
                }
            }
            // choose a node from valid_possibilities to make the new current_node
        }
	}
}
