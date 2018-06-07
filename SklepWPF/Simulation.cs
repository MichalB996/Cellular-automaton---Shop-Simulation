using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class Simulation
    {
        private ReadShop Shop { get; set; }
        private List<Customer> Customers { get; set; }
        private int iterations;
        private int maxCustomersAmount;
        public Random Rand { get; set; }

        public Simulation(int number, ReadShop shop)
        {
            Shop = shop;
            Customers = new List<Customer>();
            iterations = 0;
            maxCustomersAmount = number;
            Rand = new Random();
        }
        public void AddNewClient()
        {
            if (Customers.Count == maxCustomersAmount)
                return;
            if (Rand.Next(1, 8) % 2 == 0)
                return;
            int index;
            do
            {
                index = Rand.Next(0, Shop.getEntries().Count);
            }
            while (EmptyEntrance() && !(Shop.getEntries()[index].Client == null));
            Customer cust = new Customer(Shop, Shop.getEntries()[index].CellCoordinates);
            cust.CustomerPath = cust.GeneratePath(cust.ActualCoordinates);
            Shop.getEntries()[index].Client = cust;
            Customers.Add(cust);
        }
        public bool EmptyEntrance()
        {

            foreach (var e in Shop.getEntries())
            {
                if (e.Client == null)
                    return true;
            }
            return false;
        }
        public void Iterate()
        {
            if (Rand.Next(0, (iterations + 1) % 3) == 0)
                AddNewClient();
            int index = 0;
            int size = Customers.Count;
            while (index < Customers.Count)
            {

                Cell position = Shop.CellDictionary[Customers[index].CustomerPath[0]];
                if (position.Client != null)
                {
                    if (Shop.Chose == 0)
                    {

                        if (position.Client.ActualCoordinates.y == 39 || position.Client.ActualCoordinates.y == 40)
                        {
                            Customers.RemoveAt(index);
                            position.Client = null;
                        }

                        else
                            index++;
                    }
                    if (Shop.Chose == 1)
                    {
                        if (position.Client == null)
                            continue;
                        if (position.Client.ActualCoordinates.y == 32 || position.Client.ActualCoordinates.y == 31)
                        {
                            Customers.RemoveAt(index);
                            position.Client = null;
                        }

                        else
                            index++;
                    }
                }
                else
                index++;


            }
            foreach (var c in Customers)
                c.MakeMove();
                
            iterations++;
        }
       
                }
            }


