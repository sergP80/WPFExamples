using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormThreading1
{
    public partial class fmMain : Form
    {
        private List<IArrayProcessor> arrayProcessors = new List<IArrayProcessor>();
        public fmMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString();
        }

        private void InitProcessors()
        {
            IArrayProcessor processor = new ArrayProcessor<int, double>();
            ((ArrayProcessor<int, double>)processor).Action = ProcessorFunctions.IntProcessFunction1;
            ((ArrayProcessor<int, double>)processor).Data = ArrayInternalUtils.createIntRandomArray(1000, -1000, 100); ;
            ((ArrayProcessor<int, double>)processor).ProgressCallback = ProgressCallback1;
            ((ArrayProcessor<int, double>)processor).FinalCallback = FinalCallback1;
            this.arrayProcessors.Add(processor);

            processor = new ArrayProcessor<double, double>();
            ((ArrayProcessor<double, double>)processor).Action = ProcessorFunctions.DoubleProcessFunction2;
            ((ArrayProcessor<double, double>)processor).Data = ArrayInternalUtils.createRandomFloatArray(1000, -1000, 100); ;
            ((ArrayProcessor<double, double>)processor).ProgressCallback = ProgressCallback2;
            ((ArrayProcessor<double, double>)processor).FinalCallback = FinalCallback2;
            this.arrayProcessors.Add(processor);
        }

        private void InternalFinalCallback(Label label, double result, bool status)
        {
            label.Invoke((MethodInvoker)delegate {
                if (status)
                {
                    label.Text = string.Format("Result: {0}", result);

                }
                else
                {
                    label.Text = "Computation task was broken";
                }
            });
        }

        private void FinalCallback1(double result, bool status)
        {
            InternalFinalCallback(this.lbResult, result, status);
        }

        private void FinalCallback2(double result, bool status)
        {
            InternalFinalCallback(this.lbResult2, result, status);
        }

        private void InternalProgressCallback(Label label, double result, int progress)
        {
            label.Invoke((MethodInvoker)delegate {
                label.Text = string.Format("Processed {0}%. Current result: {1:###.####}", progress, result);
            });

        }

        private void ProgressCallback1(double result, int progress)
        {
            InternalProgressCallback(lbResult, result, progress);
        }

        private void ProgressCallback2(double result, int progress)
        {
            InternalProgressCallback(lbResult2, result, progress);
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            this.InitProcessors();
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.arrayProcessors.ForEach(processor => processor.Stop());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentStatus = this.arrayProcessors.Any(processor => processor.IsRunning);
            if (currentStatus)
            {
                this.arrayProcessors.ForEach(processor => processor.Stop());
                while(this.arrayProcessors.Any(processor => processor.IsRunning))
                {
                    Thread.Sleep(10);
                }

                btnRunner.Text = "Start all";
            } else
            {
                btnRunner.Text = "Stop all";
                this.arrayProcessors.ForEach(processor => processor.Run());
            }
            
        }

    }
}
