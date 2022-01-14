using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReworkedAlgorithms))]
public class NewInitialization : MonoBehaviour
{
    // Store in scriptable object for easy access;
    public Node_SO[] NodeArray;
    public EdgeWithNode_SO[] EdgeArray;
    private ReworkedAlgorithms _reworkAlgorithms;

    private void Awake()
    {
        _reworkAlgorithms = GetComponent<ReworkedAlgorithms>();
    }

    private void Start()
    {                
        GraphWithNodes graph = new GraphWithNodes(NodeArray, EdgeArray);

        // foreach (Node_SO node in NodeArray)
        // {
        //     node.Distance = 0;
        // }

        // DisplayGraph(graph);

        resetDistance();
        _reworkAlgorithms.BellmanFordAlgorithm(graph, NodeArray[0], NodeArray[2]);
        resetDistance();
        _reworkAlgorithms.BellmanFordAlgorithm(graph, NodeArray[1], NodeArray[4]);
        resetDistance();
        _reworkAlgorithms.BellmanFordAlgorithm(graph, NodeArray[1], NodeArray[3]);
        resetDistance();
        _reworkAlgorithms.BellmanFordAlgorithm(graph, NodeArray[2], NodeArray[4]);
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