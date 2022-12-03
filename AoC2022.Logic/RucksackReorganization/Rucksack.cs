namespace AoC2022.Logic.RucksackReorganization;

public class Rucksack
{
    public Rucksack(string data)
    {
        Data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public string Data { get; }

    public (string compartment1, string compartment2) SplitCompartments()
    {
        var compartmentSize = Data.Length / 2;
        var compartment1 = Data.Substring(0, compartmentSize);
        var compartment2 = Data.Substring(compartmentSize, compartmentSize);
        return (compartment1, compartment2);
    }
}