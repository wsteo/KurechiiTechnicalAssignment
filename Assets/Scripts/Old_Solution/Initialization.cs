using UnityEngine;

public class Initialization : MonoBehaviour
{
    public void Start()
    {
        int V = 5;
        int E = 6;

        Graph graph = new Graph(V, E);

        graph.EdgeArray[0].src = 0;
        graph.EdgeArray[0].dest = 1;
        graph.EdgeArray[0].weight = 6;

        graph.EdgeArray[1].src = 0;
        graph.EdgeArray[1].dest = 3;
        graph.EdgeArray[1].weight = 7;

        graph.EdgeArray[2].src = 0;
        graph.EdgeArray[2].dest = 4;
        graph.EdgeArray[2].weight = 3;

        graph.EdgeArray[3].src = 1;
        graph.EdgeArray[3].dest = 2;
        graph.EdgeArray[3].weight = 8;

        graph.EdgeArray[4].src = 2;
        graph.EdgeArray[4].dest = 3;
        graph.EdgeArray[4].weight = 6;

        graph.EdgeArray[5].src = 3;
        graph.EdgeArray[5].dest = 4;
        graph.EdgeArray[5].weight = -2;

        Algorithm.BellmanFord(graph, 0, 2);
        Algorithm.BellmanFord(graph, 1, 4);
        Algorithm.BellmanFord(graph, 1, 3);
        Algorithm.BellmanFord(graph, 2, 4);
    }
}