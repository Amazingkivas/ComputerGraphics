using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class WavesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int idX = Clamp((int)(x + 20f * Math.Sin(2f * Math.PI * y / 60f)), 0, sourceImage.Width - 1);
            int idY = Clamp(y, 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(idX, idY);
        }
    }
}
