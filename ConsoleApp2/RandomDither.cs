using System;
using System.Drawing;

namespace ConsoleApp2
{
    class RandomDither
    {
        Bitmap image;
        Random rand;

        public RandomDither(Bitmap image)
        {
            rand = new Random();
            this.image = new Bitmap(image);
            Color co = new Color();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    co = image.GetPixel(x, y);
                    int Average = (co.R + co.G + co.B) / 3;
                    co = Color.FromArgb(Average, Average, Average);
                    this.image.SetPixel(x, y, co);
                }
            }
        }

        public Image Dithering()
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (rand.Next(255) < image.GetPixel(x, y).G)
                    {
                        image.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        image.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return image;
        }
    }
}
