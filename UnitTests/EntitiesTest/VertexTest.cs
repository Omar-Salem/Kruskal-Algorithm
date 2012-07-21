using Kruskal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace UnitTests
{
    [TestClass()]
    public class VertexTest
    {
        readonly int _name;
        readonly Point _position;
        
        public VertexTest()
        {
            _name = 100;
            _position = new Point(1, 1); 
        }

        [TestMethod()]
        public void VertexConstructorTest()
        {
            //Act
            Vertex target = new Vertex(_name, _position);
            
            //Assert
            Assert.AreEqual(target.Name, _name);
            Assert.AreEqual(target.Position.ToString(), _position.ToString());
            Assert.AreEqual(target.Rank, 0);
            Assert.AreEqual(target.Root.Name, _name);
        }

        [TestMethod()]
        public void GetRootTest()
        {
            //Arrange
            Vertex target = new Vertex(_name, _position);
            Vertex root = new Vertex(500, new Point());
            target.Root = root;

            //Act
            Vertex actual = target.GetRoot();

            //Assert
            Assert.AreEqual(root.Name, actual.Name);
        }

        [TestMethod()]
        public void JoinTest()
        {
            //Arrange
            int root1Rank = 5;
            Vertex root1 = new Vertex(100, new Point(100, 100));
            root1.Rank = root1Rank = 5; ;
            Vertex root2 = new Vertex(200, new Point(200, 200));
            root2.Rank = 1;

            //Act
            Vertex.Join(root1, root2);

            //Assert
            Assert.AreEqual(root2.Root.Name, root1.Name);

            //Arrange
            root2.Rank = root1Rank = 5; ;

            //Act
            Vertex.Join(root1, root2);

            //Assert
            Assert.AreEqual(root1.Root.Name, root2.Name);
            Assert.AreEqual(root2.Rank, root1Rank + 1);
        }
    }
}
