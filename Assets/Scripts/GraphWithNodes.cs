using System;
using System.Collections;
using System.Collections.Generic;

public class GraphWithNodes
{
    public int Vertices;
    public int Edge;
    public Node_SO[] VerticesArray;
    public EdgeWithNode_SO[] EdgesArray;

    public GraphWithNodes(Node_SO[] nodeArray ,EdgeWithNode_SO[] edgesArray)
    {
        Vertices = nodeArray.Length;

        VerticesArray = nodeArray;
        
        Edge = edgesArray.Length;

        EdgesArray = new EdgeWithNode_SO[edgesArray.Length];

        EdgesArray = edgesArray;

        // for (int i = 0; i < edgesArray.Length; ++i)
        // {
        //     EdgesArray[i] = new EdgeWithNode_SO();
        // }
    }
}