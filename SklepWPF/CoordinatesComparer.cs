using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class CoordinatesComparer : IEqualityComparer<Coordinates>
    {
        public bool Equals(Coordinates x1Coords, Coordinates x2Coords)
        {
            if ((x1Coords.x == x2Coords.x) && (x1Coords.y == x2Coords.y))
                return true;
            else return false;
        }


        public int GetHashCode(Coordinates obj)
        {
            return 0;
        }
    }
}
