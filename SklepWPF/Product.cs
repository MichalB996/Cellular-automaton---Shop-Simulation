using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class Product
    {
        public static int numberOfProduct = 10;
        public CellState NameOfProduct { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public Product(CellState state)
        {
            this.NameOfProduct = state;
            this.Price = 1;
            this.Amount = 1;
        }
        public Product()
        {}

        public static HashSet<Product> GenerateListOfProducts(int x)
        {
            Object obj = new object();
            Random rand = new Random();
            HashSet<Product> products = new HashSet<Product>(new ProductComparer());
            for (int i = 0; i < x; i++)
            {
                Product nproduct = ReturnRandom(obj, rand);
                if (products.Contains(nproduct))
                    continue;
                products.Add(nproduct);
            }
            return products;
        }

        public static Product ReturnRandom(object c, Random r)
        {
            int x = r.Next(1, 5);
            int number = r.Next(5, 25);
            return new Product(new CellState((CellState.TypeOfCell)number));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product))
                return false;

            else
            {
                var prod = obj as Product;
                if (this.NameOfProduct.StateOfCell == prod.NameOfProduct.StateOfCell)
                    return true;
                else
                    return false;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return (int)this.NameOfProduct.StateOfCell;
        }


    }
}
