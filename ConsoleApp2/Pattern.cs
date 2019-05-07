using System;
using System.Drawing;

namespace ConsoleApp2
{
    class Pattern
    {
        Bitmap image;
        int[,] Bit;

        public Pattern(Bitmap image)
        {
            this.image = new Bitmap(image);
            Bit = new int[image.Width, image.Height];
            Color co = new Color();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    co = image.GetPixel(x, y);
                    int Average = (co.R + co.G + co.B) / 3;
                    co = Color.FromArgb(Average, Average, Average);
                    this.image.SetPixel(x, y, co);
                    Bit[x, y] = (Average*10/255);
                }
            }
        }

        private Color[,] MakePattern(int value)
        {
            Color[,] pat;
            switch(value)
            {
                case 0:
                    pat = new Color[3,3]{ {Color.Black,Color.Black,Color.Black},{ Color.Black,Color.Black,Color.Black},{ Color.Black,Color.Black,Color.Black} };
                    return pat;
                case 1:
                    pat = new Color[3, 3] { { Color.Black, Color.Black, Color.Black }, { Color.Black, Color.Black, Color.White }, { Color.Black, Color.Black, Color.Black } };
                    return pat;
                case 2:
                    pat = new Color[3, 3] { { Color.Black, Color.Black, Color.Black }, { Color.Black, Color.Black, Color.White }, { Color.Black, Color.White, Color.Black } };
                    return pat;
                case 3:
                    pat = new Color[3, 3] { { Color.Black, Color.Black, Color.Black }, { Color.White, Color.Black, Color.White }, { Color.Black, Color.White, Color.Black } };
                    return pat;
                case 4:
                    pat = new Color[3, 3] { { Color.Black, Color.White, Color.Black }, { Color.White, Color.Black, Color.White }, { Color.Black, Color.White, Color.Black } };
                    return pat;
                case 5:
                    pat = new Color[3, 3] { { Color.White, Color.White, Color.Black }, { Color.White, Color.Black, Color.White }, { Color.Black, Color.White, Color.Black } };
                    return pat;
                case 6:
                    pat = new Color[3, 3] { { Color.White, Color.White, Color.Black }, { Color.White, Color.Black, Color.White }, { Color.Black, Color.White, Color.White } };
                    return pat;
                case 7:
                    pat = new Color[3, 3] { { Color.White, Color.White, Color.White }, { Color.White, Color.Black, Color.White }, { Color.Black, Color.White, Color.White  } };
                    return pat;
                case 8:
                    pat = new Color[3, 3] { { Color.White, Color.White, Color.White }, { Color.White, Color.White, Color.White }, { Color.Black, Color.White, Color.White } };
                    return pat;
                case 9:
                    pat = new Color[3, 3] { { Color.White, Color.White, Color.White }, { Color.White, Color.White, Color.White }, { Color.White, Color.White, Color.White } };
                    return pat;
                default:
                    pat = new Color[3, 3] { { Color.White, Color.White, Color.White }, { Color.White, Color.White, Color.White }, { Color.White, Color.White, Color.White } };
                    return pat;
            }
        }

        private void InsertPattern(int x, int y, Color[,] pat)
        {
            for(int i = x;(i<x+3)&&(i<image.Width);i++)
            {
                for(int j = y;(j<y+3)&&(j<image.Height);j++)
                {
                    try
                    {
                        image.SetPixel(i, j, pat[i % 3, j % 3]);
                    }
                    catch(ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e);
                    }
                    
                }
            }
        }

        public Image Dithering()
        {
            for(int x = 0; x < image.Width; x=x+3)
            {
                for(int y = 0; y< image.Height; y=y+3)
                {
                    InsertPattern(x, y, MakePattern(Bit[x, y]));
                }
            }
            return image;
        }
    }
}
