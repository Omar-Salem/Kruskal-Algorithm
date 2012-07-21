using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kruskal
{
    public partial class frmMain : Form
    {

        #region Member Variables

        const int _radius = 20;
        const int _halfRadius = (_radius / 2);

        Color _vertexColor = Color.Aqua;
        Color _edgeColor = Color.Red;

        IList<Vertex> _vertices;
        IList<Edge> _graph, _graphSolved;

        Vertex _firstVertex, _secondVertex;

        bool _drawEdge, _solved;

        #endregion

        public frmMain()
        {
            InitializeComponent();
            Clear();
        }

        #region Events

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point clicked = new Point(e.X - _halfRadius, e.Y - _halfRadius);
            if (Control.ModifierKeys == Keys.Control)//if Ctrl is pressed
            {
                if (!_drawEdge)
                {
                    _firstVertex = GetSelectedVertex(clicked);
                    _drawEdge = true;
                }
                else
                {
                    _secondVertex = GetSelectedVertex(clicked);
                    _drawEdge = false;
                    if (_firstVertex != null && _secondVertex != null && _firstVertex.Name != _secondVertex.Name)
                    {
                        frmCost formCost = new frmCost();
                        formCost.ShowDialog();

                        Point stringPoint = GetStringPoint(_firstVertex.Position, _secondVertex.Position);
                        _graph.Add(new Edge(_firstVertex, _secondVertex, formCost._cost, stringPoint));
                        panel1.Invalidate();
                    }
                }
            }
            else
            {
                _vertices.Add(new Vertex(_vertices.Count, clicked));
                panel1.Invalidate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawVertices(g);
            DrawEdges(g);
            g.Dispose();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (_vertices.Count > 2)
            {
                if (_graph.Count < _vertices.Count - 1)
                {
                    MessageBox.Show("Missing Edges", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    btnSolve.Enabled = false;
                    IKruskal kruskal = new Kruskal();
                    int totalCost;
                    _graphSolved = kruskal.Solve(_graph, out totalCost);
                    _solved = true;
                    panel1.Invalidate();
                    MessageBox.Show("Total Cost: " + totalCost.ToString(), "Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Clear form ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                btnSolve.Enabled = true;
                Graphics g = panel1.CreateGraphics();
                g.Clear(panel1.BackColor);
                Clear();
            }
        }

        #endregion

        #region Private Methods

        private void DrawEdges(Graphics g)
        {
            Pen p = new Pen(_edgeColor);
            var edges = _solved ? _graphSolved : _graph;

            foreach (Edge e in edges)
            {
                Point v1 = new Point(e.V1.Position.X + _halfRadius, e.V1.Position.Y + _halfRadius);
                Point v2 = new Point(e.V2.Position.X + _halfRadius, e.V2.Position.Y + _halfRadius);
                g.DrawLine(p, v1, v2);
                DrawString(e.Cost.ToString(), e.StringPosition, g);
            }
        }

        private void DrawString(string strText, Point pDrawPoint, Graphics g)
        {
            Font drawFont = new Font("Arial", 15);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(strText, drawFont, drawBrush, pDrawPoint);
        }

        private void DrawVertices(Graphics g)
        {
            Pen p = new Pen(_vertexColor);
            Brush b = new SolidBrush(_vertexColor);
            foreach (Vertex v in _vertices)
            {
                g.DrawEllipse(p, v.Position.X, v.Position.Y, _radius, _radius);
                g.FillEllipse(b, v.Position.X, v.Position.Y, _radius, _radius);
                DrawString(v.Name.ToString(), v.Position, g);
            }
        }

        private Vertex GetSelectedVertex(Point pClicked)
        {
            foreach (Vertex v in _vertices)
            {
                var distance = GetDistance(v.Position, pClicked);
                if (distance <= _radius)
                {
                    return v;
                }
            }
            return null;
        }

        private double GetDistance(Point start, Point end)
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        }

        private Point GetStringPoint(Point start, Point end)
        {
            int X = (start.X + end.X) / 2;
            int Y = (start.Y + end.Y) / 2;
            return new Point(X, Y);
        }

        private void Clear()
        {
            _vertices = new List<Vertex>();
            _graph = new List<Edge>();
            _solved = false;
            _firstVertex = _secondVertex = null;
        }

        #endregion
    }
}