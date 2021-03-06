using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReworkedAlgorithms))]
public class NewInitialization : MonoBehaviour
{
    [SerializeField] private string _description;

    // Store in scriptable object for easy access;
    public Node_SO[] NodeArray;
    public EdgeWithNode_SO[] EdgeArray;
    private ReworkedAlgorithms _reworkAlgorithms;
    [SerializeField] private Node_SO startingNode;
    [SerializeField] private Node_SO goalNode;

    [SerializeField] private bool _shortestPath;

    [SerializeField] private bool _longestPath;

    private void Awake()
    {
        _reworkAlgorithms = GetComponent<ReworkedAlgorithms>();
    }

    private void Start()
    {                
        GraphWithNodes graph = new GraphWithNodes(NodeArray, EdgeArray);

        resetDistance();

        Debug.Log("-----" + _description + "-----");

        if (_shortestPath)
        {
            _reworkAlgorithms.BellmanFordAlgorithm(graph, startingNode, goalNode);
        }
        
        if (_longestPath)
        {
            _reworkAlgorithms.FindLongestPath(graph, startingNode, goalNode);
        }
        // _reworkAlgorithms.ShortestPathWithNuts(graph,startingNode,5);
        // _reworkAlgorithms.FindGoalNodeBasedOnNumOfNuts(graph, startingNode, 5);
    }

    public void resetDistance()
    {
        foreach (Node_SO node in NodeArray)
        {
            node.Distance = 0;
        }
    }

    public void DisplayGraph(GraphWithNodes graph)
    {
        for (int i = 0; i < graph.EdgesArray.Length; i++)
        {
            Debug.Log($"{graph.EdgesArray[i].SourceNode.NodeName} to {graph.EdgesArray[i].DestinationNode.NodeName}, Weight: {graph.EdgesArray[i].Weight}");
        }
    }

}