using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class Rotate : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double mu = Math.PI * 0.25;
            int x0 = (int)(sourceImage.Width / 2f);
            int y0 = (int)(sourceImage.Height / 2f);

            int idX = (int)((x - x0) * Math.Cos(mu) - (y - y0) * Math.Sin(mu) + x0);
            int idY = (int)((x - x0) * Math.Sin(mu) + (y - y0) * Math.Cos(mu) + y0);

            if (idX >= sourceImage.Width || idX < 0 || idY >= sourceImage.Height || idY < 0) 
                return Color.FromArgb(0, 0, 0);
            else return sourceImage.GetPixel(idX, idY);
        }
    }
}
