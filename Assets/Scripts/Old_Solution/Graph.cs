using System;

public class Graph
{
    public int Vertex, Edge;
    public Edge[] EdgeArray;

    public Graph(int v, int e)
    {
        Vertex = v;
        Edge = e;
        EdgeArray = new Edge[e];
        for (int i = 0; i < e; ++i)
            EdgeArray[i] = new Edge();
    }
}