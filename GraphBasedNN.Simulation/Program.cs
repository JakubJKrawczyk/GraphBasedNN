namespace GraphBasedNN.Simulation;

public static class Program
{
    public static void Main(string[] args)
    {
        var simulationMode = typeof(Program).Assembly.GetTypes()
            .Where(t => typeof(ISimulationMode).IsAssignableFrom(t) && t is {IsInterface: false, IsAbstract: false})
            .Select(t => (ISimulationMode)Activator.CreateInstance(t)!)
            .First(mode => mode.Name.Equals(args[0], StringComparison.CurrentCultureIgnoreCase));
        
        simulationMode.Run();

    }
}