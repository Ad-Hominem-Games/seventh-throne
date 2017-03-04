using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicWeb : MonoBehaviour {

    public List<TopicWebNode> nodes;
    public TopicWebNode current_node;
    public TopicWebNode focused_node;

    public List<TopicWebNode> explored_topics;
    public List<TopicWebNode> potential_topics;

    public enum Status { Contesting, PlayerOnePicking, PlayerTwoPicking }

    public Status status = Status.Contesting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (status) {
            case Status.Contesting:
                switch (current_node.status)
                {
                    case TopicWebNode.Status.Contesting:
                        break;
                    case TopicWebNode.Status.PlayerOneVictory:
                        status = Status.PlayerOnePicking;
                        InitializePotentialTopics();
                        break;
                    case TopicWebNode.Status.PlayerTwoVictory:
                        status = Status.PlayerTwoPicking;
                        InitializePotentialTopics();
                        break;
                    default:
                        break;
                }
                break;
            case Status.PlayerOnePicking:
                PickNextTopic(KeyCode.A, KeyCode.D, KeyCode.Space);
                break;
            case Status.PlayerTwoPicking:
                PickNextTopic(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.H);
                break;
            default:
                break;
        }
	}

    void InitializePotentialTopics()
    {
        explored_topics.Add(current_node);
        potential_topics = new List<TopicWebNode>();
        foreach (TopicWebNode neighbor in current_node.neighbors)
        {
            if (!explored_topics.Contains(neighbor))
            {
                potential_topics.Add(neighbor);
            }
        }
    }

    void PickNextTopic(KeyCode left_key, KeyCode right_key, KeyCode select_key)
    {
        int focused_node_index = potential_topics.IndexOf(focused_node);
        if (Input.GetKeyDown(left_key))
        {
            focused_node_index -= 1;
            if (focused_node_index < 0)
            {
                focused_node_index = potential_topics.Count - 1;
            }
            focused_node = potential_topics[focused_node_index];
        }
        if (Input.GetKeyDown(right_key))
        {
            focused_node_index += 1;
            if (focused_node_index > potential_topics.Count - 1)
            {
                focused_node_index = 0;
            }
        }
        if (Input.GetKeyDown(select_key))
        {
            current_node = focused_node;
            focused_node = null;
            potential_topics = null;
            status = Status.Contesting;
        }
    }
}
