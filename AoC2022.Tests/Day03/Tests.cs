using AoC2022.Logic.RucksackReorganization;

namespace AoC2022.Tests.Day03;

public class Tests
{
    [Test]
    [TestCase(Data.Example, 157)]
    [TestCase(Data.Input, 7785)]
    public void Part1(string input, int expectedPriority)
    {
        var rucksack = Rucksacks.Load(input);
        var priority = rucksack.GetPriorityOfDuplicateItemType();
        
        Assert.That(priority, Is.EqualTo(expectedPriority));
    }

    [Test]
    [TestCase(Data.Example, 70)]
    [TestCase(Data.Input, 2633)]
    public void Part2(string input, int expectedScore)
    {
        var rucksack = Rucksacks.Load(input);
        var priority = rucksack.GetPriorityOfDuplicateItemTypePerGroup(3);

        Assert.That(priority, Is.EqualTo(expectedScore));
    }
}