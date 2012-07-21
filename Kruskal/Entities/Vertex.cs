using System;
using System.Drawing;

namespace Kruskal
{
    public class Vertex
    {
        #region Members

        private int name;

        #endregion

        #region Public Properties

        public int Name
        {
            get
            {
                return name;
            }
        }

        public int Rank { get; set; }

        public Vertex Root { get; set; }

        public Point Position { get; set; }

        #endregion

        #region Constructor

        public Vertex(int name, Point position)
        {
            this.name = name;
            this.Rank = 0;
            this.Root = this;
            this.Position = position;
        } 

        #endregion

        #region Methods

        internal Vertex GetRoot()
        {
            if (this.Root != this)// am I my own parent ? (am i the root ?)
            {
                this.Root = this.Root.GetRoot();// No? then get my parent
            }

            return this.Root;
        }

        internal static void Join(Vertex root1, Vertex root2)
        {
            if (root2.Rank < root1.Rank)//is the rank of Root2 less than that of Root1 ?
            {
                root2.Root = root1;//yes! then Root1 is the parent of Root2 (since it has the higher rank)
            }
            else //rank of Root2 is greater than or equal to that of Root1
            {
                root1.Root = root2;//make Root2 the parent
                if (root1.Rank == root2.Rank)//both ranks are equal ?
                {
                    root2.Rank++;//increment Root2, we need to reach a single root for the whole tree
                }
            }
        }

        #endregion
    }
}