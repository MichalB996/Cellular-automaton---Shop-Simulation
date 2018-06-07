using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepWPF
{
    class ReadShop
    {
        private String filePath;
        public List<string> InData { get; set; }
        public Dictionary<Coordinates, CellState> InputData { get; set; }
        public Dictionary<Coordinates, CellState> InDat { get; set; }
        public Dictionary<Coordinates, Cell> CellDictionary { get; set; }
        private int Flag { get; set; }
        public int Chose { get; set; }

        public ReadShop(int chose)
        {
            this.Chose = chose;
            if( chose == 0 )
                filePath = @"C:\Users\Michał\Desktop\Studia\SSIPD\Sklep_WPF\sklep.txt";
            else if(chose == 1)
                filePath = @"C:\Users\Michał\Desktop\Studia\SSIPD\Sklep_WPF\sklep1.txt";
                
            InData = new List<string>(File.ReadAllLines(filePath).ToList());
            InputData = new Dictionary<Coordinates, CellState>(new CoordinatesComparer());
            InDat = new Dictionary<Coordinates, CellState>();
            CellDictionary = new Dictionary<Coordinates, Cell>(new CoordinatesComparer());
            Flag = 0;
        }
        public void ToShopState()
        {
            foreach (string line in InData)
            {

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "a")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.APPLE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.APPLE)));
                    }
                    else if (line[i].ToString() == "b")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.BUTTER));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.BUTTER)));
                    }
                    else if (line[i].ToString() == "B")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.BREAD));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.BREAD)));
                    }
                    else if (line[i].ToString() == "c")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CAKE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CAKE)));
                    }
                    else if (line[i].ToString() == "C")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CHOCOLATE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CHOCOLATE)));
                    }
                    else if (line[i].ToString() == "e")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.ENTRY));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.ENTRY)));
                    }
                    else if (line[i].ToString() == "E")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.EXIT));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.EXIT)));
                    }
                    else if (line[i].ToString() == "f")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CIGARETTES));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CIGARETTES)));
                    }
                    else if (line[i].ToString() == "g")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PEAR));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PEAR)));
                    }
                    else if (line[i].ToString() == "h")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.HAM));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.HAM)));
                    }
                    else if (line[i].ToString() == "H")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CHIPS));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CHIPS)));

                    }
                    else if (line[i].ToString() == "k")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CABBAGE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CABBAGE)));
                    }
                    else if (line[i].ToString() == "m")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.MILK));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.MILK)));
                    }
                    else if (line[i].ToString() == "l")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.LAMB));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.LAMB)));
                    }
                    else if (line[i].ToString() == "p")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PASSAGE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PASSAGE)));
                    }
                    else if (line[i].ToString() == "P")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PRIORITY_PASSAGE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PRIORITY_PASSAGE)));
                    }
                    else if (line[i].ToString() == "r")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.FISH));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.FISH)));
                    }
                    else if (line[i].ToString() == "s")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.SAUSAGE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.SAUSAGE)));
                    }
                    else if (line[i].ToString() == "S")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.SALT));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.SALT)));
                    }
                    else if (line[i].ToString() == "T")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.STRAWBERRY));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.STRAWBERRY)));
                    }
                    else if (line[i].ToString() == "t")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CHEESE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.CHEESE)));
                    }
                    else if (line[i].ToString() == "w")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.WALL));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.WALL)));
                    }
                    else if (line[i].ToString() == "W")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.WATER));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.WATER)));
                    }
                    else if (line[i].ToString() == "y")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.YOGHURT));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.YOGHURT)));
                    }
                    else if (line[i].ToString() == "z")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PEPPER));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.PEPPER)));
                    }
                    else if (line[i].ToString() == "L")
                    {
                        InputData.Add(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.LETTUCE));
                        CellDictionary.Add(new Coordinates(Flag, i), new Cell(new Coordinates(Flag, i), new CellState(CellState.TypeOfCell.LETTUCE)));
                    }
                    else
                        throw new Exception("Cell value is incorrect. Check your input matrix");

                }
                Flag++;
            }
        }
        public List<Cell> getEntries()
        {
            List<Cell> cellDictionaryToList = CellDictionary.Values.ToList();
            List<Cell> listOfEntries = cellDictionaryToList.Where(x => x.TypeOfCell.StateOfCell == CellState.TypeOfCell.ENTRY).ToList();
            return listOfEntries;
        }
        public void ShowList()
        {

            foreach (string s in InData)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].ToString() == "w")
                        Console.Write("*");
                    else if (s[i].ToString() == "p" || s[i].ToString() == "P")
                        Console.Write(" ");
                    else if (s[i].ToString() == "E")
                        Console.Write("K");
                    else if (s[i].ToString() == "e")
                        Console.Write("E");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        

       

    }
}
