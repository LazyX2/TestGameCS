namespace TestGameCS
{
    partial class LevelEditor
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
            timer1 = new System.Windows.Forms.Timer(components);
            menu_strip = new MenuStrip();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            screen = new PictureBox();
            menu_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)screen).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += OnUpdate;
            // 
            // menu_strip
            // 
            menu_strip.ImageScalingSize = new Size(24, 24);
            menu_strip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            menu_strip.Location = new Point(0, 0);
            menu_strip.Name = "menu_strip";
            menu_strip.Size = new Size(800, 33);
            menu_strip.TabIndex = 1;
            menu_strip.Text = "menu_strip";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem3 });
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(54, 29);
            toolStripMenuItem4.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(153, 34);
            toolStripMenuItem1.Text = "Save";
            toolStripMenuItem1.Click += SaveLevel;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(153, 34);
            toolStripMenuItem3.Text = "Load";
            toolStripMenuItem3.Click += LoadLevel;
            // 
            // screen
            // 
            screen.Dock = DockStyle.Fill;
            screen.Location = new Point(0, 33);
            screen.Name = "screen";
            screen.Size = new Size(800, 417);
            screen.TabIndex = 2;
            screen.TabStop = false;
            screen.Paint += OnRender;
            // 
            // LevelEditor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(screen);
            Controls.Add(menu_strip);
            MainMenuStrip = menu_strip;
            Name = "LevelEditor";
            Text = "LevelEditor";
            FormClosed += OnClose;
            Load += LevelEditor_Load;
            menu_strip.ResumeLayout(false);
            menu_strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)screen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private MenuStrip menu_strip;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private PictureBox screen;
    }
}