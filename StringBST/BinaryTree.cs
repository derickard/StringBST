using System;
using System.Collections.Generic;
using System.Text;

namespace StringBST
{
    class BinaryTree
    {
        public Node Root { get; set; }
        public bool Add(string value)
        {
            Node before = null;
            Node after = this.Root;

            while (after != null)
            {
                before = after;
                if (string.Compare(value,after.Data) == -1) // value < after.Data
                    after = after.LeftNode;
                else if (string.Compare(value,after.Data) == 1) //value > after.Data
                    after = after.RightNode;
                else
                {
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (string.Compare(value, before.Data) == -1) // value < before.Data
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }

        public Node Find(string value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(string value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node Remove(Node parent, string key)
        {
            if (parent == null) return parent;

            if (string.Compare(key,parent.Data) == -1) // key < parent.Data
                parent.LeftNode = Remove(parent.LeftNode, key);
            else if (string.Compare(key,parent.Data) == 1) // key > parent.Data
                parent.RightNode = Remove(parent.RightNode, key);
            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }
            return parent;
        }

        private string MinValue(Node node)
        {
            string minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }
            return minv;
        }

        private Node Find(string value, Node parent)
        {
            if (parent != null)
            {
                if (string.Equals(value,parent.Data)) return parent;
                if (string.Compare(value,parent.Data) == -1) // value < parent.Data
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }


        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }
}
