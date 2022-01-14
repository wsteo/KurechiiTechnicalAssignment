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

    private void Awake()
    {
        _reworkAlgorithms = GetComponent<ReworkedAlgorithms>();
    }

    private void Start()
    {                
        GraphWithNodes graph = new GraphWithNodes(NodeArray, EdgeArray);

        Debug.Log(_description);
        resetDistance();
        
        _reworkAlgorithms.BellmanFordAlgorithm(graph, startingNode, goalNode);
    }

    public void DisplayGraph(GraphWithNodes graph)
    {
        for (int i = 0; i < graph.EdgesArray.Length; i++)
        {
            Debug.Log($"{graph.EdgesArray[i].SourceNode.NodeName} to {graph.EdgesArray[i].DestinationNode.NodeName}, Weight: {graph.EdgesArray[i].Weight}");
        }
    }

    public void resetDistance()
    {
        foreach (Node_SO node in NodeArray)
        {
            node.Distance = 0;
        }
    }
}