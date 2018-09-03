using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_4
{
    class priorityQ
    {
        private int currentSize;
        private Tree theTree;

        public priorityQ(int size)
        {
            theTree = new Tree();
        }
        public void insert(int item)
        {
            theTree.insert(item);
        }
        public int removeMaxVal()
        {
            return theTree.removeMax().iData;
        }
        public int peek()
        {
            return theTree.peekMax().iData;
        }
        public bool isEmpty()
        {
            return theTree.isEmpty();
        }
        public void display()
        {
            theTree.displayTree();
        }
    }
}
