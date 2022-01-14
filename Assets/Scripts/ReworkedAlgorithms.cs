using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReworkedAlgorithms : MonoBehaviour
{
    // private readonly int NO_PARENT = -1;

    public void BellmanFordAlgorithm(GraphWithNodes graph, Node_SO startingNode, Node_SO goalNode)
    {
        int numberOfVertices = graph.Vertices;
        int numberOfEdges = graph.Edge;

        bool[] visitedNode = new bool[numberOfVertices];
        // Node_SO[] parents = new Node_SO[numberOfVertices];

        List<Node_SO> path = new List<Node_SO>();

        _solutionPath.Clear();
        
        foreach (Node_SO node in graph.VerticesArray)
        {
            node.Distance = int.MaxValue;
            node.NoParent = false;
            node.Parent = null;
        }

        // for (int i = 0; i < numberOfVertices; i++)
        // {
        //     if (graph.VerticesArray[i].NodeName == startingNode.NodeName)
        //     {
                
        //     }
        // }
        
        startingNode.Distance = 0;

        // startingNode.Parent = null;

        // startingNode.NoParent = true;

        startingNode.NoParent = true;

        for (int i = 1; i < numberOfVertices - 1; ++i)
        {
            for (int j = 0; j < numberOfEdges; ++j)
            {
                Node_SO u = graph.EdgesArray[j].SourceNode;
                Node_SO v = graph.EdgesArray[j].DestinationNode;
                int weight = graph.EdgesArray[j].Weight;

                if (u.Distance != int.MaxValue && u.Distance + weight < v.Distance)
                {
                    v.Parent = u;
                    v.Distance = u.Distance + weight;
                }
            }
        }

        for (int j = 0; j < numberOfEdges; ++j)
        {
            Node_SO u = graph.EdgesArray[j].SourceNode;
            Node_SO v = graph.EdgesArray[j].DestinationNode;
            int weight = graph.EdgesArray[j].Weight;

            if (u.Distance != int.MaxValue && u.Distance + weight < v.Distance)
            {
                Debug.Log ("Graph contains negative weight cycle!");
                return;
            }
        }

        PrintPath(goalNode, graph.VerticesArray);
        PrintResult(numberOfVertices, startingNode, goalNode);
    }

    private List<string> _solutionPath = new List<string>();
    private void PrintPath(Node_SO currentNode, Node_SO[] verticesArray)
    {
        if (currentNode.NoParent)
        {
            _solutionPath.Add(currentNode.NodeName);
            // Debug.Log(currentNode.NodeName);
            return;
        }

        foreach (Node_SO node in verticesArray)
        {
            if (currentNode.name == node.name)
            {
                _solutionPath.Add(node.NodeName);
                PrintPath(node.Parent, verticesArray);
                // Debug.Log(node.NodeName);
            }
        }
    }
    
    private void PrintResult(int numberOfVertices, Node_SO sourceNode, Node_SO destinationNode)
    {
        Debug.Log ($"Shortest path from {sourceNode.NodeName} to {destinationNode.NodeName} = {destinationNode.Distance}");

        _solutionPath.Reverse();
        Debug.Log("Solution Path: " + String.Join(" -> ", _solutionPath));
    }
}
