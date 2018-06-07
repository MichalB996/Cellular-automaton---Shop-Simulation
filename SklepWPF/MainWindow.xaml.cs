using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SklepWPF
{

    public partial class MainWindow : Window
    {
        Rectangle[,] rectTable = new Rectangle[13,41];
        ReadShop shop;
        Simulation sim;
        List<Cell> lista;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int chose = 0;
            if (Shop_1.IsChecked == true)
                chose = 0;
            if (Shop_2.IsChecked == true)
                chose = 1;
            shop = new ReadShop(chose);
            shop.ToShopState();
            lista = shop.CellDictionary.Values.ToList();
            MakeShop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Shop_1.IsChecked == true)
                ShopCells();
            if (Shop_2.IsChecked == true)
                ShopCellstry();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int amount = int.Parse(Customers_amount.Text);
            sim = new Simulation(amount, shop);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sim.Iterate();
            if (Shop_1.IsChecked == true)
                ShopCells();
            if (Shop_2.IsChecked == true)
                ShopCellstry();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {}

        public void ShowShop()
        {
            for(int i =0;i<shop.InData.Count;i++)
            {
                string line = shop.InData[i];
                for(int j =0; j < shop.InData[0].Length;j++)
                {
                        Rectangle rectangle = new Rectangle
                        {
                            Height = 15,
                            Width = 15,
                            StrokeThickness = 0.25,
                            Stroke = Brushes.Black,
                        };
                    if (line[j].ToString() == "a")
                    {
                        rectangle.Fill = Brushes.Red;
                    }
                    else if (line[j].ToString() == "b")
                    {
                        rectangle.Fill = Brushes.LightYellow;
                    }
                    else if (line[j].ToString() == "B")
                    {
                        rectangle.Fill = Brushes.Brown;
                    }
                    else if (line[j].ToString() == "c")
                    {
                        rectangle.Fill = Brushes.RosyBrown;
                    }
                    else if (line[j].ToString() == "C")
                    {
                        rectangle.Fill = Brushes.BlanchedAlmond;
                    }
                    else if (line[j].ToString() == "e")
                    {
                        rectangle.Fill = Brushes.Blue;
                    }
                    else if (line[j].ToString() == "E")
                    {
                        rectangle.Fill = Brushes.Green;
                    }
                    else if (line[j].ToString() == "f")
                    {
                        rectangle.Fill = Brushes.LightSteelBlue;
                    }
                    else if (line[j].ToString() == "g")
                    {
                        rectangle.Fill = Brushes.LightGreen;
                    }
                    else if (line[j].ToString() == "h")
                    {
                        rectangle.Fill = Brushes.PaleVioletRed;
                    }
                    else if (line[j].ToString() == "H")
                    {
                        rectangle.Fill = Brushes.LightGoldenrodYellow;
                    }
                    else if (line[j].ToString() == "k")
                    {
                        rectangle.Fill = Brushes.LawnGreen;
                    }
                    else if (line[j].ToString() == "m")
                    {
                        rectangle.Fill = Brushes.NavajoWhite;
                    }
                    else if (line[j].ToString() == "l")
                    {
                        rectangle.Fill = Brushes.MediumVioletRed;
                    }
                    else if (line[j].ToString() == "p")
                    {
                        rectangle.Fill = Brushes.White;
                    }
                    else if (line[j].ToString() == "P")
                    {
                        rectangle.Fill = Brushes.White;
                    }
                    else if (line[j].ToString() == "r")
                    {
                        rectangle.Fill = Brushes.BlueViolet;
                    }
                    else if (line[j].ToString() == "s")
                    {
                        rectangle.Fill = Brushes.IndianRed;
                    }
                    else if (line[j].ToString() == "S")
                    {
                        rectangle.Fill = Brushes.WhiteSmoke;
                    }
                    else if (line[j].ToString() == "T")
                    {
                        rectangle.Fill = Brushes.MistyRose;
                    }
                    else if (line[j].ToString() == "t")
                    {
                        rectangle.Fill = Brushes.YellowGreen;
                    }
                    else if (line[j].ToString() == "w")
                    {
                        rectangle.Fill = Brushes.Black;
                    }
                    else if (line[j].ToString() == "W")
                    {
                        rectangle.Fill = Brushes.GhostWhite;
                    }
                    else if (line[j].ToString() == "y")
                    {
                        rectangle.Fill = Brushes.FloralWhite;
                    }
                    else if (line[j].ToString() == "z")
                    {
                        rectangle.Fill = Brushes.BlueViolet;
                    }
                    else if (line[j].ToString() == "L")
                    {
                        rectangle.Fill = Brushes.LightSeaGreen;
                    }
                    Canvas.SetLeft(rectangle, j * 15);
                    Canvas.SetTop(rectangle, i * 15);
                    canvasDrawingArea.Children.Add(rectangle);
                }
                
            }

        }
        public void ShopCells1()
        {
            List<Cell> list = new List<Cell>();
            list = shop.CellDictionary.Values.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                rectTable[list[i].CellCoordinates.x,list[i].CellCoordinates.y]= new Rectangle
                {
                    Height = 15,
                    Width = 15,
                    StrokeThickness = 0.25,
                    Stroke = Brushes.Black,
                };
                if(list[i].Client == null)
                {
                    if (list[i].TypeOfCell.ToString() == "APPLE")
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Red;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BUTTER)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightYellow;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BREAD)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Brown;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CAKE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.RosyBrown;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHOCOLATE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.BlanchedAlmond;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.ENTRY)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Blue;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.EXIT)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Green;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CIGARETTES)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightSteelBlue;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEAR)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightGreen;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.HAM)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.PaleVioletRed;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHIPS)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightGoldenrodYellow;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CABBAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill =  Brushes.LawnGreen;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.MILK)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.NavajoWhite;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LAMB)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.MediumVioletRed;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PASSAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.FISH)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SAUSAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.IndianRed;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SALT)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.WhiteSmoke;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.STRAWBERRY)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.MistyRose;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHEESE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.YellowGreen;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WALL)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Black;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WATER)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.GhostWhite;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.YOGHURT)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.FloralWhite;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEPPER)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LETTUCE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightSeaGreen;
                    }
                }
                if (list[i].Client != null)
                {
                    rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.HotPink;
                }                
            }
            for(int i = 0; i<13;i++)
            {
                for(int j= 0;j<33;j++)
                {
                    Canvas.SetLeft(rectTable[i,j], j * 15);
                    Canvas.SetTop(rectTable[i,j], i * 15);
                    canvasDrawingArea.Children.Add(rectTable[i,j]);
                }
            }

        }
        public void ShopCells()
        {
            List<Cell> list = new List<Cell>();
            list = shop.CellDictionary.Values.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y] = new Rectangle
                {
                    Height = 15,
                    Width = 15,
                    StrokeThickness = 0.25,
                    Stroke = Brushes.Black,
                };
                if (list[i].Client == null)
                {
                    if (list[i].TypeOfCell.ToString() == "APPLE")
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Red;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BUTTER)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightYellow;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BREAD)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Brown;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CAKE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.RosyBrown;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHOCOLATE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.BlanchedAlmond;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.ENTRY)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Blue;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.EXIT)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Green;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CIGARETTES)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightSteelBlue;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEAR)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightGreen;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.HAM)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.PaleVioletRed;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHIPS)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightGoldenrodYellow;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CABBAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LawnGreen;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.MILK)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.NavajoWhite;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LAMB)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.MediumVioletRed;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PASSAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.FISH)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SAUSAGE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.IndianRed;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SALT)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.WhiteSmoke;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.STRAWBERRY)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.MistyRose;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHEESE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.YellowGreen;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WALL)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.Black;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WATER)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.GhostWhite;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.YOGHURT)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.FloralWhite;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEPPER)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (list[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LETTUCE)
                    {
                        rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.LightSeaGreen;
                    }
                }
                if (list[i].Client != null)
                {
                    rectTable[list[i].CellCoordinates.x, list[i].CellCoordinates.y].Fill = Brushes.HotPink;
                }
            }
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    Canvas.SetLeft(rectTable[i, j], j * 15);
                    Canvas.SetTop(rectTable[i, j], i * 15);
                    canvasDrawingArea.Children.Add(rectTable[i, j]);
                }
            }
            GC.Collect(0);
            GC.Collect(1);
        }
        public void MakeShop()
        {   
            for (int i = 0; i < lista.Count; i++)
            {
                rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y] = new Rectangle
                {
                    Height = 15,
                    Width = 15,
                    StrokeThickness = 0.25,
                    Stroke = Brushes.Black,
                };

                
                if (lista[i].Client == null)
                {
                    if (lista[i].TypeOfCell.ToString() == "APPLE")
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Red;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BUTTER)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightYellow;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BREAD)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Brown;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CAKE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.RosyBrown;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHOCOLATE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.BlanchedAlmond;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.ENTRY)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Blue;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.EXIT)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Green;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CIGARETTES)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightSteelBlue;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEAR)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightGreen;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.HAM)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.PaleVioletRed;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHIPS)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightGoldenrodYellow;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CABBAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LawnGreen;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.MILK)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.NavajoWhite;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LAMB)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.MediumVioletRed;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PASSAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.FISH)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SAUSAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.IndianRed;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SALT)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.WhiteSmoke;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.STRAWBERRY)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.MistyRose;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHEESE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.YellowGreen;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WALL)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Black;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WATER)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.GhostWhite;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.YOGHURT)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.FloralWhite;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEPPER)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LETTUCE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightSeaGreen;
                    }
                }
                if (lista[i].Client != null)
                {
                    rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.HotPink;
                }
            }
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    Canvas.SetLeft(rectTable[i, j], j * 15);
                    Canvas.SetTop(rectTable[i, j], i * 15);
                    canvasDrawingArea.Children.Add(rectTable[i, j]);
                }
            }
        }
        public void ShopCellstry()
        {
            for (int i = 0; i < lista.Count; i++)
            {

                if (lista[i].Client == null)
                {
                    if (lista[i].TypeOfCell.ToString() == "APPLE")
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Red;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BUTTER)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightYellow;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.BREAD)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Brown;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CAKE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.RosyBrown;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHOCOLATE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.BlanchedAlmond;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.ENTRY)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Blue;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.EXIT)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Green;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CIGARETTES)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightSteelBlue;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEAR)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightGreen;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.HAM)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.PaleVioletRed;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHIPS)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightGoldenrodYellow;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CABBAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LawnGreen;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.MILK)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.NavajoWhite;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LAMB)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.MediumVioletRed;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PASSAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PRIORITY_PASSAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.White;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.FISH)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SAUSAGE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.IndianRed;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.SALT)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.WhiteSmoke;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.STRAWBERRY)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.MistyRose;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.CHEESE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.YellowGreen;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WALL)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.Black;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.WATER)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.GhostWhite;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.YOGHURT)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.FloralWhite;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.PEPPER)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.BlueViolet;
                    }
                    else if (lista[i].TypeOfCell.StateOfCell == CellState.TypeOfCell.LETTUCE)
                    {
                        rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.LightSeaGreen;
                    }
                }
                if (lista[i].Client != null)
                {
                    rectTable[lista[i].CellCoordinates.x, lista[i].CellCoordinates.y].Fill = Brushes.OrangeRed;
                }
            }


        }


        
    }
}
