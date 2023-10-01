namespace Graphs.Domain.Tests;

public class GraphTests
{
    [Fact]
    public void WhenAddVertex_ThenVertexAdded()
    {
        // Arrange
        var graph = new Graph();
        
        // Act
        graph.AddVertex(1);
        
        // Assert
        Assert.True(graph.HasVertex(1));
    }
    
    [Fact]
    public void WhenAddEdge_ThenEdgeAdded()
    {
        // Arrange
        var graph = new Graph();
        graph.AddVertex(1);
        graph.AddVertex(2);
        
        // Act
        graph.AddEdge(1, 2);
        
        // Assert
        Assert.True(graph.HasEdge(1, 2));
    }
    
    [Fact]
    public void WhenHasCycle_ThenReturnTrue()
    {
        // Arrange
        var graph = new Graph();
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 1);
        
        // Act
        var hasCycle = graph.FindCycle();
        
        // Assert
        Assert.True(hasCycle.Item1);
    }

    [Fact]
    public void WhenNotHaveCycles_TheReturnFalse()
    {
        // Arrange
        var graph = new Graph();
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        
        // Act
        var hasCycle = graph.FindCycle();
        
        // Assert
        Assert.False(hasCycle.Item1);
    }
}