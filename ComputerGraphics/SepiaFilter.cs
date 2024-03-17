using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float k = 16f;
            Color sourceColor = sourceImage.GetPixel(x, y);

            int intensity = (int)Math.Round(0.299f * sourceColor.R + 0.587f * sourceColor.G + 0.114f * sourceColor.B);
            int R = Clamp((int)Math.Round(intensity + 2f * k), 0, 255);
            int G = Clamp((int)Math.Round(intensity + 0.5f * k), 0, 255);
            int B = Clamp((int)Math.Round(intensity - 1f * k), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
