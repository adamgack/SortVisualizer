using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class GeneratedArray
    {

        int[] array;

        public GeneratedArray(int size)
        {
            this.array = GenerateArray(size);
        }

        public int[] GenerateArray(int size)
        {
            array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            Random random = new Random();

            array = array.OrderBy(x => random.Next()).ToArray();

            return array;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(int i in array)
            {
                stringBuilder.Append(i + ", ");
            }
            return stringBuilder.ToString();
        }
    }
}
