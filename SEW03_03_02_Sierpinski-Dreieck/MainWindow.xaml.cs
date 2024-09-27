using System.ComponentModel;
using System.Reflection.Emit;
using System.Text;
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


namespace SEW03_03_02_Sierpinski_Dreieck
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

            int level = 5;
            float startsize = 800;

            Random rnd = new Random();
            Woopec.Core.Color[] myColors = new Woopec.Core.Color[level];

            for (int i = 0; i < level; i++)
            {
                myColors[i] = new Woopec.Core.Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            }

            drawPattern(startsize, 0, 0, level-1, myColors);
            level--;
            drawtri(startsize / 2, 0, -startsize/4, level, myColors);




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

            static void drawPattern(float size, float x, float y, int level, Woopec.Core.Color[] myColors)
            {
                float half = size / 2;
                drawline(x - half, y - half, x + half, y - half, myColors[level]);
                drawline(x - half, y - half, x , y + half, myColors[level]);
                drawline(x, y + half, x + half, y - half, myColors[level]);
            }

            static void drawtri(float size, float x, float y, int level, Woopec.Core.Color[] myColors)
            {

                if (level == -1)
                {
                    return;
                }

                float half = size / 2;
                float quarter = size / 4;
                float threequarter = quarter * 3;


                drawline(x, y - half, x - quarter, y, myColors[level]);
                drawtri(half, x - half, y - quarter, level - 1,myColors);
                drawline(x - quarter, y, x - half, y + half, myColors[level]);

                drawline(x - half, y + half, x, y + half, myColors[level]);
                drawtri(half, x, y + threequarter, level - 1, myColors);
                drawline(x, y + half, x + half, y + half, myColors[level]);

                drawline(x + half, y + half, x + quarter, y, myColors[level]);
                drawtri(half, x + half, y - quarter, level - 1, myColors);
                drawline(x + quarter, y, x, y - half, myColors[level]);
                

                


            }

        }

    }
}