using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormThreading1
{
    public delegate bool TaskProcessDelegate<U, V>(U[] items, ref bool canRun, out V result, Action<V, int> progressCallback);
    interface IArrayProcessor
    {
        void Run();

        void Stop();
    }
    public class ArrayProcessor<D, T>: IArrayProcessor
    {
        public D[] Data { get; set; }

        private bool isRun = false;
        public TaskProcessDelegate<D, T> Action { get; set; }
        public Action<T, bool> FinalCallback { get; set; }
        public Action<T, int> ProgressCallback { get; set; }
        
        public void Run()
        {
            if (this.isRun)
            {
                return;
            }

            this.isRun = true;
            Thread task = new Thread(new ParameterizedThreadStart(Process));
            task.Start(this.Data);
        }

        public void Stop()
        {
            this.isRun = false;
        }

        private void Process(object o)
        {
            if (this.Action != null)
            {
                D[] data = (D[])o;
                var status = this.Action(data, ref this.isRun, out T result, this.ProgressCallback);
                this.FinalCallback?.Invoke(result, status);
                this.isRun = false;
            }

        }

    }

    public static class ProcessorFunctions
    {
        public static bool IntProcessFunction1(int[] data, ref bool canRun, out double result, Action<double, int> progressCalback)
        {
            result = 0;
            int count = 0;
            for (var i = 0; i < data.Length && canRun; ++i)
            {
                if (data[i] > 0)
                {
                    result += data[i];
                    ++count;
                }

                int progress = (int)((i + 1.0) * 100 / data.Length);

                progressCalback?.Invoke(result, progress);

                Thread.Sleep(10);
            }

            return canRun;
        }

        public static bool DoubleProcessFunction2(double[] data, ref bool canRun, out double result, Action<double, int> progressCalback)
        {
            result = 0;
            for (var i = 0; i < data.Length && canRun; ++i)
            {
                result += data[i] * data[i];
                int progress = (int)((i + 1.0) * 100 / data.Length);
                progressCalback?.Invoke(result, progress);

                Thread.Sleep(10);
            }

            return canRun;
        }
    }
}
