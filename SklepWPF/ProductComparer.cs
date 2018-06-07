using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class ProductComparer: IEqualityComparer<Product>
    {

            public bool Equals(Product p1, Product p2)
            {
                if (p1.NameOfProduct.StateOfCell == p2.NameOfProduct.StateOfCell)
                    return true;
                else return false;
            }

            public int GetHashCode(Product obj)
            {
                return 0;
            }
    }
}
