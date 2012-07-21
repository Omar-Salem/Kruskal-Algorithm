using Kruskal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace UnitTests
{
    [TestClass()]
    public class EdgeTest
    {
        [TestMethod()]
        public void EdgeConstructorTest()
        {
            //Arrange
            Vertex v1 = new Vertex(100, new Point(100, 100));
            Vertex v2 = new Vertex(200, new Point(200, 200));
            int cost = 500;
            Point stringPosition = new Point(300,300);

            //Act
            Edge target = new Edge(v1, v2, cost, stringPosition);

            //Assert
            Assert.AreEqual(target.V1.Name, v1.Name);
            Assert.AreEqual(target.V2.Name, v2.Name);
            Assert.AreEqual(target.Cost, cost);
            Assert.AreEqual(target.StringPosition.ToString(), stringPosition.ToString());
        }
    }
}
