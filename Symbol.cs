using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeForces
{
    internal class Symbol
    {
        public char cipher_value { get; set; }
        public char real_value { get; set; }
        public decimal frequency { get; set; }
        public Symbol(char cipher_value, decimal frequency)
        {
            this.cipher_value = cipher_value;
            this.frequency = frequency;
        }
        public Symbol()
        {

        }
        public void display()
        {
            Console.WriteLine($"Cypher Value : {cipher_value}, Frequency : {frequency}%");
        }
    }
}