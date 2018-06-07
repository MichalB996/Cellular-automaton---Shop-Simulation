using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class Customer
    {
        public HashSet<Product> ListOfProducts { get; set; }
        public List<Coordinates> CustomerPath { get; set; }
        public Dictionary<Coordinates, CellState> ShopMap { get; set; }
        public Coordinates ActualCoordinates { get; set; }
        public Dictionary<Coordinates, Cell> CellDictionary { get; set; }

        public Customer(ReadShop shop)
        {
            ListOfProducts = new HashSet<Product>(new ProductComparer());
            ListOfProducts = Product.GenerateListOfProducts(Product.numberOfProduct);
            ShopMap = shop.InputData;
            CustomerPath = new List<Coordinates>();
            this.CellDictionary = shop.CellDictionary;
        }
        public Customer(ReadShop shop, Coordinates cords)
        {
            ListOfProducts = Product.GenerateListOfProducts(Product.numberOfProduct);
            ShopMap = shop.InputData;
            CustomerPath = new List<Coordinates>();
            this.CellDictionary = shop.CellDictionary;
            this.CellDictionary[cords].Client = this;
            ActualCoordinates = cords;
        }

        public bool CheckTopAlleyLeft(Coordinates current)
        {
            Coordinates check = new Coordinates(current.x, current.y - 1);
            if (!ShopMap.ContainsKey(check))
                return false;

            int column = current.y - 1;
            bool isThere = false;
            List<CellState> cellsProducts = new List<CellState>();

            var subCells = ShopMap.Select(i => i.Key).Where(d => d.y == column && d.x <= current.x).ToList();
            for(int i =0; i< subCells.Count(); i++)
            {
                cellsProducts.Add(ShopMap[subCells[i]]);
            }

            foreach (CellState s in cellsProducts)
            {
                if (ListOfProducts.Contains(new Product(s)))
                    isThere = true; 
            }

            return isThere;
        }
        public bool CheckTopAlleyRight(Coordinates current)
        {

            Coordinates check = new Coordinates(current.x, current.y + 1);
            if (!ShopMap.ContainsKey(check))
                return false;

            int column = current.y + 1;
            bool isThere = false;
            List<CellState> cellsProducts = new List<CellState>();

            var subCells = ShopMap.Select(i => i.Key).Where(d => d.y == column && d.x <= current.x).ToList();
            for (int i = 0; i < subCells.Count(); i++)
            {
                cellsProducts.Add(ShopMap[subCells[i]]);
            }

            foreach (CellState s in cellsProducts)
            {
                if (ListOfProducts.Contains(new Product(s)))
                    isThere = true;
            }

            return isThere;
           
        }
        public bool CheckDownAlleyLeft(Coordinates current)
        {
            Coordinates check = new Coordinates(current.x, current.y - 1);
            if (!ShopMap.ContainsKey(check))
                return false;
            int column = current.y - 1;
            bool isThere = false;
            
            List<CellState> cellsProducts = new List<CellState>();

            var subCells = ShopMap.Select(i => i.Key).Where(d => d.y == column && d.x >= current.x).ToList();
            for (int i = 0; i < subCells.Count(); i++)
            {
                cellsProducts.Add(ShopMap[subCells[i]]);
            }

            foreach (CellState s in cellsProducts)
            {
                if (ListOfProducts.Contains(new Product(s)))
                    isThere = true;
            }

            return isThere;
            
        }
        public bool CheckDownAlleyRight(Coordinates current)
        {
            Coordinates check = new Coordinates(current.x, current.y + 1);
            if (!ShopMap.ContainsKey(check))
                return false;
            int column = current.y + 1;
            bool isThere = false;
            List<CellState> cellsProducts = new List<CellState>();

            var subCells = ShopMap.Select(i => i.Key).Where(d => d.y == column && d.x >= current.x).ToList();
            for (int i = 0; i < subCells.Count(); i++)
            {
                cellsProducts.Add(ShopMap[subCells[i]]);
            }

            foreach (CellState s in cellsProducts)
            {
                if (ListOfProducts.Contains(new Product(s)))
                    isThere = true;
            }

            return isThere;
        }
        public bool IsTheProductInTopAlley(Coordinates currentCoordinates)
        {
            if (CheckTopAlleyLeft(currentCoordinates) || CheckTopAlleyRight(currentCoordinates))
                return true;

            else return false;
        }
        public bool IsTheProductInDownAlley(Coordinates currentCoordinates)
        {
            if (CheckDownAlleyLeft(currentCoordinates) || CheckDownAlleyRight(currentCoordinates))
                return true;

            else return false;
        }
        public bool IsTheProductInAlley(Coordinates currentCoordinates)
        {
            if (CheckDownAlleyRight(currentCoordinates) || CheckTopAlleyRight(currentCoordinates)
                || CheckTopAlleyLeft(currentCoordinates) || CheckDownAlleyLeft(currentCoordinates))
                return true;

            else return false;
        }

        public bool IsTheItemOnListOfProductLeft(Coordinates currentCoordinates)
        {
            Coordinates check = new Coordinates(currentCoordinates.x, currentCoordinates.y - 1);
            if (!ShopMap.ContainsKey(check))
                return false;
            bool isThere = false;


            Coordinates cords = new Coordinates(currentCoordinates.x, currentCoordinates.y - 1);
            ShopMap.TryGetValue(cords, out CellState cell);
            foreach (var products in ListOfProducts)
            {
                if (ListOfProducts.Contains(new Product(cell)))
                    isThere = true;
            }

            return isThere;

        }
        public bool IsTheItemOnListOfProductRight(Coordinates currentCoordinates)
        {
            Coordinates check = new Coordinates(currentCoordinates.x, currentCoordinates.y + 1);
            if (!ShopMap.ContainsKey(check))
                return false;
            bool isThere = false;

            Coordinates cords = new Coordinates(currentCoordinates.x, currentCoordinates.y + 1);
            ShopMap.TryGetValue(cords, out CellState cell);
            foreach (var products in ListOfProducts)
            {
                if (products.NameOfProduct.StateOfCell == cell.StateOfCell)
                    isThere = true;
            }
            return isThere;

        }
        public void RemoveProductFromListIfPossible(Coordinates currentCoordinates)
        {
            Coordinates lCoords = new Coordinates(currentCoordinates.x, currentCoordinates.y - 1);
            Coordinates rCoords = new Coordinates(currentCoordinates.x, currentCoordinates.y + 1);
            if (!ShopMap.ContainsKey(lCoords) || !ShopMap.ContainsKey(rCoords))
                return;

            if (IsTheItemOnListOfProductLeft(currentCoordinates))
            {

                foreach (var c in ListOfProducts.ToList())
                {
                    if (c.NameOfProduct.StateOfCell == ShopMap[lCoords].StateOfCell)
                        ListOfProducts.Remove(c);
                }
            }
            if (IsTheItemOnListOfProductRight(currentCoordinates))
            {
                foreach (var c in ListOfProducts.ToList())
                {
                    if (c.NameOfProduct.StateOfCell == ShopMap[rCoords].StateOfCell)
                        ListOfProducts.Remove(c);
                }
            }
        }
        public bool IsCustomerIsOnTop(Coordinates currentCoordinates)
        {
            Coordinates check = new Coordinates(currentCoordinates.x, currentCoordinates.y);
            if (!ShopMap.ContainsKey(check))
                return false;

            Coordinates tempCoordinates = new Coordinates(currentCoordinates.x, currentCoordinates.y);
            while (!(ShopMap[tempCoordinates].StateOfCell == CellState.TypeOfCell.WALL))
            {

                if (ShopMap[tempCoordinates].StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                    return true;

                tempCoordinates = new Coordinates(tempCoordinates.x + 1, tempCoordinates.y);
            }
            return false;
        }
        public bool InTheMainAlleyTop(Coordinates currentCoordinates)
        {
            Coordinates tempCoordinates = new Coordinates(currentCoordinates.x - 1, currentCoordinates.y);
            if (ShopMap[tempCoordinates].StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                return true;

            else return false;
        }

        public bool InTheMainAlleyDown(Coordinates currentCoordinates)
        {
            Coordinates tempCoordinates = new Coordinates(currentCoordinates.x + 1, currentCoordinates.y);
            if (ShopMap[tempCoordinates].StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                return true;

            else return false;
        }
        public List<Coordinates> GeneratePath(Coordinates currentPosition)
        {
            List<Coordinates> tempPath = new List<Coordinates>();
            Coordinates tempCoordinates = new Coordinates(currentPosition.x, currentPosition.y);
            tempPath.Add(currentPosition);

            if (ListOfProducts.Count == 0)
            {
                while (!IsTheProductInAlley(tempCoordinates) && !(ShopMap[tempCoordinates].StateOfCell == CellState.TypeOfCell.EXIT))
                {
                    tempCoordinates = new Coordinates(tempCoordinates.x, tempCoordinates.y + 1);
                    tempPath.Add(tempCoordinates);
                }

            }
            else
            {
                while (!IsTheProductInAlley(tempCoordinates))
                {
                    tempCoordinates = new Coordinates(tempCoordinates.x, tempCoordinates.y + 1);
                    tempPath.Add(tempCoordinates);
                }
                if (IsTheProductInTopAlley(tempCoordinates))
                {
                    tempCoordinates = new Coordinates(tempCoordinates.x - 1, tempCoordinates.y);
                    while (IsTheProductInTopAlley(tempCoordinates))
                    {
                        
                        if (ShopMap[new Coordinates(tempCoordinates.x - 1, tempCoordinates.y)].StateOfCell == CellState.TypeOfCell.WALL)
                        {
                            tempCoordinates = new Coordinates(tempCoordinates.x, tempCoordinates.y + 1);
                            tempPath.Add(tempCoordinates);
                            while (!IsTheProductInTopAlley(tempCoordinates))
                            {
                                tempCoordinates = new Coordinates(tempCoordinates.x, tempCoordinates.y + 1);
                                tempPath.Add(tempCoordinates);
                            }
                        }
                        while (IsTheProductInTopAlley(tempCoordinates))
                        {
                            tempPath.Add(tempCoordinates);
                            RemoveProductFromListIfPossible(tempCoordinates);
                            tempCoordinates = new Coordinates(tempCoordinates.x - 1, tempCoordinates.y);
                        }
                    }
                }
                else if (IsTheProductInDownAlley(tempCoordinates))
                {
                    tempCoordinates = new Coordinates(tempCoordinates.x + 1, tempCoordinates.y);
                    while (IsTheProductInDownAlley(tempCoordinates))
                    {
                        if (ShopMap[new Coordinates(tempCoordinates.x + 1, tempCoordinates.y)].StateOfCell == CellState.TypeOfCell.WALL)
                        {
                            tempCoordinates = new Coordinates(tempCoordinates.x, tempCoordinates.y + 1);
                            tempPath.Add(tempCoordinates);
                            while (!IsTheProductInDownAlley(tempCoordinates))
                            {
                                tempCoordinates = new Coordinates(tempCoordinates.x, tempCoordinates.y + 1);
                                tempPath.Add(tempCoordinates);
                            }
                        }
                        while (IsTheProductInDownAlley(tempCoordinates))
                        {
                            tempPath.Add(tempCoordinates);
                            RemoveProductFromListIfPossible(tempCoordinates);
                            tempCoordinates = new Coordinates(tempCoordinates.x + 1, tempCoordinates.y);
                        }
                    }
                }
                Coordinates leftCoordinates = new Coordinates(tempPath[tempPath.Count - 1].x, tempPath[tempPath.Count - 1].y - 1);
                Coordinates rightCoordinates = new Coordinates(tempPath[tempPath.Count - 1].x, tempPath[tempPath.Count - 1].y + 1);

                if (!CellState.IsProduct(ShopMap[leftCoordinates].StateOfCell))
                {
                    tempPath.Add(leftCoordinates);
                    tempCoordinates = new Coordinates(leftCoordinates.x, leftCoordinates.y);
                }
                else if (!CellState.IsProduct(ShopMap[rightCoordinates].StateOfCell))
                {
                    tempPath.Add(rightCoordinates);
                    tempCoordinates = new Coordinates(rightCoordinates.x, rightCoordinates.y);
                }
                if (IsCustomerIsOnTop(tempCoordinates))
                {
                    while (!InTheMainAlleyTop(tempCoordinates))
                    {
                        tempCoordinates = new Coordinates(tempCoordinates.x + 1, tempCoordinates.y);
                        tempPath.Add(tempCoordinates);
                    }
                }
                else
                {
                    while (!InTheMainAlleyDown(tempCoordinates))
                    {
                        tempCoordinates = new Coordinates(tempCoordinates.x - 1, tempCoordinates.y);
                        tempPath.Add(tempCoordinates);
                    }
                }


            }
            ActualCoordinates = new Coordinates(tempPath[tempPath.Count - 1].x, tempPath[tempPath.Count - 1].y);
            return tempPath;
        }
        public bool CanMove()
        {
            if (CustomerPath.Count <= 1)
                return false;
            Coordinates nextMove = CustomerPath[1];
            CellDictionary.TryGetValue(nextMove, out Cell cell);
            if (cell.Client == null)
                return true;
            else
                return false;
        }
        public void MakeMove()
        {
            if (!CanMove() && CustomerPath.Count <= 1)
                this.CustomerPath = GeneratePath(this.CustomerPath[0]);
            Coordinates actual = CustomerPath[0];
            Coordinates nextMove = CustomerPath[1];
            if (actual == nextMove)
            {
                CustomerPath.RemoveAt(1);
                nextMove = CustomerPath[1];
            }
            if (CellDictionary[nextMove].Client == null && CellDictionary[nextMove].TypeOfCell.StateOfCell != CellState.TypeOfCell.EXIT)
            {
                RemoveProductFromListIfPossible(nextMove);
                CellDictionary[nextMove].Client = this;
                CellDictionary[actual].Client = null;
                CustomerPath.RemoveAt(0);
            }
            else if (CellDictionary[nextMove].Client == null)
            {
                CellDictionary[nextMove].Client = this;
                CellDictionary[actual].Client = null;
            }
        }
        

    }
}
