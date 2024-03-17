using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class SobelFilter : DualKernelMatrixFilter
    {
        public SobelFilter()
        {
            kernel = new float[,] { { -1f, 0f, 1f }, 
                                    { -2f, 0f, 2f }, 
                                    { -1f, 0f, 1f } };

            kernel2 = new float[,] { { -1f, -2f, -1f }, 
                                     { -0f, 0f, 0f }, 
                                     { 1f, 2f, 1f } };
        }
    }
}
