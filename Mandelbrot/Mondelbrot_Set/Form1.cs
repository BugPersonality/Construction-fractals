using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mondelbrot_Set
{
    public partial class Form1 : Form
    {
        double x_min = -1.5, y_min = -1.5, x_max = 1.5, y_max = 1.5;
        double hx, hy, x_, y_, n = 0;

        Bitmap newBitmap;

        Size size;
        double SizeArea, ScaleArea;

        public Form1()
        {
            InitializeComponent();

            newBitmap = new Bitmap(imPict.Width, imPict.Height);
            imPict.Image = newBitmap;
            size = imPict.Size;

            SizeArea = 3;
            ScaleArea = 3;
        }

        private Color MandelBrot(double a, double b)
        {
            double x = 0, y = 0, xy, x2, y2, r = 0;
            int k = 100, loopgo = 0;

            do
            {
                loopgo++;
                x2 = Math.Pow(x, 2);
                y2 = Math.Pow(y, 2);
                xy = x * y;
                x = x2 - y2 + a;
                y = 2 * xy + b;
                r = x2 + y2;
            } 
            while (k > loopgo && r < 4);

            if (loopgo == k)
                return Color.FromArgb(k, k, k);
            else
                return Color.FromArgb(loopgo % 2 * 50, loopgo % 4 * 30, loopgo % 2 * 100);
        }

        private void Draw()
        {
            newBitmap = new Bitmap(imPict.Width, imPict.Height);
            imPict.Image = newBitmap;
            size = imPict.Size;

            Color tcolor = Color.Purple;

            for (int i = 0; i < imPict.Width; i++)
            {
                x_ = (hx - SizeArea / 2) + i * (SizeArea / size.Width);

                for (int j = 0; j < imPict.Height; j++)
                { 
                    y_ = (hy - SizeArea / 2) + j * (SizeArea / size.Height);

                    tcolor = MandelBrot(x_, y_);
                        
                    newBitmap.SetPixel(i, j, tcolor);
                }
            }

            imPict.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void Auto_Scale_Click(object sender, EventArgs e)
        {
            x_min = -1.5; y_min = -1; x_max = 1; y_max = 1;
            timer1.Enabled = true;
            Draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int CursorX = Cursor.Position.X;
            int CursorY = Cursor.Position.Y;

            int X = CursorX, Y = CursorY;

            hx = (hx - SizeArea / 2) + X * (SizeArea / size.Width);
            hy = (hy - SizeArea / 2) + Y * (SizeArea / size.Height);
            SizeArea /= ScaleArea;
            Draw();
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            int X = e.X,
                Y = e.Y;

            string _x = X.ToString();
            string _y = Y.ToString();

            Console.WriteLine($"{_x}, {_y}");
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    hx = (hx - SizeArea / 2) + X * (SizeArea / size.Width);
                    hy = (hy - SizeArea / 2) + Y * (SizeArea / size.Height);
                    SizeArea /= ScaleArea;
                    Draw();
                    break;
                case MouseButtons.Middle:
                    x_max = 1; y_max = 1;
                    SizeArea = 3;
                    ScaleArea = 3;
                    Draw();
                    break;
                case MouseButtons.Right:
                    x_ = (hx - SizeArea / 2) + X * (SizeArea / size.Width);
                    y_ = (hy - SizeArea / 2) + Y * (SizeArea / size.Height);
                    SizeArea *= ScaleArea;
                    Draw();
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e){}
    }
}
