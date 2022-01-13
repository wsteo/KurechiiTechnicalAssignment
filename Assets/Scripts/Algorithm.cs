using UnityEngine;
public static class Algorithm
{
    public static void BellmanFord(Graph graph, int src, int dest)
    {
        int V = graph.Vertex, E = graph.Edge;
        int[] dist = new int[V];

        for (int i = 0; i < V; ++i)
            dist[i] = int.MaxValue;
        dist[src] = 0;

        for (int i = 1; i < V; ++i)
        {
            for (int j = 0; j < E; ++j)
            {
                int u = graph.EdgeArray[j].src;
                int v = graph.EdgeArray[j].dest;
                int weight = graph.EdgeArray[j].weight;
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    dist[v] = dist[u] + weight;
            }
        }

        for (int j = 0; j < E; ++j)
        {
            int u = graph.EdgeArray[j].src;
            int v = graph.EdgeArray[j].dest;
            int weight = graph.EdgeArray[j].weight;
            if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
            {
                Debug.Log("Graph contains negative weight cycle");
                return;
            }
        }

        PrintArray(dist, V, src, dest);
    }

    private static void PrintArray(int[] dist, int numOfVertices, int src ,int dest)
    {
        for (int i = 0; i < numOfVertices; ++i)
        {
            if (i == dest)
                Debug.Log($"Shortest path from {ConvertToAlphabet(src)} to {ConvertToAlphabet(dest)} = {dist[i]}");
        }
    }

    private static string ConvertToAlphabet(int index)
    {
        switch (index)
        {
            case 0: return "A";
            case 1: return "B";
            case 2: return "C";
            case 3: return "D";
            case 4: return "E";
        }
        return "Invalid index";
    }

}

