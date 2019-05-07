using System;
using System.Drawing;

namespace ConsoleApp2
{
    class Convention
    {
        Bitmap image;

        public Convention(Bitmap image)
        {
            this.image = new Bitmap(image);
            Color co = new Color();
            for (int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    co = image.GetPixel(x, y);
                    int Average = (co.R + co.G + co.B) / 3;
                    co = Color.FromArgb(Average,Average,Average);
                    this.image.SetPixel(x, y, co);
                }
            }
        }

        public Image Dithering(int Conv)
        {
            for(int y = 0; y  < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    if (Conv < image.GetPixel(x, y).G)
                    {
                        image.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        image.SetPixel(x, y, Color.Black);
                    }
                }
            }
            //image.Save("make.png", System.Drawing.Imaging.ImageFormat.Png);
            return image;
        }
    }
}
