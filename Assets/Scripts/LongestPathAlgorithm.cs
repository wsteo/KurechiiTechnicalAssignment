using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LongestPathAlgorithm : MonoBehaviour
{
    public void TopologicalSortUtil(Node_SO node, bool[] visited, Stack<Node_SO> stack, GraphWithNodes graph)
    {
        visited [node.NodeIndex] = true;

        foreach (var vertex in graph.VerticesArray)
        {
            if (!visited[vertex.NodeIndex])
                TopologicalSortUtil(vertex, visited, stack, graph);
        }

        stack.Push(node);
    }

    public void FindLongestPath(GraphWithNodes graph, Node_SO startingNode, Node_SO goalNode)
    {
        int numberOfVertices = graph.Vertices;
        int numberOfEdges = graph.Edge;

        Stack<Node_SO> stack = new Stack<Node_SO>();
        bool[] visitedNode = new bool[numberOfVertices];

        List<Node_SO> path = new List<Node_SO>();

        foreach (Node_SO node in graph.VerticesArray)
        {
            visitedNode[node.NodeIndex] = false;
        }

        foreach (Node_SO node in graph.VerticesArray)
        {
            if(visitedNode[node.NodeIndex] == false)
            {
                TopologicalSortUtil(node, visitedNode, stack, graph);
            }
        }

        foreach (Node_SO node in graph.VerticesArray)
        {
            node.Distance = int.MinValue;
            node.NoParent = false;
            node.Parent = null;
        }

        startingNode.Distance = 0;
        startingNode.NoParent = true;
        
            
    }
}