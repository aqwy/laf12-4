using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int size = 10;
            priorityQ pq = new priorityQ(size);

            for (int i = 0; i < size; i++)
            {
                int num = r.Next(99);
                pq.insert(num);
            }

            pq.display();

            while(!pq.isEmpty())
            {
                Console.Write(pq.removeMaxVal() + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
