namespace GraphBasedNN.Simulation;

public class Node
{
    private IActivationFunction _activationFunction;
    private (double, double) _cooridinates;
    private ulong _id;
    private Dictionary<ulong, Node> _nextNeighbours;
    private Dictionary<ulong, double> _weights;
    
    private Dictionary<ulong, double> _inputValues;
    private Dictionary<ulong, double> _processValues;
    
    public Node(ulong id, (double, double) coordinates, IActivationFunction activationFunction)
    {
        _id = id;
        _cooridinates = coordinates;
        _activationFunction = activationFunction;
        _nextNeighbours = new Dictionary<ulong, Node>();
        _weights = new Dictionary<ulong, double>();
    }
    
    public ulong Id => _id;
    
    public (double, double) Coordinates => _cooridinates;
    
    public double Output { get; private set; }
    
    public void SetInputValue(ulong nodeId, double value)
    {
        _inputValues[nodeId] = value;
    }

    public void Forward()
    {
        _processValues = _inputValues.ToDictionary(x => x.Key, x => x.Value);
        _inputValues = new();
        if(_inputValues.Count != _weights.Count)
            throw new InvalidOperationException("Input values count does not match weights count.");
        
        Output = _weights
            .Select(w => w.Value * _processValues[w.Key])
            .Sum(x => _activationFunction.Calculate(x));

        
        foreach (var (_, node) in _nextNeighbours) 
            node.SetInputValue(Id, Output);
    }
    
    public Node WithNextNeighbour(Node node)
    {
        _nextNeighbours[node.Id] = node;
        return this;
    }

    public Node WithWeight(ulong nodeId, double weight)
    {
        _weights[nodeId] = weight;
        return this;
    }

    public Node Init()
    {
        _processValues = _weights.Select(x => x.Key).ToDictionary(x => x, _ => 0.0);
        return this;
    }
}