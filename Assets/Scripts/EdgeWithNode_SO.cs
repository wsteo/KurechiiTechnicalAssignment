using System;

using UnityEngine;

[CreateAssetMenu(fileName = "Edge", menuName = "Graph/Edge", order = 0)]
public class EdgeWithNode_SO : ScriptableObject
{
    public Node_SO SourceNode;
    public Node_SO DestinationNode;
    public int Weight;

    // public EdgeWithNode()
    // {
    //     SourceNode = null;
    //     DestinationNode = null;
    //     Weight = 0;
    // }

    // public EdgeWithNode(Node_SO sourceNode, Node_SO destinationNode, int weight)
    // {
    //     SourceNode = sourceNode;
    //     DestinationNode = destinationNode;
    //     Weight = weight;
    // }

}