using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Создание дерева
            Node Root = new Node(null, null, null, 1);
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
            #endregion

            Console.WriteLine("Рекурсивный прямой обход:");
            Node.CLR_RekWalk(Root);
            Console.WriteLine();
            Console.WriteLine("Рекурсивный обратный обход:");
            for (; ; ) ;
        }
    }
}
