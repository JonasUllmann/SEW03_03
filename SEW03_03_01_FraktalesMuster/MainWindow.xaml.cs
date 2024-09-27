﻿using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Woopec.Core;

namespace SEW03_03_01_FraktalesMuster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        public static void TurtleMain()
        { 

            int level = 0;

            Random rnd = new Random();
            Woopec.Core.Color[] myColors = new Woopec.Core.Color[5];

            for (int i = 0;  i < 5; i++)
            {
                myColors[i] = new Woopec.Core.Color(rnd.Next(0,255), rnd.Next(0, 255), rnd.Next(0, 255));
            }

            drawH(200, 0, 0, 4, myColors);
            

            static void drawline(float x0, float y0, float x1, float y1, Woopec.Core.Color myColor)
            {
                var turt = Turtle.Seymour();
                turt.Speed = 100000;

                turt.PenUp();
                turt.GoTo((x0, y0));

                turt.PenDown();
                turt.Color = myColor;
                turt.GoTo((x1, y1));
                turt.HideTurtle();
            }

            static void drawH(float size, float x, float y, int level, Woopec.Core.Color[] myColors)
            {

                if (level == -1)
                {
                    return;
                }

                float half = size / 2;

                drawline(x - half, y, x + half, y, myColors[level]);

                drawline(x - half, y, x - half, y + half, myColors[level]);
                drawH(half, x - half, y + half, level - 1, myColors);

                drawline(x - half, y, x - half, y - half, myColors[level]);
                drawH(half, x - half, y-half, level - 1, myColors);

                drawline(x + half, y, x + half, y + half, myColors[level]);
                drawH(half, x + half, y + half, level - 1, myColors);

                drawline(x + half, y, x + half, y - half, myColors[level]);
                drawH(half, x + half, y - half, level - 1, myColors);
            }

        }



    }
}