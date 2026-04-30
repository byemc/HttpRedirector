namespace HttpRedirector
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            listView1 = new ListView();
            browserIconList = new ImageList(components);
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            quitButton = new Button();
            settingsButton = new Button();
            browserOpenTimer = new System.Windows.Forms.Timer(components);
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(progressBar1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(listView1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(434, 232);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 0;
            label1.Text = "Opening about:blank";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 15);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 5;
            label2.Text = "in Infinity seconds...";
            // 
            // progressBar1
            // 
            progressBar1.Enabled = false;
            progressBar1.Location = new Point(4, 33);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(427, 27);
            progressBar1.TabIndex = 1;
            progressBar1.Value = 50;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 63);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 6;
            label3.Text = "Using IEXPLORE.exe";
            // 
            // listView1
            // 
            listView1.LargeImageList = browserIconList;
            listView1.Location = new Point(4, 81);
            listView1.Margin = new Padding(4, 3, 4, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(427, 149);
            listView1.SmallImageList = browserIconList;
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // browserIconList
            // 
            browserIconList.ColorDepth = ColorDepth.Depth32Bit;
            browserIconList.ImageSize = new Size(32, 32);
            browserIconList.TransparentColor = Color.Transparent;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(quitButton);
            flowLayoutPanel2.Controls.Add(settingsButton);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(0, 232);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(434, 29);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(356, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "&Open";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // quitButton
            // 
            quitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            quitButton.Location = new Point(280, 3);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(70, 23);
            quitButton.TabIndex = 7;
            quitButton.Text = "&Cancel";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(199, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(75, 23);
            settingsButton.TabIndex = 8;
            settingsButton.Text = "&Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // browserOpenTimer
            // 
            browserOpenTimer.Interval = 50;
            browserOpenTimer.Tick += browserOpenTimer_Tick;
            // 
            // Form1
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            CancelButton = quitButton;
            ClientSize = new Size(434, 261);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(450, 1000);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HTTP Redirector";
            TopMost = true;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList browserIconList;
        private System.Windows.Forms.Timer browserOpenTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Button quitButton;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button settingsButton;
    }
}

