namespace Utility.PathFinding.AStar
{
    public record Neighbor<TKey>(TKey Key, int Cost);
}