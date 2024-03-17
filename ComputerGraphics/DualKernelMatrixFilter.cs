using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class DualKernelMatrixFilter : MatrixFilter
    {
        protected float[,] kernel2;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = calculateNewAxisOrientedPixelColor(sourceImage, x, y, kernel);
            int R = resultColor.R;
            int G = resultColor.G;
            int B = resultColor.B;

            resultColor = calculateNewAxisOrientedPixelColor(sourceImage, x, y, kernel2);
            resultColor = Color.FromArgb(Clamp((int)(Math.Sqrt(R * R + resultColor.R * resultColor.R)), 0, 255),
                                         Clamp((int)(Math.Sqrt(G * G + resultColor.G * resultColor.G)), 0, 255),
                                         Clamp((int)(Math.Sqrt(B * B + resultColor.B * resultColor.B)), 0, 255));
            return resultColor;
        }

        protected Color calculateNewAxisOrientedPixelColor(Bitmap sourceImage, int x, int y, float[,] kernel)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int i = -radiusY; i <= radiusY; i++)
                for (int j = -radiusX; j <= radiusX; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[j + radiusX, i + radiusY];
                    resultG += neighborColor.G * kernel[j + radiusX, i + radiusY];
                    resultB += neighborColor.B * kernel[j + radiusX, i + radiusY];
                }
            return Color.FromArgb(
              Clamp((int)resultR, 0, 255),
              Clamp((int)resultG, 0, 255),
              Clamp((int)resultB, 0, 255)
              );
        }
    }
}
