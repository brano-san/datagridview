namespace datagridview.Forms
{
    partial class EditTourForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNights = new System.Windows.Forms.NumericUpDown();
            this.nudPricePerTour = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkWifi = new System.Windows.Forms.CheckBox();
            this.nudAdditionalFees = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nudPeopleCount = new System.Windows.Forms.NumericUpDown();
            this.label7nudPeopleCount = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudNights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdditionalFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeopleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Направление";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(91, 12);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(118, 20);
            this.txtDestination.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата вылета";
            // 
            // dtpDepartureDate
            // 
            this.dtpDepartureDate.Location = new System.Drawing.Point(91, 42);
            this.dtpDepartureDate.Name = "dtpDepartureDate";
            this.dtpDepartureDate.Size = new System.Drawing.Size(118, 20);
            this.dtpDepartureDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кол-во ночей";
            // 
            // nudNights
            // 
            this.nudNights.Location = new System.Drawing.Point(90, 75);
            this.nudNights.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNights.Name = "nudNights";
            this.nudNights.Size = new System.Drawing.Size(120, 20);
            this.nudNights.TabIndex = 5;
            this.nudNights.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPricePerTour
            // 
            this.nudPricePerTour.Location = new System.Drawing.Point(90, 106);
            this.nudPricePerTour.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPricePerTour.Name = "nudPricePerTour";
            this.nudPricePerTour.Size = new System.Drawing.Size(120, 20);
            this.nudPricePerTour.TabIndex = 7;
            this.nudPricePerTour.ValueChanged += new System.EventHandler(this.UpdateData);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Стоимость";
            // 
            // chkWifi
            // 
            this.chkWifi.AutoSize = true;
            this.chkWifi.Location = new System.Drawing.Point(12, 212);
            this.chkWifi.Name = "chkWifi";
            this.chkWifi.Size = new System.Drawing.Size(124, 17);
            this.chkWifi.TabIndex = 9;
            this.chkWifi.Text = "Наличие интернета";
            this.chkWifi.UseVisualStyleBackColor = true;
            // 
            // nudAdditionalFees
            // 
            this.nudAdditionalFees.Location = new System.Drawing.Point(90, 160);
            this.nudAdditionalFees.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAdditionalFees.Name = "nudAdditionalFees";
            this.nudAdditionalFees.Size = new System.Drawing.Size(120, 20);
            this.nudAdditionalFees.TabIndex = 11;
            this.nudAdditionalFees.ValueChanged += new System.EventHandler(this.UpdateData);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Доплаты";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(90, 186);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(118, 20);
            this.txtCount.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Общая цена";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(118, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // nudPeopleCount
            // 
            this.nudPeopleCount.Location = new System.Drawing.Point(90, 132);
            this.nudPeopleCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPeopleCount.Name = "nudPeopleCount";
            this.nudPeopleCount.Size = new System.Drawing.Size(120, 20);
            this.nudPeopleCount.TabIndex = 17;
            this.nudPeopleCount.ValueChanged += new System.EventHandler(this.UpdateData);
            // 
            // label7nudPeopleCount
            // 
            this.label7nudPeopleCount.AutoSize = true;
            this.label7nudPeopleCount.Location = new System.Drawing.Point(9, 134);
            this.label7nudPeopleCount.Name = "label7nudPeopleCount";
            this.label7nudPeopleCount.Size = new System.Drawing.Size(76, 13);
            this.label7nudPeopleCount.TabIndex = 16;
            this.label7nudPeopleCount.Text = "Кол-во людей";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 277);
            this.Controls.Add(this.nudPeopleCount);
            this.Controls.Add(this.label7nudPeopleCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudAdditionalFees);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkWifi);
            this.Controls.Add(this.nudPricePerTour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudNights);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDepartureDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(260, 316);
            this.MinimumSize = new System.Drawing.Size(260, 316);
            this.Name = "EditTourForm";
            this.Text = "EditTourForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudNights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdditionalFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeopleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDepartureDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNights;
        private System.Windows.Forms.NumericUpDown nudPricePerTour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkWifi;
        private System.Windows.Forms.NumericUpDown nudAdditionalFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudPeopleCount;
        private System.Windows.Forms.Label label7nudPeopleCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
