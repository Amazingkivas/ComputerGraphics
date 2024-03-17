using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerGraphics
{
    class LinearHistogramStretchingFilter : Filters
    {
        protected int maxR, maxG, maxB, minR, minG, minB;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = sourceImage.GetPixel(x, y);

            float R = (resultColor.R - minR) * 255f / (maxR - minR);
            float G = (resultColor.G - minG) * 255f / (maxG - minG);
            float B = (resultColor.B - minB) * 255f / (maxB - minB);

            resultColor = Color.FromArgb(Clamp((int)R, 0, 255),
                                         Clamp((int)G, 0, 255),
                                         Clamp((int)B, 0, 255));
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            setMinPixelColor(sourceImage);
            setMaxPixelColor(sourceImage);

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                worker.ReportProgress((int)((float)x / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            }
            return resultImage;
        }

        public void setMaxPixelColor(Bitmap sourceImage)
        {
            maxR = 0;
            maxG = 0;
            maxB = 0;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);

                    maxR = Math.Max(maxR, color.R);
                    maxB = Math.Max(maxB, color.B);
                    maxG = Math.Max(maxG, color.G);
                }
            }
        }

        public void setMinPixelColor(Bitmap sourceImage)
        {
            minR = 255;
            minG = 255;
            minB = 255;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);

                    minR = Math.Min(minR, color.R);
                    minB = Math.Min(minB, color.B);
                    minG = Math.Min(minG, color.G);
                }
            }
        }
    }
}
