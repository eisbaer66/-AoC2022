using AoC2022.Logic.RockPaperScissors;

namespace AoC2022.Tests.Day02;

public class Tests
{
    [Test]
    [TestCase(Data.Example, 15)]
    [TestCase(Data.Input, 8933)]
    public void Part1(string input, int expectedScore)
    {
        var strategyGuide = StrategyGuide.LoadAsPlayerShape(input);
        var score = strategyGuide.CalculateScore();
        
        Assert.That(score, Is.EqualTo(expectedScore));
    }

    [Test]
    [TestCase(Data.Example, 12)]
    [TestCase(Data.Input, 11998)]
    public void Part2(string input, int expectedScore)
    {
        var strategyGuide = StrategyGuide.LoadAsOutcome(input);
        var score = strategyGuide.CalculateScore();

        Assert.That(score, Is.EqualTo(expectedScore));
    }
}