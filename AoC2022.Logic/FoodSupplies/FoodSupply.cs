namespace AoC2022.Logic.FoodSupplies;

public class FoodSupply
{
    private readonly List<FoodCarrier> _carriers;

    public FoodSupply(List<FoodCarrier> carriers)
    {
        _carriers = carriers ?? throw new ArgumentNullException(nameof(carriers));
    }
    public static FoodSupply Load(string input)
    {
        var lines = input.ToLines();

        var foodCarriers = new List<FoodCarrier>();

        var currentCarrier = new FoodCarrier();
        foodCarriers.Add(currentCarrier);
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                currentCarrier = new FoodCarrier();
                foodCarriers.Add(currentCarrier);
                continue;
            }

            if (!int.TryParse(line, out int calories))
            {
                throw new Exception($"could not parse {line} as int");
            }

            currentCarrier.Add(calories);
        }

        return new FoodSupply(foodCarriers);
    }

    public FoodCarrier? FindCarrierWithMostCalories()
    {
        return _carriers.MaxBy(c => c.TotalCalories);
    }

    public IOrderedEnumerable<FoodCarrier> FindTopCarriers()
    {
        return _carriers.OrderByDescending(c => c.TotalCalories);
    }
}