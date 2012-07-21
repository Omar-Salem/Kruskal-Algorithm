using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kruskal
{
    public class Edge : IComparable
    {
        #region Members

        private Vertex v1, v2;
        private int cost;
        private Point stringPosition;

        #endregion

        #region Public Properties

        public Vertex V1
        {
            get
            {
                return v1;
            }
        }

        public Vertex V2
        {
            get
            {
                return v2;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }
        }

        public Point StringPosition
        {
            get
            {
                return stringPosition;
            }
        }

        #endregion

        #region Constructor

        public Edge(Vertex v1, Vertex v2, int cost, Point stringPosition)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.cost = cost;
            this.stringPosition = stringPosition;
        } 

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            Edge e = (Edge)obj;
            return this.cost.CompareTo(e.cost);
        }

        #endregion
    }
}