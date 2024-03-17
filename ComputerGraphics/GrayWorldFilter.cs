using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ComputerGraphics
{
    class GrayWorldFilter : Filters
    {
        float R = 0f;
        float G = 0f;
        float B = 0f;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = sourceImage.GetPixel(x, y);
            resultColor = Color.FromArgb(Clamp((int)(resultColor.R * R), 0, 255),
                                         Clamp((int)(resultColor.G * G), 0, 255),
                                         Clamp((int)(resultColor.B * B), 0, 255));
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            setCoeffs(sourceImage);

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

        protected void setCoeffs(Bitmap sourceImage)
        {
            Color sourcePixelColor;
            int sizeOfImage = sourceImage.Height * sourceImage.Width;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    sourcePixelColor = sourceImage.GetPixel(i, j);
                    R += sourcePixelColor.R;
                    G += sourcePixelColor.G;
                    B += sourcePixelColor.B;
                }
            normalizeCoeffs(sourceImage.Height * sourceImage.Width);
        }
        protected void normalizeCoeffs(int imageSize)
        {
            R /= imageSize;
            G /= imageSize;
            B /= imageSize;

            float averageColor = (R + G + B) / 3f;

            R = averageColor / R;
            G = averageColor / G;
            B = averageColor / B;
        }
    }
}
