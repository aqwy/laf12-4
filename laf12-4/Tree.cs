using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_4
{
    class Tree
    {
        private Node root;
        public Tree()
        {
            root = null;
        }
        public Node find(int key)
        {
            if (root == null)
                return null;
            Node current = root;
            while (current.iData != key)
            {
                if (key < current.iData)
                    current = current.leftChild;
                else
                    current = current.rightChild;
                if (current == null)
                    return null;
            }
            return current;
        }
        public void insert(int id)
        {
            Node newNode = new Node();
            newNode.iData = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.iData)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public bool delete(int key)
        {
            if (root == null)
                return false;
            Node current = root;
            Node parent = root;
            bool isLeftChild = true;

            while (current.iData != key)
            {
                parent = current;
                if (key < current.iData)
                {
                    isLeftChild = true;
                    current = current.leftChild;
                }
                else
                {
                    isLeftChild = false;
                    current = current.rightChild;
                }
                if (current == null)
                    return false;
            }

            if (current.leftChild == null && current.rightChild == null)
            {
                if (current == root)
                    root = null;
                else if (isLeftChild)
                    parent.leftChild = null;
                else
                    parent.rightChild = null;
            }

            else if (current.rightChild == null)
                if (current == root)
                    root = current.leftChild;
                else if (isLeftChild)
                    parent.leftChild = current.leftChild;
                else
                    parent.rightChild = current.leftChild;

            else if (current.leftChild == null)
                if (current == root)
                    root = current.rightChild;
                else if (isLeftChild)
                    parent.leftChild = current.rightChild;
                else
                    parent.rightChild = current.rightChild;

            else
            {
                Node successor = getSuccessor(current);
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parent.leftChild = successor;
                else
                    parent.rightChild = successor;
                successor.leftChild = current.leftChild;
            }
            return true;
        }
        private Node getSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.rightChild;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.leftChild;
            }
            if (successor != delNode.rightChild)
            {
                successorParent.leftChild = successor.rightChild;
                successor.rightChild = delNode.rightChild;
            }
            return successor;
        }
        public void traverse(int traverseType)
        {
            switch (traverseType)
            {
                case 1:
                    Console.Write("\nPreorder traversal: ");
                    preOrder(root);
                    break;
                case 2:
                    Console.Write("\nInorder traversal: ");
                    inOrder(root);
                    break;
                case 3:
                    Console.Write("\nPostorder traversal: ");
                    postOrder(root);
                    break;
                default:
                    Console.WriteLine("invalid type!");
                    break;
            }
            Console.WriteLine();
        }
        private void preOrder(Node localRoot)
        {
            if (localRoot != null)
            {
                Console.Write(localRoot.iData + " ");
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }
        private void inOrder(Node localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                Console.WriteLine(localRoot.iData + " ");
                inOrder(localRoot.rightChild);
            }
        }
        private void postOrder(Node localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                Console.Write(localRoot.iData + " ");
            }
        }
        public void displayTree()
        {
            Stack<object> globalStack = new Stack<object>();
            globalStack.Push(root);
            int nBlanks = 32;
            bool isRowEmpty = false;
            Console.WriteLine("..............................................................");
            while (isRowEmpty == false)
            {
                Stack<object> localStack = new Stack<object>();
                isRowEmpty = true;

                for (int j = 0; j < nBlanks; j++)
                    Console.Write(' ');
                while (globalStack.Count() != 0)
                {
                    Node temp = (Node)globalStack.Pop();
                    if (temp != null)
                    {
                        Console.Write(temp.iData);
                        localStack.Push(temp.leftChild);
                        localStack.Push(temp.rightChild);
                        if (temp.leftChild != null ||
                        temp.rightChild != null)
                            isRowEmpty = false;
                    }
                    else
                    {
                        Console.Write("--");
                        localStack.Push(null);
                        localStack.Push(null);
                    }
                    for (int j = 0; j < nBlanks * 2 - 2; j++)
                        Console.Write(' ');
                }
                Console.WriteLine();
                nBlanks /= 2;
                while (localStack.Count != 0)
                    globalStack.Push(localStack.Pop());
            }
            Console.WriteLine("..............................................................");
        }
        public bool isEmpty()
        {
            return (root == null);
        }
        public Node removeMax()
        {
            Node grandParent = root;
            Node parent = root;
            Node current = root;

            while (current != null)
            {
                grandParent = parent;
                parent = current;
                current = current.rightChild;
            }
            if (parent == root)
                root = root.leftChild;
            else
                grandParent.rightChild = parent.leftChild;
            return parent;
        }
        public Node peekMax()
        {
            Node parent = root;
            Node current = root;
            while (current != null)
            {
                parent = current;
                current = current.rightChild;
            }
            return parent;
        }
    }
}
