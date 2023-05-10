using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneraIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressGenerator nuovo = new AddressGenerator("11000000.10100000.01010000.10000000");
             
            Console.WriteLine($"Indirizzo IP:{nuovo.generateIPv4()}   Subnetmask:{nuovo.generateSubnet()}");

            Console.ReadLine();
            
        }
    }
}
