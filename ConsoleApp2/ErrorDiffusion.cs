using System;
using System.Drawing;

namespace ConsoleApp2
{
    class ErrorDiffusion
    {
        Bitmap image;
        Color error;
        int oldpixel;
        int newpixel;
        int quantum_error;

        public ErrorDiffusion(Bitmap image)
        {
            this.image = new Bitmap(image);
            error = new Color();
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
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    oldpixel = image.GetPixel(x, y).R;

                    if (oldpixel < 128)
                    {
                        image.SetPixel(x, y, Color.Black);
                        quantum_error = oldpixel;
                    }
                    else
                    {
                        image.SetPixel(x, y, Color.White);
                        quantum_error = oldpixel - 255;
                    }

                    MakeError(x, y);
                }
            }
            return image;
        }
        private void MakeError(int x, int y)
        {
            if (x + 1 < image.Width)
            {
                newpixel = image.GetPixel(x + 1, y).R + (quantum_error * 7 / 16);
                if (newpixel > 255)
                    newpixel = 255;
                else if (newpixel < 0)
                    newpixel = 0;
                error = Color.FromArgb(newpixel, newpixel, newpixel);
                image.SetPixel(x + 1, y, error);
            }

            if ((image.Width < x - 1) && (y + 1 < image.Height))
            {
                newpixel = image.GetPixel(x - 1, y + 1).R + (quantum_error * 3 / 16);
                if (newpixel > 255)
                    newpixel = 255;
                else if (newpixel < 0)
                    newpixel = 0;
                error = Color.FromArgb(newpixel, newpixel, newpixel);
                image.SetPixel(x - 1, y + 1, error);
            }

            if (y + 1 < image.Height)
            {
                newpixel = image.GetPixel(x, y + 1).R + (quantum_error * 5 / 16);
                if (newpixel > 255)
                    newpixel = 255;
                else if (newpixel < 0)
                    newpixel = 0;
                error = Color.FromArgb(newpixel, newpixel, newpixel);
                image.SetPixel(x, y + 1, error);
            }

            if ((x + 1 < image.Width) && (y + 1 < image.Height))
            {
                newpixel = image.GetPixel(x + 1, y + 1).R + (quantum_error * 1 / 16);
                if (newpixel > 255)
                    newpixel = 255;
                else if (newpixel < 0)
                    newpixel = 0;
                error = Color.FromArgb(newpixel, newpixel, newpixel);
                image.SetPixel(x + 1, y + 1, error);
            }
        }


    }
}
