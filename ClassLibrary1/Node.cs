using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Node
    {
        public int Value;
        public Node Parent;
        public Node LeftChild;
        public Node RightChild;
        public bool Visited;

        public Node(Node Parent, Node Left, Node Right, int Value)
        {
            this.Value = Value;
            this.Parent = Parent;
            LeftChild = Left;
            RightChild = Right;
            Visited = false;
        }

        /// <summary>
        /// Прямой обход
        /// </summary>
        /// <param name="Root"></param>
        public static void CLR_RekWalk(Node Root)
        {
            Root.Visited = true;
            Console.Write(Root.Value);
            if (Root.LeftChild != null)
            {
                Thread.Sleep(700);
                Console.Write(" --> ");
                CLR_RekWalk(Root.LeftChild);
            }
            if (Root.RightChild != null)
            {
                Thread.Sleep(700);
                Console.Write(" --> ");
                CLR_RekWalk(Root.RightChild);
            }
        }

        /// <summary>
        /// Прямой обход
        /// </summary>
        /// <param name="Root"></param>
        public static void CLR_CycleWalk(Node Root)
        {
            bool Flag = true;
            Stack<Node> stack = new Stack<Node>();
            while (Flag)
            {
                if (!Root.Visited)
                {
                    Thread.Sleep(700);
                    Root.Visited = true;
                }
                if (Root.LeftChild != null && !Root.LeftChild.Visited)
                {
                    stack.Push(Root);
                    Root = Root.LeftChild;
                }
                else if (Root.RightChild != null && !Root.RightChild.Visited)
                {
                    stack.Push(Root);
                    Root = Root.RightChild;
                }
                else if (Root.Parent != null)
                    Root = stack.Pop();
                else Flag = false;
            }
        }

        /// <summary>
        /// Симметричный обход
        /// </summary>
        /// <param name="Root"></param>
        public static void LCR_RekWalk(Node Root)
        {
            if (Root.LeftChild != null)
                LCR_RekWalk(Root.LeftChild);
            Thread.Sleep(700);
            Root.Visited = true;
            if (Root.RightChild != null)
                LCR_RekWalk(Root.RightChild);
        }

        /// <summary>
        /// Симметричный обход
        /// </summary>
        /// <param name="Root"></param>
        public static void LCR_CycleWalk(Node Root)
        {
            bool Flag = true;
            Stack<Node> stack = new Stack<Node>();
            while (Flag)
            {
                if (Root.LeftChild != null && !Root.LeftChild.Visited)
                {
                    stack.Push(Root);
                    Root = Root.LeftChild;
                }
                else if (!Root.Visited)
                {
                    Thread.Sleep(700);
                    Root.Visited = true;
                }
                else if (Root.RightChild != null && !Root.RightChild.Visited)
                {
                    stack.Push(Root);
                    Root = Root.RightChild;
                }
                else if (Root.Parent != null)
                    Root = stack.Pop();
                else Flag = false;
            }
        }

        /// <summary>
        /// Обратный обход
        /// </summary>
        /// <param name="Root"></param>
        public static void LRC_RekWalk(Node Root)
        {
            if (Root.LeftChild != null)
                LRC_RekWalk(Root.LeftChild);
            if (Root.RightChild != null)
                LRC_RekWalk(Root.RightChild);
            Thread.Sleep(700);
            Root.Visited = true;
        }

        /// <summary>
        /// Обратный обход
        /// </summary>
        /// <param name="Root"></param>
        public static void LRC_CycleWalk(Node Root)
        {
            bool Flag = true;
            Stack<Node> stack = new Stack<Node>();
            while (Flag)
            {
                if (Root.LeftChild != null && !Root.LeftChild.Visited)
                {
                    stack.Push(Root);
                    Root = Root.LeftChild;
                }
                else if (Root.RightChild != null && !Root.RightChild.Visited)
                {
                    stack.Push(Root);
                    Root = Root.RightChild;
                }
                else if (!Root.Visited)
                {
                    Thread.Sleep(700);
                    Root.Visited = true;
                }
                else if (Root.Parent != null)
                    Root = stack.Pop();
                else Flag = false;
            }
        }

        public int GetSum()
        {
            int S = Value;
            if (LeftChild != null) S += LeftChild.GetSum();
            if (RightChild != null) S += RightChild.GetSum();
            return S;
        }

        public int GetChildrenSum()
        {
            int S = 0;
            if (LeftChild != null) S += LeftChild.GetSum();
            if (RightChild != null) S += RightChild.GetSum();
            return S;
        }
    }
}
