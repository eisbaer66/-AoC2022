namespace Utility.PathFinding.Dijkstra
{
    public record Neighbor<TKey>(TKey Key, int Cost);
}