using System;
using System.Drawing;
using System.Windows.Forms;

namespace Barnsley_fern
{
    public partial class Form1 : Form
    {
        private const float MinX = -6;
        private const float MaxX = 6;
        private const float MinY = 0.1f;
        private const float MaxY = 10;

        private int PointNumber = 1;

        private int _width;
        private int _height;

        private Bitmap _bitmap;

        private Bitmap Clear_bitmap;

        private Graphics _graph;

        private Graphics _clear_graph;

       

        private float[] fern_probability = new float[4]
        {
            0.01f,
            0.2f,
            0.2f,
            0.85f
        };

        private float[] snow_probability = new float[4]
        {
            0.1f,
            0.2f,
            0.3f,
            0.45f
        };

        private float[] tree_probability = new float[5]
        {
            0.07f,
            0.5f,
            0.3f,
            0.2f,
            0.4f
        };

        private float[,] Barn_fern = new float[4, 6]
        {
            {0,      0,      0,     0.16f, 0, 0    },
            {-0.15f, 0.28f,  0.26f, 0.24f, 0, 0.44f},
            {0.2f,  -0.26f,  0.23f, 0.22f, 0, 1.6f },
            {0.85f,  0.04f, -0.04f, 0.85f, 0, 1.6f }
        };

        private float[,] snowflake = new float[3, 6]
        {
            { 0.5f, 0.0f, 0.0f, -0.5f, 0.0f, 1.0f },
            { 0.0f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f },
            { 0.5f, 0.0f, 0.0f, 0.5f, 0.5f, 0.5f}
        };

        private float[,] tree = new float[5, 6]
        {
            { 0.1950f, -0.4880f, 0.344f, 0.443f, 0.4431f, 0.2452f },
            { 0.4620f, 0.4140f, -0.2520f, 0.3610f, 0.2511f, 0.5692f },
            { -0.0580f, -0.0700f, 0.4530f, -0.1110f, 0.5976f, 0.0969f },
            { -0.0350f, -0.0700f, -0.4690f, 0.0220f, 0.4884f, 0.5069f },
            { -0.6370f, 0.0f, 0.0f, 0.5010f, 0.8562f, 0.2513f },
        };

        public Form1()
        {
            InitializeComponent();

            Clear_bitmap = new Bitmap(_PictureBox.Width, _PictureBox.Height);
            _clear_graph = Graphics.FromImage(Clear_bitmap);
            _clear_graph.Clear(Color.Black);
        }

        private void DrawSnow()
        {
            Random rnd = new Random();

            float xtemp = 0, ytemp = 0;

            int func_num = 0;

            for (int i = 1; i <= PointNumber; i++)
            {
                var num = rnd.NextDouble();

                for (int j = 0; j <= 2; j++)
                {
                    num = num - snow_probability[j];

                    if (num <= 0)
                    {
                        func_num = j;
                        break;
                    }
                }

                var x = snowflake[func_num, 0] * xtemp + snowflake[func_num, 1] * ytemp + snowflake[func_num, 4];
                var y = snowflake[func_num, 2] * xtemp + snowflake[func_num, 3] * ytemp + snowflake[func_num, 5];

                xtemp = x;
                ytemp = y;

                x = (int)(xtemp * _width + _PictureBox.Width / 2);
                y = (int)(ytemp * _height);

                _bitmap.SetPixel((int)x, (int)y, Color.BlueViolet);

            }
            
            _PictureBox.BackgroundImage = _bitmap;
        }

        private void DrawTree()
        {
            Random rnd = new Random();

            float xtemp = 0, ytemp = 0;

            int func_num = 0;

            for (int i = 1; i <= PointNumber; i++)
            {
                var num = rnd.NextDouble();

                for (int j = 0; j <= 4; j++)
                {
                    num = num - tree_probability[j];

                    if (num <= 0)
                    {
                        func_num = j;
                        break;
                    }
                }

                var x = tree[func_num, 0] * xtemp + tree[func_num, 1] * ytemp + tree[func_num, 4];
                var y = tree[func_num, 2] * xtemp + tree[func_num, 3] * ytemp + tree[func_num, 5];

                xtemp = x;
                ytemp = y;

                x = (int)(xtemp * _width + _PictureBox.Width / 2);
                y = (int)(ytemp * _height);

                _bitmap.SetPixel((int)x, (int)y, Color.Green);

            }
            _bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            _PictureBox.BackgroundImage = _bitmap;
        }

        private void DrawFern()
        {
            Random rnd = new Random();
            
            float xtemp = 0, ytemp = 0;
            
            int func_num = 0;

            for (int i = 1; i <= PointNumber; i++)
            {
                var num = rnd.NextDouble();
                
                for (int j = 0; j <= 3; j++)
                {
                    num = num - fern_probability[j];

                    if (num <= 0)
                    {
                        func_num = j;
                        break;
                    }
                }

                var x = Barn_fern[func_num, 0] * xtemp + Barn_fern[func_num, 1] * ytemp + Barn_fern[func_num, 4];
                var y = Barn_fern[func_num, 2] * xtemp + Barn_fern[func_num, 3] * ytemp + Barn_fern[func_num, 5];

                xtemp = x;
                ytemp = y;

                x = (int)(xtemp * _width + _PictureBox.Width / 2);
                y = (int)(ytemp * _height);

                _bitmap.SetPixel((int)x, (int)y, Color.LawnGreen);

            }
            _bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            _PictureBox.BackgroundImage = _bitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _PictureBox.BackgroundImage = Clear_bitmap;

            _bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            PointNumber += 100;

            DrawFern();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _PictureBox.BackgroundImage = Clear_bitmap;

            PointNumber += 100;

            DrawSnow();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            _PictureBox.BackgroundImage = Clear_bitmap;

            _bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            PointNumber += 100;

            DrawTree();
        }

        private void button_snow(object sender, EventArgs e)
        {
            _width = (int)((_PictureBox.Width * 6) / (MaxX - MinX));
            _height = (int)((_PictureBox.Height * 6) / (MaxY - MinY));
            _bitmap = new Bitmap(_PictureBox.Width * 6, _PictureBox.Height * 6);
            _graph = Graphics.FromImage(_bitmap);
            _graph.Clear(Color.Black);

            timer2.Enabled = true;
        }

        private void button_fern(object sender, EventArgs e)
        {
            _width = (int)((_PictureBox.Width / 1.5) / (MaxX - MinX));
            _height = (int)((_PictureBox.Height / 1.5) / (MaxY - MinY));
            _bitmap = new Bitmap(_PictureBox.Width, _PictureBox.Height);
            _graph = Graphics.FromImage(_bitmap);
            _graph.Clear(Color.Black);

            timer1.Enabled = true;
        }

        private void button_tree(object sender, EventArgs e)
        {
            _width = (int)((_PictureBox.Width * 6) / (MaxX - MinX));
            _height = (int)((_PictureBox.Height * 6) / (MaxY - MinY));
            _bitmap = new Bitmap(_PictureBox.Width, _PictureBox.Height);
            _graph = Graphics.FromImage(_bitmap);
            _graph.Clear(Color.Black);

            timer3.Enabled = true;
        }

        private void button_clear(object sender, EventArgs e)
        {
            _PictureBox.BackgroundImage = Clear_bitmap;

            timer1.Enabled = false;

            timer2.Enabled = false;

            timer3.Enabled = false;
        }

        private void FernPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
