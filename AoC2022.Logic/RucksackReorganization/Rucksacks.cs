namespace AoC2022.Logic.RucksackReorganization;

public class Rucksacks
{
    private readonly ICollection<Rucksack> _rucksacks;

    private Rucksacks(ICollection<Rucksack> rucksacks)
    {
        _rucksacks = rucksacks ?? throw new ArgumentNullException(nameof(rucksacks));
    }

    public static Rucksacks Load(string input)
    {
        var rucksacks = input.ToLines()
            .Select(l => new Rucksack(l))
            .ToArray();
        return new Rucksacks(rucksacks);
    }

    public int GetPriorityOfDuplicateItemType()
    {
        return _rucksacks
            .Select(FindDuplicateItemTypeInCompartments)
            .Select(CalculatePriority)
            .Sum();
    }

    public int GetPriorityOfDuplicateItemTypePerGroup(int groupSize = 1)
    {
        if (groupSize <= 0) throw new ArgumentOutOfRangeException(nameof(groupSize));

        return _rucksacks.Chunk(groupSize)
            .Select(FindDuplicateItemTypeInGroup)
            .Select(CalculatePriority)
            .Sum();
    }

    private static int CalculatePriority(char c)
    {
        return c <= 'Z' ? c - 38 : c - 96;
    }

    private static char FindDuplicateItemTypeInCompartments(Rucksack r)
    {
        var (compartment1, compartment2) = r.SplitCompartments();
        var hashSet = compartment1.ToHashSet();
        return compartment2.FirstOrDefault(c => hashSet.Contains(c));
    }

    private static char FindDuplicateItemTypeInGroup(Rucksack[] g)
    {
        HashSet<char>? hashSet = null;
        foreach (var rucksack in g)
        {
            var duplicateItemTypes = rucksack.Data
                .Where(c => hashSet?.Contains(c) ?? true)
                .Distinct()
                .ToArray();
            if (duplicateItemTypes.Length == 1)
                return duplicateItemTypes[0];

            hashSet = duplicateItemTypes.ToHashSet();
        }

        throw new Exception("could not find single duplicate item type");
    }
}