
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormThreading1
{
    internal static class ArrayInternalUtils
    {
        public static int[] createIntRandomArray(int size, int from, int to)
        {
            int[] data = new int[size];
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; ++i)
            {
                data[i] = random.Next(from, to);
            }
            return data;
        }

        public static double[] createRandomFloatArray(int size, double from, double to)
        {
            double[] data = new double[size];
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; ++i)
            {
                data[i] = from + (to - from) * random.NextDouble();
            }
            return data;
        }
    }
}
