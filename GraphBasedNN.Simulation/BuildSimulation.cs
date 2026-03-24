namespace GraphBasedNN.Simulation;

public class BuildSimulation: ISimulationMode
{

    public void Run()
    {
        GeneticBuilder builder = new(); // Tworzymy genetyczny template sieci
        builder.FeedRandom(); // Ustawiamy losowe wartości; .FeedFromFile() dla wczytywania z pliku
        builder.SetInputShape([2, 4]); // Ustawiamy shape na dane wejściowe
        builder.SetOutputShape([3]); // Ustawiamy shape na dane wyjściowe
        
        // Tu można jakoś go trenować
        GraphBasedNetwork network = builder.Build(); // Budujemy sieć z template GeneticBuilder
        network.PrintSummary(); // Wypisujemy podsumowanie sieci
        network.SetInput([
            1, 5,
            2, 3,
            0, .5,
            -1, -.8,
        ]);
        var neededIterations = network.RecommendedIterations;
        List<double[]> intermediateOutputs = [];
        for (int iteration = 0; iteration < neededIterations; iteration++)
        {
            network.Iterate();
            intermediateOutputs.Add(network.Output);
        }
        var output = intermediateOutputs[^1];
        Console.WriteLine($"Output: {string.Join(", ", output)}");
    }

    public string Name => "build";
}