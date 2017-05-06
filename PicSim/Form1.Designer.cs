namespace PicSim
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dokuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.argumentListBox1 = new System.Windows.Forms.ListBox();
            this.argumentListBox2 = new System.Windows.Forms.ListBox();
            this.completeListBox1 = new System.Windows.Forms.ListBox();
            this.btRun = new System.Windows.Forms.Button();
            this.btOneStep = new System.Windows.Forms.Button();
            this.lbSource = new System.Windows.Forms.Label();
            this.lbArg1 = new System.Windows.Forms.Label();
            this.lbArg2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1201, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokuToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // dokuToolStripMenuItem
            // 
            this.dokuToolStripMenuItem.Name = "dokuToolStripMenuItem";
            this.dokuToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.dokuToolStripMenuItem.Text = "Doku";
            this.dokuToolStripMenuItem.Click += new System.EventHandler(this.dokuToolStripMenuItem_Click);
            // 
            // argumentListBox1
            // 
            this.argumentListBox1.FormattingEnabled = true;
            this.argumentListBox1.Location = new System.Drawing.Point(13, 68);
            this.argumentListBox1.Name = "argumentListBox1";
            this.argumentListBox1.Size = new System.Drawing.Size(68, 459);
            this.argumentListBox1.TabIndex = 1;
            // 
            // argumentListBox2
            // 
            this.argumentListBox2.FormattingEnabled = true;
            this.argumentListBox2.Location = new System.Drawing.Point(97, 68);
            this.argumentListBox2.Name = "argumentListBox2";
            this.argumentListBox2.Size = new System.Drawing.Size(72, 459);
            this.argumentListBox2.TabIndex = 2;
            // 
            // completeListBox1
            // 
            this.completeListBox1.FormattingEnabled = true;
            this.completeListBox1.Location = new System.Drawing.Point(250, 68);
            this.completeListBox1.Name = "completeListBox1";
            this.completeListBox1.Size = new System.Drawing.Size(682, 459);
            this.completeListBox1.TabIndex = 3;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(1114, 27);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 4;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btOneStep
            // 
            this.btOneStep.Location = new System.Drawing.Point(1033, 28);
            this.btOneStep.Name = "btOneStep";
            this.btOneStep.Size = new System.Drawing.Size(75, 23);
            this.btOneStep.TabIndex = 5;
            this.btOneStep.Text = "One Step";
            this.btOneStep.UseVisualStyleBackColor = true;
            this.btOneStep.Click += new System.EventHandler(this.btOneStep_Click);
            // 
            // lbSource
            // 
            this.lbSource.AutoSize = true;
            this.lbSource.Location = new System.Drawing.Point(247, 48);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(41, 13);
            this.lbSource.TabIndex = 16;
            this.lbSource.Text = "Source";
            // 
            // lbArg1
            // 
            this.lbArg1.AutoSize = true;
            this.lbArg1.Location = new System.Drawing.Point(13, 49);
            this.lbArg1.Name = "lbArg1";
            this.lbArg1.Size = new System.Drawing.Size(29, 13);
            this.lbArg1.TabIndex = 17;
            this.lbArg1.Text = "Arg1";
            // 
            // lbArg2
            // 
            this.lbArg2.AutoSize = true;
            this.lbArg2.Location = new System.Drawing.Point(97, 48);
            this.lbArg2.Name = "lbArg2";
            this.lbArg2.Size = new System.Drawing.Size(29, 13);
            this.lbArg2.TabIndex = 18;
            this.lbArg2.Text = "Arg2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 563);
            this.Controls.Add(this.lbArg2);
            this.Controls.Add(this.lbArg1);
            this.Controls.Add(this.lbSource);
            this.Controls.Add(this.btOneStep);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.completeListBox1);
            this.Controls.Add(this.argumentListBox2);
            this.Controls.Add(this.argumentListBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "PicSim";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dokuToolStripMenuItem;
        private System.Windows.Forms.ListBox argumentListBox1;
        private System.Windows.Forms.ListBox argumentListBox2;
        private System.Windows.Forms.ListBox completeListBox1;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btOneStep;
        private System.Windows.Forms.Label lbSource;
        private System.Windows.Forms.Label lbArg1;
        private System.Windows.Forms.Label lbArg2;
    }
}

