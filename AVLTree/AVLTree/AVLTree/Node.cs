using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    internal class Node
    {
        public string Word { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int WordsLength { get; set; }
        public Node()
        {
            Word = "";
            Left = null;
            Right = null;   
            WordsLength = Word.Length;
        }
        public Node(string word)
        {
            Word = word;
            Left = null;
            Right = null;
            WordsLength = Word.Length;

        }
        public override string ToString() 
        {
            return Word.ToString();
        }
    }
}
