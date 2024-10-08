using CodeForces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstitutionCipher
{
    internal class SubstitutionCipher : Symbol
    {
        public List<Symbol> ListOfSymbols = new List<Symbol>();

        public List<Symbol> OrderedListOfSymbols = new List<Symbol>();


        private char[] Relative_letters_Order = new char[]
{
            'E', 'T', 'A', 'O', 'I', 'N', 'S', 'H',
            'R', 'D', 'L', 'C', 'U', 'M', 'W', 'F',
            'G', 'Y', 'P', 'B', 'V', 'K', 'J', 'X',
            'Q', 'Z'
        };


        protected void calc_symbols_probability(string data)
        {
            int char_rep = 0;
            string data_no_space = data.Replace(' '.ToString(), string.Empty);  //remove space
            data_no_space = data_no_space.ToLower();
            int count = data_no_space.Count(); //number of characters
            for (int i = 97; i <= 122; i++)
            {
                Symbol s = new Symbol();
                s.cipher_value = (char)i;
                char_rep = data_no_space.Count(x => x == i);
                decimal frequency = ((decimal)char_rep / count) * 100;
                s.frequency = Math.Round(frequency, 2);
                ListOfSymbols.Add(s);
            }
        }


        public void display_symbols_frequency()
        {
            foreach (Symbol s in ListOfSymbols)
            {
                s.display();
            }
        }
        public void display_symbols_frequency_ordered()
        {
            var s = ListOfSymbols.OrderByDescending(x => x.frequency);
            foreach (var obj in s)
            {
                obj.display();
            }
        }
        public void solve(string data)
        {
            calc_symbols_probability(data);

            OrderedListOfSymbols = ListOfSymbols.OrderByDescending(x => x.frequency).ToList(); //ordering of symbols 
            int i = 0;
            foreach (var obj in OrderedListOfSymbols)
            {
                obj.real_value = Relative_letters_Order[i];
                i++;
            }
        }
        public void show_answer()
        {
            foreach (var obj in OrderedListOfSymbols)
            {
                Console.WriteLine($"{obj.cipher_value} -> {obj.real_value}");
            }
        }
    }
}
