namespace HttpRedirector
{
    partial class SettingsForm
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
            Label label1;
            browserBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBox1 = new ComboBox();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            checkBox1 = new CheckBox();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            panel1 = new Panel();
            cancelButton = new Button();
            saveButton = new Button();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)browserBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 3;
            label1.Text = "Default browser";
            // 
            // browserBindingSource
            // 
            browserBindingSource.DataSource = typeof(Browser);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(comboBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(400, 64);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DataSource = browserBindingSource;
            comboBox1.DisplayMember = "Name";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(103, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(294, 23);
            comboBox1.TabIndex = 2;
            comboBox1.ValueMember = "Id";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 31);
            label2.Name = "label2";
            label2.Size = new Size(84, 30);
            label2.TabIndex = 4;
            label2.Text = "Automatically open";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(checkBox1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(numericUpDown1);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Location = new Point(103, 32);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(294, 29);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(68, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(77, 7);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 1;
            label3.Text = "after...";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Left;
            numericUpDown1.Location = new Point(123, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(45, 23);
            numericUpDown1.TabIndex = 2;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(174, 7);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 3;
            label4.Text = "seconds.";
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(cancelButton);
            panel1.Controls.Add(saveButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 151);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 30);
            panel1.TabIndex = 1;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(241, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "&Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(322, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "&Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(3, 130);
            label5.Name = "label5";
            label5.Size = new Size(244, 15);
            label5.TabIndex = 2;
            label5.Text = "Set HTTP Redirector as your default browser?";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Enabled = false;
            button1.Location = new Point(307, 126);
            button1.Name = "button1";
            button1.Size = new Size(90, 23);
            button1.TabIndex = 3;
            button1.Text = "Set as default";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(3, 108);
            label6.Name = "label6";
            label6.Size = new Size(378, 15);
            label6.TabIndex = 4;
            label6.Text = "Unable to determine if HTTP Redirector is your default system browser";
            // 
            // SettingsForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = cancelButton;
            ClientSize = new Size(400, 181);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)browserBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.BindingSource browserBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private Label label5;
        private Button button1;
        private Label label6;
    }
}