using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer.Sorts
{
    interface Iterator
    {
        int[] Iterate();

        bool CanIterate();
    }
}
