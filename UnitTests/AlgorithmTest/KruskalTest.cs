using Kruskal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace UnitTests
{
    [TestClass()]
    public class KruskalTest
    {
        [TestMethod()]
        public void QuickSortTest()
        {
            //Arrange
            Kruskal_Accessor target = new Kruskal_Accessor();
            Vertex v = new Vertex(1, new System.Drawing.Point(1, 1));
            IList<Edge> graph = new List<Edge> 
            {
                new Edge(v,v,2,v.Position),
                new Edge(v,v,1,v.Position),
                new Edge(v,v,3,v.Position)
            };

            int left = 0;
            int right = graph.Count - 1;

            //Act
            target.QuickSort(graph, left, right);

            //Assert
            Assert.AreEqual(graph[0].Cost, 1);
            Assert.AreEqual(graph[1].Cost, 2);
            Assert.AreEqual(graph[2].Cost, 3);
        }
    }
}