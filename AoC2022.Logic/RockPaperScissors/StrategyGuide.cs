namespace AoC2022.Logic.RockPaperScissors;

public class StrategyGuide
{
    private readonly ICollection<Round> _rounds;

    private StrategyGuide(ICollection<Round> rounds)
    {
        _rounds = rounds ?? throw new ArgumentNullException(nameof(rounds));
    }

    public static StrategyGuide LoadAsPlayerShape(string input)
    {
        var rounds = input.ToLines()
            .Select(line =>
            {
                var opponentShape = GetShape(line[0]);
                var playerShape = GetShape(line[2]);
                return new Round(opponentShape, playerShape);
            })
            .ToList();

        return new StrategyGuide(rounds);
    }

    public static StrategyGuide LoadAsOutcome(string input)
    {
        var rounds = input.ToLines()
            .Select(line =>
            {
                var opponentShape = GetShape(line[0]);
                var outcome = GetOutcome(line[2]);
                return new Round(opponentShape, outcome);
            })
            .ToList();

        return new StrategyGuide(rounds);
    }

    private static Shape GetShape(char c)
    {
        return c switch
        {
            'A' or 'X' => Shape.Rock,
            'B' or 'Y' => Shape.Paper,
            'C' or 'Z' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }

    private static Outcome GetOutcome(char c)
    {
        return c switch
        {
            'X' => Outcome.Lose,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }

    public int CalculateScore()
    {
        return _rounds.Sum(r => r.CalculateScore());
    }
}