using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;
using System.Xml.Linq;

namespace AVLTree
{
    internal class AVLTree
    {
        public Node Root { get; set; }

        public AVLTree()
        {
            Root = null;
        }
        private Node InsertNode(Node tree, Node node)
        {
            if (tree == null)
            {
                tree = node;
                return tree;
            }
            else if (tree.Word.CompareTo(node.Word) < 0)
            {
                tree.Left = InsertNode(tree.Left, node);
                tree = BalanceTree(tree);
            }
            else if (tree.Word.CompareTo(node.Word) > 0)
            {
                tree.Right = InsertNode(tree.Right, node);
                tree = BalanceTree(tree);
            }
            return tree;
        }
        public void Add(string word)
        {
            Node node = new Node(word);
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Root = InsertNode(Root, node);
            }
        }
        private int GetHeight(Node current)
        {
           int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                int max = Max(left, right);
                height = max + 1;
            }
            return height;
        }
        private int BalanceFactor(Node current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int b_factor = left - right;
            return b_factor;
        }

        private Node BalanceTree(Node current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;  //cant delete AroundTheEarth?
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private int Max(int left, int right)
        {
            return left > right ? left : right;
        }
        private string TraversePreOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append($"(Length {node.WordsLength}: {node.ToString()})");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }
        private string TraverseInOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                sb.Append($"(Length {node.WordsLength}: {node.ToString()})");
                sb.Append(TraverseInOrder(node.Right));
            }
            return sb.ToString();
        }
        private string TraversePostOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(TraversePostOrder(node.Right));
                sb.Append($"(Length {node.WordsLength}: {node.ToString()})");
            }
            return sb.ToString();
        }
        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("Tree is empty");
            }
            else
            {
                sb.Append(TraversePreOrder(Root));
            }
            return sb.ToString();
        }
        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("Tree is empty");
            }
            else
            {
                sb.Append(TraverseInOrder(Root));
            }
            return sb.ToString();
        }
        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("Tree is empty");
            }
            else
            {
                sb.Append(TraversePostOrder(Root));
            }
            return sb.ToString();
        }

        private Node Delete(Node current, Node target)
        {
            if (current == null)
            {
                return null;
            }
            else if (target.Word.CompareTo(current.Word) < 0)
            {
                current.Left = Delete(current.Left, target);
                if (BalanceFactor(current) == -2)
                {
                    if (BalanceFactor(current.Right) <= 0)
                    {
                        current = RotateRR(current);
                    }
                    else
                    {
                        current = RotateRL(current);
                    }
                }
            }
            else if (target.Word.CompareTo(current.Word) > 0)
            {
                current.Right = Delete(current.Right, target);
                if (BalanceFactor(current) == 2)
                {
                    if (BalanceFactor(current.Left) >= 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLR(current);
                    }
                }
            }
            else
            {
                if (current.Right != null)
                {
                    Node parent = current.Right;
                    while (parent.Left != null)
                    {
                        parent = parent.Left;
                    }
                    current.Word = parent.Word;
                    current.Right = Delete(current.Right, parent);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    return current.Left;
                }
            }

            return current;
        }



        private Node Search(Node tree, Node node)
        {
            if (tree != null)                            //n = O(1)
            {
                if (tree.Word.CompareTo(node.Word) == 0) //n = O(1)
                {
                    return tree;                        //n = O(1)
                }
                if (tree.Word.CompareTo(node.Word) < 0) //n = O(1)
                {
                    return Search(tree.Left, node);      //n = O(log n)
                }
                else
                {
                    return Search(tree.Right, node);    //n = O(log n) is this correct 
                }
            }
            return null;
        }

        public string Remove(string word)
        {
            Node node = new Node(word);
            node = Search(Root, node);
            if (node != null)
            {
                Root = Delete(Root, node);
                return "Target: " + word + ", Node removed";
            }
            else
            {
                return "Target: " + word + ", Node not found or tree empty";
            }

        }

        public string Find(string word)
        {
            Node node = new Node(word);
            node = Search(Root, node);

            if (node != null)
            {
                return "Target: " + word + ", Node found: " + node.ToString();
            }
            else
            {
                return "Target: " + word + ", Node not found or tree empty";
            }

        }

        private int FindTreeDepth(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int leftDepth = FindTreeDepth(node.Left);
                int rightDepth = FindTreeDepth(node.Right);

                /* use the larger one */
                if (leftDepth > rightDepth)
                    return (leftDepth + 1);
                else
                    return (rightDepth + 1);
            }
        }
        public int TreeDepth()
        {
            return FindTreeDepth(Root);
        }
    }
}
