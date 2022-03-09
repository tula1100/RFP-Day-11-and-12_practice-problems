using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Problems_day_11_and_12
{
    internal class StockAccountManagement
    {
         string FilePath = @"D:\.net\jason\Stock-Manage-jason.json";
        public StockAccountManagement()
        {
            Selection();
        }
        public void Selection()
        {
            Console.WriteLine("1-->AddStock\n2-->DisplayStockDetails\n(Any number to Quit(Except 1&2))");
            int select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    AddStock();
                    break;
                case 2:
                    Display();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        public void AddStock()
        {
            Console.Write("Enter the StockName: ");
            string stock = Console.ReadLine();
            Console.Write("Enter the Number of Share: ");
            long share = long.Parse(Console.ReadLine());
            Console.Write("Enter the StockPrice: ");
            long shareprice = long.Parse(Console.ReadLine());
            Stock obj = new Stock
            {
                StockName = stock,
                NumberOfShare = share,
                SharePrice = shareprice,
                TotalStockPrice = share * shareprice
            };
            string Read = File.ReadAllText(FilePath);
            StockPortFoili Sobj = new StockPortFoili();
            if (Read.Length == 0)
            {
                Sobj.GrandTotalStockPrice = obj.TotalStockPrice;
            }
            if (Read.Length != 0)
            {
                Sobj = JsonConvert.DeserializeObject<StockPortFoili>(Read);
                Sobj.GrandTotalStockPrice += obj.TotalStockPrice;
            }

            if (Sobj.Stocks == null)
            {
                Sobj.Stocks = new List<Stock>();
            }
            Sobj.Stocks.Add(obj);
            String serialize = JsonConvert.SerializeObject(Sobj);
            File.WriteAllText(FilePath, serialize);
            Selection();
        }
        public void Display()
        {
            string Read = File.ReadAllText(FilePath);
            var Deserialize = JsonConvert.DeserializeObject<StockPortFoili>(Read);
            foreach (var read in Deserialize.Stocks)
            {
                Console.WriteLine(read + "\n");
            }
            Console.WriteLine("GrandTotalStockPrice: " + Deserialize.GrandTotalStockPrice);
            Selection();
        }
    }
}
