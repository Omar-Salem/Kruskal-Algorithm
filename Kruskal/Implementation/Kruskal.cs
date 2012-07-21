namespace Kruskal
{
    using System.Collections.Generic;
    using System.Linq;

    public class Kruskal : IKruskal
    {
        #region IKruskal

        IList<Edge> IKruskal.Solve(IList<Edge> graph, out int totalCost)
        {
            QuickSort(graph, 0, graph.Count - 1);
            IList<Edge> solvedGraph = new List<Edge>();
            totalCost = 0;

            foreach (Edge ed in graph)
            {
                Vertex root1 = ed.V1.GetRoot();
                Vertex root2 = ed.V2.GetRoot();

                if (root1.Name != root2.Name)
                {
                    totalCost += ed.Cost;
                    Vertex.Join(root1, root2);
                    solvedGraph.Add(ed);
                }
            }

            return solvedGraph;
        } 

        #endregion

        #region Private Methods

        private void QuickSort(IList<Edge> graph, int left, int right)
        {
            int i, j, x;
            i = left; j = right;
            x = graph[(left + right) / 2].Cost;

            do
            {
                while ((graph[i].Cost < x) && (i < right))
                {
                    i++;
                }

                while ((x < graph[j].Cost) && (j > left))
                {
                    j--;
                }

                if (i <= j)
                {
                    Edge y = graph[i];
                    graph[i] = graph[j];
                    graph[j] = y;
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (left < j)
            {
                QuickSort(graph, left, j);
            }

            if (i < right)
            {
                QuickSort(graph, i, right);
            }
        } 

        #endregion
    }
}