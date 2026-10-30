using System;
using System.Collections.Generic;
using System.Text;

namespace курсовая
{
    internal class Node
    {
        public char Symbol; 
        public int Frequency;
        public Node Left;   
        public Node Right; 
        public Node(char symbol, int frequency)
        {
            Symbol = symbol;
            Frequency = frequency;
        }
        public Node(Node left, Node right)
        {
            Left = left;
            Right = right;
            Frequency = left.Frequency + right.Frequency;
        }
        public bool IsLeaf => Left == null && Right == null;
    }
}
