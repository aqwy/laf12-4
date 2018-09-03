using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_4
{
    class Node
    {
        public int iData;
        public Node leftChild;
        public Node rightChild;
        public Node (int key)
        {
            iData = key;
        }
        public int getKey()
        {
            return iData;
        }
        public void displayNode()
        {
            Console.Write(iData);
        }
    }
}
