using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class SharrFilter : DualKernelMatrixFilter
    {
        public SharrFilter()
        {
            kernel = new float[,] { { 3f, 0f, -3f },
                                    { 10f, 0f, -10f },
                                    { 3f, 0f, -3f } };

            kernel2 = new float[,] { { 3f, 10f, 3f },
                                     { 0f, 0f, 0f },
                                     { -3f, -10f, -3f } };
        }
    }
}
