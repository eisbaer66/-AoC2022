using AoC2022.Logic.FoodSupplies;

namespace AoC2022.Tests.Day01;

public class Tests
{
    [Test]
    [TestCase(Data.Example, 24000)]
    [TestCase(Data.Input, 71780)]
    public void Part1(string input, int expectedTotalCalories)
    {
        var foodSupply = FoodSupply.Load(input);
        var carrier = foodSupply.FindCarrierWithMostCalories();

        Assert.That(carrier, Is.Not.Null);
        Assert.That(carrier!.TotalCalories, Is.EqualTo(expectedTotalCalories));
    }

    [Test]
    [TestCase(Data.Example, 45000)]
    [TestCase(Data.Input, 212489)]
    public void Part2(string input, int expectedTotalCalories)
    {
        var foodSupply = FoodSupply.Load(input);
        var carriers = foodSupply.FindTopCarriers();
        
        // ReSharper disable PossibleMultipleEnumeration
        Assert.That(carriers, Is.Not.Null);
        Assert.That(carriers.Take(3).Sum(c => c.TotalCalories), Is.EqualTo(expectedTotalCalories));
        // ReSharper restore PossibleMultipleEnumeration
    }
}