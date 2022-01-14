using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReworkedAlgorithms : MonoBehaviour
{
    private readonly int NO_PARENT = -1;
    public void BellmanFordAlgorithm(GraphWithNodes graph, Node_SO startingNode, Node_SO goalNode)
    {

        int numberOfVertices = graph.Vertices;
        int numberOfEdges = graph.Edge;
        
        // int[] distance = new int[numberOfVertices];

        // for (int i = 0; i < numberOfVertices; ++i)
        // {
        //     distance[i] = int.MaxValue;
        // }

        // int startingNodeIndex = 0;
        // distance[startingNodeIndex] = 0;

        foreach (Node_SO node in graph.VerticesArray)
        {
            node.Distance = int.MaxValue;
        }
        
        startingNode.Distance = 0;

        for (int i = 1; i < numberOfVertices - 1; ++i)
        {
            for (int j = 0; j < numberOfEdges; ++j)
            {
                Node_SO u = graph.EdgesArray[j].SourceNode;
                Node_SO v = graph.EdgesArray[j].DestinationNode;
                int weight = graph.EdgesArray[j].Weight;

                if (u.Distance != int.MaxValue && u.Distance + weight < v.Distance)
                    v.Distance = u.Distance + weight;
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

        PrintResult(numberOfVertices, startingNode, goalNode);
    }

    private void PrintResult(int numberOfVertices, Node_SO sourceNode, Node_SO destinationNode)
    {
        Debug.Log ($"Shortest path from {sourceNode.NodeName} to {destinationNode.NodeName} = {destinationNode.Distance}");
    }
}
