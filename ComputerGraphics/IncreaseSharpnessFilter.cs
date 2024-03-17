using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class IncreaseSharpnessFilter : MatrixFilter
    {
        public IncreaseSharpnessFilter()
        {
            kernel = new float[3, 3] { { 0f, -1f, 0f },
                                       { -1f, 5f, -1f },
                                       { 0f, -1f, 0f } };
        }
    }
}
