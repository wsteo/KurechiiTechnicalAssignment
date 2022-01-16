using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReworkedAlgorithms : MonoBehaviour
{
    public void BellmanFordAlgorithm(GraphWithNodes graph, Node_SO startingNode, Node_SO goalNode)
    {
        
        int numberOfVertices = graph.Vertices;
        int numberOfEdges = graph.Edge;

        bool[] visitedNode = new bool[numberOfVertices];

        List<string> path = new List<string>();

        foreach (Node_SO node in graph.VerticesArray)
        {
            node.Distance = int.MaxValue;
            node.NoParent = false;
            node.Parent = null;
        }

        startingNode.Distance = 0;

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
                Debug.Log("Graph contains negative weight cycle!");
                return;
            }
        }

        Debug.Log("Shortest Path");
        PrintPath(goalNode, graph.VerticesArray, path);
        PrintResult(numberOfVertices, startingNode, goalNode, path);
    }

    public void FindLongestPath(GraphWithNodes graph, Node_SO startingNode, Node_SO goalNode)
    {
        int numberOfVertices = graph.Vertices;
        int numberOfEdges = graph.Edge;

        List<string> path = new List<string>();

        foreach (Node_SO node in graph.VerticesArray)
        {
            node.Distance = int.MinValue;
            node.NoParent = false;
            node.Parent = null;
        }

        startingNode.Distance = 0;
        startingNode.NoParent = true;

        for (int i = 1; i < numberOfVertices - 1; ++i)
        {
            for (int j = 0; j < numberOfEdges; ++j)
            {
                Node_SO u = graph.EdgesArray[j].SourceNode;
                Node_SO v = graph.EdgesArray[j].DestinationNode;
                int weight = graph.EdgesArray[j].Weight;

                if (v.Distance < u.Distance + weight)
                {
                    v.Parent = u;
                    v.Distance = u.Distance + weight;
                }
            }
        }

        Debug.Log("Longest Path");
        PrintPath(goalNode, graph.VerticesArray, path);
        PrintResult(numberOfVertices, startingNode, goalNode, path);
    }

    // public void ShortestPathWithNuts(GraphWithNodes graph, Node_SO startingNode, int targetNuts)
    // {
    //     int numberOfVertices = graph.Vertices;
    //     int numberOfEdges = graph.Edge;

    //     bool[] visitedNode = new bool[numberOfVertices];

    //     List<string> path = new List<string>();

    //     foreach (Node_SO node in graph.VerticesArray)
    //     {
    //         node.Distance = int.MaxValue;
    //         node.NoParent = false;
    //         node.Parent = null;
    //     }

    //     startingNode.Distance = 0;

    //     startingNode.NoParent = true;
        
    //     for (int i = 1; i < numberOfVertices - 1; ++i)
    //     {
    //         for (int j = 0; j < numberOfEdges; ++j)
    //         {
    //             Node_SO u = graph.EdgesArray[j].SourceNode;
    //             Node_SO v = graph.EdgesArray[j].DestinationNode;
    //             int weight = graph.EdgesArray[j].Weight;

    //             if (u.Distance != int.MaxValue && u.Distance + weight < v.Distance)
    //             {
    //                 v.Parent = u;
    //                 v.Distance = u.Distance + weight;
    //             }
    //         }
    //     }

    // }

    private void PrintPath(Node_SO currentNode, Node_SO[] verticesArray, List<string> solutionPath)
    {
        if (currentNode.NoParent)
        {
            solutionPath.Add(currentNode.NodeName);
            return;
        }

        foreach (Node_SO node in verticesArray)
        {
            if (currentNode.name == node.name)
            {
                solutionPath.Add(node.NodeName);
                PrintPath(node.Parent, verticesArray, solutionPath);
            }
        }
    }

    private void PrintResult(int numberOfVertices, Node_SO sourceNode, Node_SO destinationNode, List<string> solutionPath)
    {
        Debug.Log($"Distances from {sourceNode.NodeName} to {destinationNode.NodeName} = {destinationNode.Distance}");

        solutionPath.Reverse();
        Debug.Log("Path: " + String.Join(" -> ", solutionPath));
    }

    public void FindGoalNodeBasedOnNumOfNuts(GraphWithNodes graph, Node_SO startingNode, int numOfNuts)
    {
        int numberOfVertices = graph.Vertices;
        int numberOfEdges = graph.Edge;
        bool[] VisitedNode = new bool[numberOfVertices];

        int acculumationOfNuts = startingNode.NumberOfNuts;

        for (int i = 0; i < numberOfVertices; i++)
        {
            VisitedNode[i] = false;
        }

        VisitedNode[0] = true; //Starting Node is always visited

        foreach(Node_SO node in graph.VerticesArray)
        {
            foreach (Node_SO neighbourNode in node.neighbourNodes)
            {
                if (!VisitedNode[neighbourNode.NodeIndex])
                {
                    acculumationOfNuts += neighbourNode.NumberOfNuts;
                    VisitedNode[neighbourNode.NodeIndex] = true;
                    Debug.Log($"NeightbourNode = {neighbourNode.NumberOfNuts}, Current AcculumationOfNuts: {acculumationOfNuts}");
                }
            }
        }
    }
}
