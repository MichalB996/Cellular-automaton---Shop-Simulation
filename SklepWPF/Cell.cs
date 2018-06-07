using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class Cell
    {
        public CellState TypeOfCell { get; set; }
        public Coordinates CellCoordinates { get; set; }
        public Customer Client { get; set; }

        public Cell()
        {
            TypeOfCell = null;
            CellCoordinates = new Coordinates(0, 0);
            Client = null;
        }
        public Cell(CellState cstat, Coordinates cor, Customer cust)
        {
            TypeOfCell = cstat;
            CellCoordinates = cor;
            Client = cust;
        }
        public Cell(Coordinates cor, CellState cstat)
        {
            TypeOfCell = cstat;
            CellCoordinates = cor;
            Client = null;
        }
        

    }
}
