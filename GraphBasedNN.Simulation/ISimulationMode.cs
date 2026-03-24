namespace GraphBasedNN.Simulation;

public interface ISimulationMode
{
    void Run();
    string Name { get; }
}