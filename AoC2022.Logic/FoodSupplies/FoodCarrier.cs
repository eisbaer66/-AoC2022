namespace AoC2022.Logic.FoodSupplies;

public class FoodCarrier
{
    public int TotalCalories { get; private set; }


    public void Add(int calories)
    {
        TotalCalories += calories;
    }
}