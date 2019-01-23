namespace GeneticAlgorithmForm
{
    partial class Form1
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
            this.mstrength = new System.Windows.Forms.NumericUpDown();
            this.btnclearconsole = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.consolebox = new System.Windows.Forms.RichTextBox();
            this.datasets = new System.Windows.Forms.ComboBox();
            this.btnresetalgo = new System.Windows.Forms.Button();
            this.mrate = new System.Windows.Forms.NumericUpDown();
            this.mselectionup = new System.Windows.Forms.NumericUpDown();
            this.popCount = new System.Windows.Forms.NumericUpDown();
            this.mselectiondown = new System.Windows.Forms.NumericUpDown();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.iterationCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.IterationNumber = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBestThisGen = new System.Windows.Forms.Label();
            this.lblBestBagEver = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mstrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mselectionup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mselectiondown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationCount)).BeginInit();
            this.SuspendLayout();
            // 
            // mstrength
            // 
            this.mstrength.DecimalPlaces = 4;
            this.mstrength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.mstrength.Location = new System.Drawing.Point(112, 448);
            this.mstrength.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mstrength.Name = "mstrength";
            this.mstrength.Size = new System.Drawing.Size(120, 20);
            this.mstrength.TabIndex = 36;
            this.mstrength.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            // 
            // btnclearconsole
            // 
            this.btnclearconsole.Location = new System.Drawing.Point(320, 336);
            this.btnclearconsole.Name = "btnclearconsole";
            this.btnclearconsole.Size = new System.Drawing.Size(96, 40);
            this.btnclearconsole.TabIndex = 35;
            this.btnclearconsole.Text = "Clear Console";
            this.btnclearconsole.UseVisualStyleBackColor = true;
            this.btnclearconsole.Click += new System.EventHandler(this.btnclearconsole_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Mutation Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Mutation Strength";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Population Count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Lower Selection ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Upper Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Dataset";
            // 
            // consolebox
            // 
            this.consolebox.Location = new System.Drawing.Point(16, 24);
            this.consolebox.Name = "consolebox";
            this.consolebox.ReadOnly = true;
            this.consolebox.Size = new System.Drawing.Size(512, 304);
            this.consolebox.TabIndex = 27;
            this.consolebox.Text = "";
            // 
            // datasets
            // 
            this.datasets.FormattingEnabled = true;
            this.datasets.Items.AddRange(new object[] {
            "DATA\\\\Instance_100_995.txt",
            "DATA\\\\Instance_100_997.txt",
            "DATA\\\\Instance_200_1008.txt",
            "DATA\\\\Instance_24_6404180.txt"});
            this.datasets.Location = new System.Drawing.Point(400, 384);
            this.datasets.Name = "datasets";
            this.datasets.Size = new System.Drawing.Size(121, 21);
            this.datasets.TabIndex = 26;
            this.datasets.Text = "DATA\\\\Instance_100_995.txt";
            // 
            // btnresetalgo
            // 
            this.btnresetalgo.Enabled = false;
            this.btnresetalgo.Location = new System.Drawing.Point(424, 336);
            this.btnresetalgo.Name = "btnresetalgo";
            this.btnresetalgo.Size = new System.Drawing.Size(96, 40);
            this.btnresetalgo.TabIndex = 25;
            this.btnresetalgo.Text = "Reset";
            this.btnresetalgo.UseVisualStyleBackColor = true;
            this.btnresetalgo.Click += new System.EventHandler(this.btnresetalgo_Click);
            // 
            // mrate
            // 
            this.mrate.DecimalPlaces = 4;
            this.mrate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.mrate.Location = new System.Drawing.Point(112, 416);
            this.mrate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mrate.Name = "mrate";
            this.mrate.Size = new System.Drawing.Size(120, 20);
            this.mrate.TabIndex = 24;
            this.mrate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // mselectionup
            // 
            this.mselectionup.Location = new System.Drawing.Point(400, 416);
            this.mselectionup.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.mselectionup.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mselectionup.Name = "mselectionup";
            this.mselectionup.Size = new System.Drawing.Size(120, 20);
            this.mselectionup.TabIndex = 23;
            this.mselectionup.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // popCount
            // 
            this.popCount.Location = new System.Drawing.Point(112, 384);
            this.popCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.popCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.popCount.Name = "popCount";
            this.popCount.Size = new System.Drawing.Size(120, 20);
            this.popCount.TabIndex = 22;
            this.popCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // mselectiondown
            // 
            this.mselectiondown.Location = new System.Drawing.Point(400, 448);
            this.mselectiondown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mselectiondown.Name = "mselectiondown";
            this.mselectiondown.Size = new System.Drawing.Size(120, 20);
            this.mselectiondown.TabIndex = 21;
            this.mselectiondown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnStep
            // 
            this.btnStep.Enabled = false;
            this.btnStep.Location = new System.Drawing.Point(216, 336);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(96, 40);
            this.btnStep.TabIndex = 20;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(16, 336);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(112, 40);
            this.btnstart.TabIndex = 19;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // iterationCount
            // 
            this.iterationCount.Location = new System.Drawing.Point(144, 352);
            this.iterationCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.iterationCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationCount.Name = "iterationCount";
            this.iterationCount.Size = new System.Drawing.Size(61, 20);
            this.iterationCount.TabIndex = 37;
            this.iterationCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Iteration Count:";
            // 
            // IterationNumber
            // 
            this.IterationNumber.AutoSize = true;
            this.IterationNumber.Location = new System.Drawing.Point(72, 8);
            this.IterationNumber.Name = "IterationNumber";
            this.IterationNumber.Size = new System.Drawing.Size(13, 13);
            this.IterationNumber.TabIndex = 39;
            this.IterationNumber.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Best This Generation:";
            // 
            // lblBestThisGen
            // 
            this.lblBestThisGen.AutoSize = true;
            this.lblBestThisGen.Location = new System.Drawing.Point(248, 8);
            this.lblBestThisGen.Name = "lblBestThisGen";
            this.lblBestThisGen.Size = new System.Drawing.Size(0, 13);
            this.lblBestThisGen.TabIndex = 41;
            // 
            // lblBestBagEver
            // 
            this.lblBestBagEver.AutoSize = true;
            this.lblBestBagEver.Location = new System.Drawing.Point(432, 8);
            this.lblBestBagEver.Name = "lblBestBagEver";
            this.lblBestBagEver.Size = new System.Drawing.Size(0, 13);
            this.lblBestBagEver.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Best Bag so far:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Iteration:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 487);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblBestBagEver);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblBestThisGen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.IterationNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.iterationCount);
            this.Controls.Add(this.mstrength);
            this.Controls.Add(this.btnclearconsole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.consolebox);
            this.Controls.Add(this.datasets);
            this.Controls.Add(this.btnresetalgo);
            this.Controls.Add(this.mrate);
            this.Controls.Add(this.mselectionup);
            this.Controls.Add(this.popCount);
            this.Controls.Add(this.mselectiondown);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnstart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mstrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mselectionup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mselectiondown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown mstrength;
        private System.Windows.Forms.Button btnclearconsole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox consolebox;
        private System.Windows.Forms.ComboBox datasets;
        private System.Windows.Forms.Button btnresetalgo;
        private System.Windows.Forms.NumericUpDown mrate;
        private System.Windows.Forms.NumericUpDown mselectionup;
        private System.Windows.Forms.NumericUpDown popCount;
        private System.Windows.Forms.NumericUpDown mselectiondown;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.NumericUpDown iterationCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label IterationNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBestThisGen;
        private System.Windows.Forms.Label lblBestBagEver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

