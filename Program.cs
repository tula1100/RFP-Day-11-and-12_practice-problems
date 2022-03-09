using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Problems_day_11_and_12
{
    internal class Program
    {
      InventoryFactory iv;
        string path = @"D:\.net\jason\inventory-json.json";
        public Inventory_Management()
        {
            Inventory_Managements();
        }
        public void Inventory_Managements()
        {
            Console.WriteLine("1 = add items, 2 = display, 3 = exit");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    AddItems();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Inventory_Managements();
                    break;
            }
        }
        public void AddItems()
        {
            Console.WriteLine("enter 1 for adding Rice , 2 for adding pulses, 3 for adding wheats");
            int select = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rice Brand Name");
            string name = (Console.ReadLine());
            Console.WriteLine("Enter Weight ");
            int weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Price per KG");
            int price = Convert.ToInt32(Console.ReadLine());
            Seeds seeds = new Seeds()
            {
                Name = name,
                Weight = weight,
                Price = price,
                Total = price * weight
            };
            string path = @"D:\.net\jason\inventory-json.json";
            string read = File.ReadAllText(path);
            if (iv == null)
            {
                iv = new InventoryFactory();
            }
            if (read.Length != 0)
            {
                iv = JsonConvert.DeserializeObject<InventoryFactory>(read);
            }
            switch (select)
            {
                case 1:
                    if (iv.Rice == null)
                    {
                        iv.Rice = new List<Seeds>();
                    }
                    iv.Rice.Add(seeds);
                    break;
                case 2:
                    if (iv.Pulses == null)
                    {
                        iv.Pulses = new List<Seeds>();
                    }
                    iv.Pulses.Add(seeds);
                    break;
                case 3:
                    if (iv.Wheats == null)
                    {
                        iv.Wheats = new List<Seeds>();
                    }
                    iv.Wheats.Add(seeds);
                    break;
                default:
                    Console.WriteLine("Entered Invalid Number ");
                    AddItems();
                    break;

            }
            string data = JsonConvert.SerializeObject(iv);
            File.WriteAllText(path, data);
            Inventory_Managements();
        }
        public void Display()
        {
            string Read = File.ReadAllText(path);
            iv = JsonConvert.DeserializeObject<InventoryFactory>(Read);
            Console.WriteLine("enter 1 for Rice Details , 2 for Pulses Details , 3 for Wheats Details , 4 for all Details , 5 for Adding items\nQuit(Any number");
            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (select)
            {
                case 1:
                    Console.WriteLine("Rice Details\n");
                    foreach (var rice in iv.Rice)
                    {
                        Console.WriteLine(rice.ToString() + "\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Pulses Details\n");
                    foreach (var pulses in iv.Pulses)
                    {
                        Console.WriteLine(pulses.ToString() + "\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("Wheats  Details\n");
                    foreach (var wheats in iv.Wheats)
                    {
                        Console.WriteLine(wheats.ToString() + "\n");
                    }
                    break;
                case 4:
                    Console.WriteLine("Rice Details\n");
                    foreach (var rice in iv.Rice)
                    {
                        Console.WriteLine(rice.ToString() + "\n");
                    }
                    Console.WriteLine("Pulses Details\n");
                    foreach (var pulses in iv.Pulses)
                    {
                        Console.WriteLine(pulses.ToString() + "\n");
                    }

                    Console.WriteLine("Wheats  Details\n");
                    foreach (var wheats in iv.Wheats)
                    {
                        Console.WriteLine(wheats.ToString() + "\n");
                    }
                    break;
                case 5:
                    AddItems();
                    Console.WriteLine("Items Added");
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            Display();
        }
    }
    public class InventoryFactory
    {
        public List<Seeds> Rice;
        public List<Seeds> Pulses;
        public List<Seeds> Wheats;
    }
    public class Seeds
    {
        public string Name;
        public int Weight, Price, Total;
        public string ToString()
        {
            string str = $"Name:{Name}\nWeight:{Weight}\nPrice:{Price}\nTotal:{Total}";
            return str;
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventory_Management im = new Inventory_Management();
            im.Inventory_Managements();
            StockAccountManagement sm = new StockAccountManagement();
            sm.Selection();
            CommericialDataManagement cm = new CommericialDataManagement();
            cm.Selection();
            DeckOfCard dc = new DeckOfCard();
            dc.Play();
            DeckCardQueue dq = new DeckCardQueue();

        }
    }
}
