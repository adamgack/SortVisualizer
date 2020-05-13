using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer.Sorts
{
    public class BubbleSort : Iterator
    {

        private int innerCount = 0;

        private int outerCount = 0;

        private bool canIterate = true;

        public int[] Iterate(int[] arrayToSort)
        {
            int t;
            while (outerCount <= arrayToSort.Length - 2)
            {
                while (innerCount <= arrayToSort.Length - 2)
                {
                    if (arrayToSort[innerCount] > arrayToSort[innerCount + 1])
                    {
                        t = arrayToSort[innerCount + 1];
                        arrayToSort[innerCount + 1] = arrayToSort[innerCount];
                        arrayToSort[innerCount] = t;
                        innerCount += 1;
                        return arrayToSort;
                    }
                    innerCount += 1;
                }
                innerCount = 0;
                outerCount += 1;
            }
            canIterate = false;
            return arrayToSort;
        }

        public bool CanIterate()
        {
            return canIterate;
        }
    }
}
