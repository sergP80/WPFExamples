namespace WinFormThreading1
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.btnRunner = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbResult2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnRunner
            // 
            this.btnRunner.Location = new System.Drawing.Point(30, 283);
            this.btnRunner.Name = "btnRunner";
            this.btnRunner.Size = new System.Drawing.Size(119, 35);
            this.btnRunner.TabIndex = 0;
            this.btnRunner.Text = "Start all";
            this.btnRunner.UseVisualStyleBackColor = true;
            this.btnRunner.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(27, 32);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 17);
            this.lbTime.TabIndex = 2;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(12, 65);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(21, 17);
            this.lbResult.TabIndex = 3;
            this.lbResult.Text = "r1";
            // 
            // lbResult2
            // 
            this.lbResult2.AutoSize = true;
            this.lbResult2.Location = new System.Drawing.Point(12, 116);
            this.lbResult2.Name = "lbResult2";
            this.lbResult2.Size = new System.Drawing.Size(21, 17);
            this.lbResult2.TabIndex = 4;
            this.lbResult2.Text = "r2";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(207, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(184, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 100;
            // 
            // button1
            // 
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(407, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 31);
            this.button1.TabIndex = 7;
            this.button1.Tag = "0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Go.png");
            this.imageList1.Images.SetKeyName(1, "Close.png");
            // 
            // button2
            // 
            this.button2.ImageIndex = 0;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(407, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 31);
            this.button2.TabIndex = 9;
            this.button2.Tag = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(207, 110);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(184, 23);
            this.progressBar2.TabIndex = 8;
            this.progressBar2.Value = 100;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 373);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbResult2);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btnRunner);
            this.Name = "fmMain";
            this.Text = "Parallel calc";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunner;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbResult2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar2;
    }
}

