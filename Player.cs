using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Inventory_Management
{
    internal class Player
    {
        public static Queue<Player> players;
        public String player;
        public string[] Cards = new String[9];
        public override string ToString()
        {
            string st = "";
            st += player + "\n";
            for (int i = 0; i < Cards.Length; i++)
            {
                st += Cards[i] + " , ";
            }
            return st;
        }
    }
}