using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class PruittFilter : DualKernelMatrixFilter
    {
        public PruittFilter()
        {
            kernel = new float[,] { { -1f, 0f, 1f },
                                    { -1f, 0f, 1f },
                                    { -1f, 0f, 1f } };

            kernel2 = new float[,] { { -1f, -1f, -1f },
                                     { 0f, 0f, 0f },
                                     { 1f, 1f, 1f } };
        }
    }
}
