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
            List<TopicWebNode> possible_choices = new List<TopicWebNode>();
            foreach (TopicWebNode neighbor in current_node.neighbors)
            {
                if (!explored.Contains(neighbor))
                {
                    possible_choices.Add(neighbor);
                }
            }
            // choose a node from possible choices to make the new current_node
        }
	}
}
