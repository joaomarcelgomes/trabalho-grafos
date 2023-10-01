using Graphs.Domain;
using Graphs.Domain.App.Utils;

var graph = new Graph();

FileGraph.Read(graph, Path.GetFullPath("../../../Assets/file.txt"));

var cycle = graph.FindCycle();

Console.WriteLine($"Has cycle? {cycle.Item1}");

foreach(var element in cycle.Item2)
    Console.WriteLine($"{element}");