namespace HttpRedirector
{
    partial class UpdateBrowserForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            currentTextBox = new TextBox();
            replacementTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            currentVersionBox = new TextBox();
            replacementVersion = new TextBox();
            label5 = new Label();
            relativeVersion = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 6);
            label1.Name = "label1";
            label1.Size = new Size(320, 30);
            label1.TabIndex = 0;
            label1.Text = "There is another copy of HTTP Redirector set up.\r\nWould you like to use this copy of HTTP Redirector instead?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 42);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 1;
            label2.Text = "Currently installed:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 108);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 2;
            label3.Text = "Would replace with:";
            // 
            // currentTextBox
            // 
            currentTextBox.BackColor = SystemColors.Control;
            currentTextBox.BorderStyle = BorderStyle.FixedSingle;
            currentTextBox.Location = new Point(122, 41);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.ReadOnly = true;
            currentTextBox.Size = new Size(291, 23);
            currentTextBox.TabIndex = 3;
            // 
            // replacementTextBox
            // 
            replacementTextBox.BackColor = SystemColors.Control;
            replacementTextBox.BorderStyle = BorderStyle.FixedSingle;
            replacementTextBox.Location = new Point(122, 106);
            replacementTextBox.Name = "replacementTextBox";
            replacementTextBox.ReadOnly = true;
            replacementTextBox.Size = new Size(291, 23);
            replacementTextBox.TabIndex = 4;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(345, 182);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "&Yes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(264, 182);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "&No";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 72);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 7;
            label4.Text = "Version";
            // 
            // currentVersionBox
            // 
            currentVersionBox.BackColor = SystemColors.Control;
            currentVersionBox.BorderStyle = BorderStyle.FixedSingle;
            currentVersionBox.Location = new Point(122, 70);
            currentVersionBox.Name = "currentVersionBox";
            currentVersionBox.ReadOnly = true;
            currentVersionBox.Size = new Size(291, 23);
            currentVersionBox.TabIndex = 8;
            // 
            // replacementVersion
            // 
            replacementVersion.BackColor = SystemColors.Control;
            replacementVersion.BorderStyle = BorderStyle.FixedSingle;
            replacementVersion.Location = new Point(122, 135);
            replacementVersion.Name = "replacementVersion";
            replacementVersion.ReadOnly = true;
            replacementVersion.Size = new Size(291, 23);
            replacementVersion.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 137);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 9;
            label5.Text = "Version";
            // 
            // relativeVersion
            // 
            relativeVersion.AutoSize = true;
            relativeVersion.Location = new Point(122, 161);
            relativeVersion.Name = "relativeVersion";
            relativeVersion.Size = new Size(202, 15);
            relativeVersion.TabIndex = 11;
            relativeVersion.Text = "This version is {0} the current verison.";
            // 
            // UpdateBrowserForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = button2;
            ClientSize = new Size(432, 217);
            Controls.Add(relativeVersion);
            Controls.Add(replacementVersion);
            Controls.Add(label5);
            Controls.Add(currentVersionBox);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(replacementTextBox);
            Controls.Add(currentTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "UpdateBrowserForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update default browser associations?";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox currentTextBox;
        private TextBox replacementTextBox;
        private Button button1;
        private Button button2;
        private Label label4;
        private TextBox currentVersionBox;
        private TextBox replacementVersion;
        private Label label5;
        private Label relativeVersion;
    }
}