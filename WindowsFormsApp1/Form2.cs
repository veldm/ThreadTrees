using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// "Корень" дерева
        /// </summary>
        Node Root;

        Graphics G;
        Point S = new Point(200, 10);
        static Thread x;

        public Form2()
        {
            InitializeComponent();
            CreateDefaultTree();
        }
        /// <summary>
        /// Создание дерева
        /// </summary>
        private void CreateDefaultTree()
        {
            Root = new Node(null, null, null, 1);
            Node Left1 = new Node(Root, null, null, 0);
            Node Right1 = new Node(Root, null, null, 5);
            Root.LeftChild = Left1;
            Root.RightChild = Right1;
            Node Left2 = new Node(Left1, null, null, -3);
            Left1.LeftChild = Left2;
            Node Right2 = new Node(Right1, null, null, 7);
            Right1.RightChild = Right2;
            Node Left3 = new Node(Right2, null, null, 4);
            Right2.LeftChild = Left3;
            Node Right3 = new Node(Left1, null, null, 2);
            Left1.RightChild = Right3;
            Node Right4 = new Node(Right2, null, null, 9);
            Right2.RightChild = Right4;
            Node Left5 = new Node(Right4, null, null, 3);
            Right4.LeftChild = Left5;
            Node Right5 = new Node(Right4, null, null, 12);
            Right4.RightChild = Right5;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Рисует узел дерева
        /// </summary>
        /// <param name="g"></param>
        /// <param name="node"></param>
        /// <param name="S"></param>
        private void DrawNode(Graphics g, Node node, Point S)
        {
            g.DrawString(node.GetChildrenSum().ToString(), Form1.DefaultFont,
                new SolidBrush(Color.Black), S.X + 40, S.Y);
            int D = (node.Parent == null ? 80 : 50);
            Pen P = new Pen(Color.Brown, 5);
            Pen P2 = new Pen(Color.Brown, 3);
            g.DrawEllipse(P, S.X, S.Y, 30, 30);
            P.Color = Color.Brown;
            if (node.LeftChild != null)
            {
                Point S2 = new Point(S.X - D, S.Y + 70);
                g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                DrawNode(g, node.LeftChild, S2);
            }
            if (node.RightChild != null)
            {
                Point S2 = new Point(S.X + D, S.Y + 70);
                g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                DrawNode(g, node.RightChild, S2);
            }
            Color C = (node.Visited ? Color.Yellow : Color.White);
            SolidBrush B = new SolidBrush(C);
            g.FillEllipse(B, S.X, S.Y, 30, 30);
            int d = 10 - (node.Value / 10 == 1 ? 3 : 0) - (node.Value < 0 ? 3 : 0);
            g.DrawString(node.Value.ToString(), Form1.DefaultFont,
                new SolidBrush(Color.Black), S.X + d, S.Y + 10);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            G = e.Graphics;
            G.Clear(Color.LightSteelBlue);
            DrawNode(G, Root, S);
        }
    }
}
