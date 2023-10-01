namespace Graphs.Domain.App.Utils;

public abstract class FileGraph
{
    public static void Read(Graph graph, string path)
    {
        var lines = File.ReadAllLines(path);
        
        var vertices = int.Parse(lines[0]);

        for (var i = 1; i < vertices; i++)
        {
            var part = lines[i].Split(" ");
            
            var vertex = int.Parse(part[0]);

            for (var j = 1; j < part.Length; j++)
            {
                var neighbor = int.Parse(part[j]);
                graph.AddEdge(vertex, neighbor);
            }
        }
    }
}