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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtDestination = new TextBox();
            dtpDepartureDate = new DateTimePicker();
            nudNights = new NumericUpDown();
            nudPricePerTour = new NumericUpDown();
            nudPeopleCount = new NumericUpDown();
            nudAdditionalFees = new NumericUpDown();
            txtCount = new TextBox();
            chkWifi = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudNights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPricePerTour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPeopleCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAdditionalFees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Направление";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 53);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 1;
            label2.Text = "Дата вылета";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 84);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 2;
            label3.Text = "Кол-во ночей";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 113);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 3;
            label4.Text = "Стоимость";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 144);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 4;
            label5.Text = "Кол-во людей";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 179);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 5;
            label6.Text = "Доплаты";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 217);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 6;
            label7.Text = "Общая цена";
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(99, 18);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(136, 23);
            txtDestination.TabIndex = 7;
            // 
            // dtpDepartureDate
            // 
            dtpDepartureDate.Location = new Point(99, 51);
            dtpDepartureDate.Name = "dtpDepartureDate";
            dtpDepartureDate.Size = new Size(136, 23);
            dtpDepartureDate.TabIndex = 8;
            // 
            // nudNights
            // 
            nudNights.Location = new Point(99, 82);
            nudNights.Name = "nudNights";
            nudNights.Size = new Size(136, 23);
            nudNights.TabIndex = 9;
            // 
            // nudPricePerTour
            // 
            nudPricePerTour.Location = new Point(99, 113);
            nudPricePerTour.Name = "nudPricePerTour";
            nudPricePerTour.Size = new Size(136, 23);
            nudPricePerTour.TabIndex = 10;
            nudPricePerTour.ValueChanged += UpdateData;
            // 
            // nudPeopleCount
            // 
            nudPeopleCount.Location = new Point(99, 146);
            nudPeopleCount.Name = "nudPeopleCount";
            nudPeopleCount.Size = new Size(136, 23);
            nudPeopleCount.TabIndex = 11;
            nudPeopleCount.ValueChanged += UpdateData;
            // 
            // nudAdditionalFees
            // 
            nudAdditionalFees.Location = new Point(99, 179);
            nudAdditionalFees.Name = "nudAdditionalFees";
            nudAdditionalFees.Size = new Size(136, 23);
            nudAdditionalFees.TabIndex = 12;
            nudAdditionalFees.ValueChanged += UpdateData;
            // 
            // txtCount
            // 
            txtCount.Enabled = false;
            txtCount.Location = new Point(99, 214);
            txtCount.Name = "txtCount";
            txtCount.ReadOnly = true;
            txtCount.Size = new Size(136, 23);
            txtCount.TabIndex = 13;
            // 
            // chkWifi
            // 
            chkWifi.AutoSize = true;
            chkWifi.Location = new Point(16, 244);
            chkWifi.Name = "chkWifi";
            chkWifi.Size = new Size(134, 19);
            chkWifi.TabIndex = 14;
            chkWifi.Text = "Наличие интернета";
            chkWifi.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(23, 269);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "ОК";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(151, 269);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 16;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // EditTourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 308);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chkWifi);
            Controls.Add(txtCount);
            Controls.Add(nudAdditionalFees);
            Controls.Add(nudPeopleCount);
            Controls.Add(nudPricePerTour);
            Controls.Add(nudNights);
            Controls.Add(dtpDepartureDate);
            Controls.Add(txtDestination);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(274, 347);
            MinimumSize = new Size(274, 347);
            Name = "EditTourForm";
            Text = "EditTourForm";
            ((System.ComponentModel.ISupportInitialize)nudNights).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPricePerTour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPeopleCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAdditionalFees).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtDestination;
        private DateTimePicker dtpDepartureDate;
        private NumericUpDown nudNights;
        private NumericUpDown nudPricePerTour;
        private NumericUpDown nudPeopleCount;
        private NumericUpDown nudAdditionalFees;
        private TextBox txtCount;
        private CheckBox chkWifi;
        private Button button1;
        private Button button2;
        private ErrorProvider errorProvider1;
    }
}