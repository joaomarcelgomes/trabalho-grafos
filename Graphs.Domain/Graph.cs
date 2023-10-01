namespace Graphs.Domain;

public class Graph
{
    private readonly Dictionary<int, List<int>> _adjacency = new();

    public void AddVertex(int vertex)
    {
        _adjacency[vertex] = new List<int>();
    }
    
    public void AddEdge(int vertex1, int vertex2)
    {
        var hasVertex1 = _adjacency.ContainsKey(vertex1);
        var hasVertex2 = _adjacency.ContainsKey(vertex2);
        
        if (!hasVertex1)
            AddVertex(vertex1);
        
        if (!hasVertex2)
            AddVertex(vertex2);
        
        _adjacency[vertex1].Add(vertex2);
        _adjacency[vertex2].Add(vertex1);
    }
    
    public void SearchInWidth(int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        
        queue.Enqueue(start);
        visited.Add(start);
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine(current);
            
            foreach (var neighbor in _adjacency[current].Where(neighbor => !visited.Contains(neighbor)))
            {
                visited.Add(neighbor);
                queue.Enqueue(neighbor);
            }
        }
    }

    public (bool, List<int>) FindCycle()
    {
        var visited = new HashSet<int>();
        var cycle = new List<int>();

        if (_adjacency.Keys.Any(vertex => !visited.Contains(vertex) && FindCycleRecursive(vertex, -1, visited, cycle)))
        {
            return (true, cycle);
        }

        // Nenhum ciclo foi encontrado
        return (false, cycle);
    }
    
    private bool FindCycleRecursive(int vertex, int parent, ISet<int> visited, List<int> cycle)
    {
        visited.Add(vertex);
        cycle.Add(vertex);

        foreach (var neighbor in _adjacency[vertex])
        {
            if (!visited.Contains(neighbor))
            {
                if (FindCycleRecursive(neighbor, vertex, visited, cycle))
                {
                    // Um ciclo foi encontrado
                    return true;
                }
            }
            else if (neighbor != parent)
            {
                // Um ciclo foi encontrado
                cycle.Add(neighbor);
                return true;
            }
        }

        // Remove o vértice atual do caminho se não houver um ciclo
        cycle.Remove(vertex);

        // Nenhum ciclo foi encontrado nesta parte do grafo
        return false;
    }

    public bool HasVertex(int i)
    {
        return _adjacency.ContainsKey(i);
    }
    
    public bool HasEdge(int vertex1, int vertex2)
    {
        return _adjacency[vertex1].Contains(vertex2);
    }
}