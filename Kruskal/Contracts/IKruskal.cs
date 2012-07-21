namespace Kruskal
{
    using System.Collections.Generic;

    public interface IKruskal
    {
        IList<Edge> Solve(IList<Edge> graph, out int totalCost);
    }
}
