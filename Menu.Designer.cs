namespace TestGameCS
{
    partial class Menu
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
            button5 = new Button();
            button6 = new Button();
            file_box = new TextBox();
            button1 = new Button();
            consoleBox = new TextBox();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(298, 133);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 5;
            button5.Text = "Browse";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Broswe_File;
            // 
            // button6
            // 
            button6.Location = new Point(416, 59);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 7;
            button6.Text = "Start";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Launch_Game;
            // 
            // file_box
            // 
            file_box.Font = new Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point);
            file_box.Location = new Point(416, 135);
            file_box.Name = "file_box";
            file_box.ReadOnly = true;
            file_box.Size = new Size(150, 32);
            file_box.TabIndex = 8;
            file_box.Text = "None";
            // 
            // button1
            // 
            button1.Location = new Point(260, 59);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "Make";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnMake;
            // 
            // consoleBox
            // 
            consoleBox.Dock = DockStyle.Bottom;
            consoleBox.Location = new Point(0, 275);
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.Size = new Size(800, 175);
            consoleBox.TabIndex = 10;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(consoleBox);
            Controls.Add(button1);
            Controls.Add(file_box);
            Controls.Add(button6);
            Controls.Add(button5);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button5;
        private Button button6;
        public TextBox file_box;
        private Button button1;
        public TextBox consoleBox;
    }
}