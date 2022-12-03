namespace AoC2022.Logic.RockPaperScissors;

public class Round
{
    private readonly Outcome _outcome;
    private readonly Shape _playerShape;

    public Round(Shape opponentShape, Shape playerShape)
    {
        _playerShape = playerShape;
        _outcome = GetOutcomeScore(opponentShape, playerShape);
    }

    public Round(Shape opponentShape, Outcome outcome)
    {
        _playerShape = GetPlayerShape(opponentShape, outcome);
        _outcome = outcome;
    }

    public int CalculateScore()
    {
        var outcomeScore = (int)_outcome;
        var shapeScore = (int)_playerShape;

        return outcomeScore + shapeScore;
    }

    private static Outcome GetOutcomeScore(Shape opponentShape, Shape playerShape)
    {
        if (opponentShape == playerShape)
            return Outcome.Draw;

        return (opponentShape, playerShape) switch
        {
            (Shape.Rock, Shape.Paper) => Outcome.Win,
            (Shape.Rock, Shape.Scissors) => Outcome.Lose,
            (Shape.Paper, Shape.Rock) => Outcome.Lose,
            (Shape.Paper, Shape.Scissors) => Outcome.Win,
            (Shape.Scissors, Shape.Rock) => Outcome.Win,
            (Shape.Scissors, Shape.Paper) => Outcome.Lose,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static Shape GetPlayerShape(Shape opponentShape, Outcome outcome)
    {
        if (outcome == Outcome.Draw)
            return opponentShape;

        return (opponentShape, outcome) switch
        {
            (Shape.Rock, Outcome.Lose) => Shape.Scissors,
            (Shape.Rock, Outcome.Win) => Shape.Paper,
            (Shape.Paper, Outcome.Lose) => Shape.Rock,
            (Shape.Paper, Outcome.Win) => Shape.Scissors,
            (Shape.Scissors, Outcome.Lose) => Shape.Paper,
            (Shape.Scissors, Outcome.Win) => Shape.Rock,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}