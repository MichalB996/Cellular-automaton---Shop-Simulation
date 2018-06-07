using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class CellState
    {
        public enum TypeOfCell
        {   // INFRASTRUCTURE
            ENTRY, EXIT, WALL, PASSAGE, PRIORITY_PASSAGE, 
            //  MILK PRODUCTS
            MILK, YOGHURT, CHEESE, BUTTER,
            // MEAT PRODUCTS 
            HAM, LAMB, FISH, SAUSAGE,
            // FRUITS AND VEGETABLES 
            APPLE, PEAR, STRAWBERRY, LETTUCE, CABBAGE,
            // COMONLY USED
            BREAD, WATER, SALT, PEPPER,
            //PARTY PRODUCTS
            CHOCOLATE, CHIPS, CAKE, CIGARETTES,
        }
        public CellState(CellState.TypeOfCell s)
        {
            StateOfCell = s;
        }
        public TypeOfCell StateOfCell { get; set; }
        public static int NumberOfProducts { get; } = 26;
        public static bool IsProduct(CellState.TypeOfCell state)
        {
            if (state == TypeOfCell.ENTRY || state == TypeOfCell.EXIT || state == TypeOfCell.WALL ||
                state == TypeOfCell.PASSAGE || state == TypeOfCell.PRIORITY_PASSAGE)
                return false;

            else return true;
        }
    }
}
