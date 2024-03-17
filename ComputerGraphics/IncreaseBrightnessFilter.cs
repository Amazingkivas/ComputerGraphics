using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class IncreaseBrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 32;
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + k, 0, 255),
                                               Clamp(sourceColor.G + k, 0, 255),
                                               Clamp(sourceColor.B + k, 0, 255));
            return resultColor;
        }
    }
}
