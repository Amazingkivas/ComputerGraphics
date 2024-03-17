using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphics
{
    class MedianFilter : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            List<int> Reds = new List<int>();
            List<int> Greens = new List<int>();
            List<int> Blues = new List<int>();

            int radiusX = 1;
            int radiusY = 1;

            for (int k = -radiusX; k <= radiusY; k++)
            {
                for (int l = -radiusX; l <= radiusY; l++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color color = sourceImage.GetPixel(idX, idY);

                    Reds.Add(color.R);
                    Greens.Add(color.G);
                    Blues.Add(color.B);
                }
            }

            Reds.Sort();
            Greens.Sort();
            Blues.Sort();

            return Color.FromArgb(Reds[Reds.Count() / 2], Greens[Greens.Count() / 2], Blues[Blues.Count() / 2]);
        }
    }
}
