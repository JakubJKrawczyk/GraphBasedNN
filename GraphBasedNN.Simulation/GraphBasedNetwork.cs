namespace GraphBasedNN.Simulation;

public class GraphBasedNetwork
{
    private Dictionary<ulong, Node> _nodes;
    private List<ulong> _inputNodeIds;
    private List<ulong> _outputNodeIds;
    
    public void PrintSummary()
    {
        throw new NotImplementedException();
    }

    public void SetInput(params List<double> doubles)
    {
        throw new NotImplementedException();
    }

    public int RecommendedIterations { get; set; }

    public double[] Output => _outputNodeIds.Select(outNodeId => _nodes[outNodeId].Output).ToArray();

    public void Iterate()
    {
        foreach (var (_, node) in _nodes)
        {
            node.Forward();
        }
    }

    public void SaveToFile(string path)
    {
        throw new NotImplementedException();
    }
    
    public static GraphBasedNetwork LoadFromFile(string path)
    {
        throw new NotImplementedException();
    }
}