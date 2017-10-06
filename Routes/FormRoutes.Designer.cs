namespace Routes
{
    partial class FormRoutes
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
            this.openSchDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttOpenSch = new System.Windows.Forms.Button();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStart = new System.Windows.Forms.ComboBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.comboBoxFinish = new System.Windows.Forms.ComboBox();
            this.labelFinish = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.groupBoxProp = new System.Windows.Forms.GroupBox();
            this.listBoxFast = new System.Windows.Forms.ListBox();
            this.listBoxCheap = new System.Windows.Forms.ListBox();
            this.labelFastRoute = new System.Windows.Forms.Label();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.labelCheapRoute = new System.Windows.Forms.Label();
            this.groupBoxProp.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // openSchDialog
            // 
            this.openSchDialog.FileName = "schedule.txt";
            // 
            // buttOpenSch
            // 
            this.buttOpenSch.Location = new System.Drawing.Point(12, 12);
            this.buttOpenSch.Name = "buttOpenSch";
            this.buttOpenSch.Size = new System.Drawing.Size(172, 29);
            this.buttOpenSch.TabIndex = 0;
            this.buttOpenSch.Text = "&Open schedule file";
            this.buttOpenSch.UseVisualStyleBackColor = true;
            this.buttOpenSch.Click += new System.EventHandler(this.buttOpenSch_Click);
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "HH:mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(89, 66);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(76, 22);
            this.startTimePicker.TabIndex = 1;
            this.startTimePicker.Value = new System.DateTime(2017, 10, 5, 12, 0, 0, 0);
            // 
            // comboBoxStart
            // 
            this.comboBoxStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStart.Location = new System.Drawing.Point(89, 15);
            this.comboBoxStart.Name = "comboBoxStart";
            this.comboBoxStart.Size = new System.Drawing.Size(76, 24);
            this.comboBoxStart.TabIndex = 2;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(6, 18);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(42, 17);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "Start:";
            // 
            // comboBoxFinish
            // 
            this.comboBoxFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFinish.FormattingEnabled = true;
            this.comboBoxFinish.Location = new System.Drawing.Point(89, 41);
            this.comboBoxFinish.Name = "comboBoxFinish";
            this.comboBoxFinish.Size = new System.Drawing.Size(76, 24);
            this.comboBoxFinish.TabIndex = 2;
            // 
            // labelFinish
            // 
            this.labelFinish.AutoSize = true;
            this.labelFinish.Location = new System.Drawing.Point(6, 44);
            this.labelFinish.Name = "labelFinish";
            this.labelFinish.Size = new System.Drawing.Size(49, 17);
            this.labelFinish.TabIndex = 4;
            this.labelFinish.Text = "Finish:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(6, 71);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(72, 17);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Start time:";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(6, 94);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(159, 28);
            this.buttonCalculate.TabIndex = 6;
            this.buttonCalculate.Text = "&Get routes";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // groupBoxProp
            // 
            this.groupBoxProp.Controls.Add(this.labelStart);
            this.groupBoxProp.Controls.Add(this.buttonCalculate);
            this.groupBoxProp.Controls.Add(this.startTimePicker);
            this.groupBoxProp.Controls.Add(this.labelTime);
            this.groupBoxProp.Controls.Add(this.comboBoxStart);
            this.groupBoxProp.Controls.Add(this.labelFinish);
            this.groupBoxProp.Controls.Add(this.comboBoxFinish);
            this.groupBoxProp.Enabled = false;
            this.groupBoxProp.Location = new System.Drawing.Point(12, 47);
            this.groupBoxProp.Name = "groupBoxProp";
            this.groupBoxProp.Size = new System.Drawing.Size(172, 128);
            this.groupBoxProp.TabIndex = 7;
            this.groupBoxProp.TabStop = false;
            // 
            // listBoxFast
            // 
            this.listBoxFast.FormattingEnabled = true;
            this.listBoxFast.HorizontalScrollbar = true;
            this.listBoxFast.IntegralHeight = false;
            this.listBoxFast.ItemHeight = 16;
            this.listBoxFast.Location = new System.Drawing.Point(6, 43);
            this.listBoxFast.Name = "listBoxFast";
            this.listBoxFast.Size = new System.Drawing.Size(231, 114);
            this.listBoxFast.TabIndex = 8;
            // 
            // listBoxCheap
            // 
            this.listBoxCheap.FormattingEnabled = true;
            this.listBoxCheap.HorizontalScrollbar = true;
            this.listBoxCheap.IntegralHeight = false;
            this.listBoxCheap.ItemHeight = 16;
            this.listBoxCheap.Location = new System.Drawing.Point(244, 43);
            this.listBoxCheap.Name = "listBoxCheap";
            this.listBoxCheap.Size = new System.Drawing.Size(231, 114);
            this.listBoxCheap.TabIndex = 9;
            // 
            // labelFastRoute
            // 
            this.labelFastRoute.AutoSize = true;
            this.labelFastRoute.Location = new System.Drawing.Point(6, 18);
            this.labelFastRoute.Name = "labelFastRoute";
            this.labelFastRoute.Size = new System.Drawing.Size(35, 17);
            this.labelFastRoute.TabIndex = 10;
            this.labelFastRoute.Text = "Fast";
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.labelCheapRoute);
            this.groupBoxResults.Controls.Add(this.listBoxFast);
            this.groupBoxResults.Controls.Add(this.labelFastRoute);
            this.groupBoxResults.Controls.Add(this.listBoxCheap);
            this.groupBoxResults.Location = new System.Drawing.Point(190, 12);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(481, 163);
            this.groupBoxResults.TabIndex = 11;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Routes:";
            // 
            // labelCheapRoute
            // 
            this.labelCheapRoute.AutoSize = true;
            this.labelCheapRoute.Location = new System.Drawing.Point(241, 18);
            this.labelCheapRoute.Name = "labelCheapRoute";
            this.labelCheapRoute.Size = new System.Drawing.Size(49, 17);
            this.labelCheapRoute.TabIndex = 11;
            this.labelCheapRoute.Text = "Cheap";
            // 
            // FormRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 178);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxProp);
            this.Controls.Add(this.buttOpenSch);
            this.MinimumSize = new System.Drawing.Size(500, 225);
            this.Name = "FormRoutes";
            this.Text = "Routes";
            this.Shown += new System.EventHandler(this.FormRoutes_Shown);
            this.Resize += new System.EventHandler(this.FormRoutes_Resize);
            this.groupBoxProp.ResumeLayout(false);
            this.groupBoxProp.PerformLayout();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openSchDialog;
        private System.Windows.Forms.Button buttOpenSch;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.ComboBox comboBoxStart;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.ComboBox comboBoxFinish;
        private System.Windows.Forms.Label labelFinish;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.GroupBox groupBoxProp;
        private System.Windows.Forms.ListBox listBoxFast;
        private System.Windows.Forms.ListBox listBoxCheap;
        private System.Windows.Forms.Label labelFastRoute;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label labelCheapRoute;
    }
}

