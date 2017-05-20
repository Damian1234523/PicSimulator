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
            this.components = new System.ComponentModel.Container();
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
            this.statusGridView = new System.Windows.Forms.DataGridView();
            this.C = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DC = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Z = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PDneg = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TOneg = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RP0 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RP1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IRP = new System.Windows.Forms.DataGridViewButtonColumn();
            this.raGridView1 = new System.Windows.Forms.DataGridView();
            this.A0 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.A7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rbGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerRun = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbGridView1)).BeginInit();
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
            this.completeListBox1.Size = new System.Drawing.Size(615, 459);
            this.completeListBox1.TabIndex = 3;
            this.completeListBox1.SelectedIndexChanged += new System.EventHandler(this.completeListBox1_SelectedIndexChanged);
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(996, 28);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 4;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btOneStep
            // 
            this.btOneStep.Location = new System.Drawing.Point(915, 28);
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
            // statusGridView
            // 
            this.statusGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.statusGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statusGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C,
            this.DC,
            this.Z,
            this.PDneg,
            this.TOneg,
            this.RP0,
            this.RP1,
            this.IRP});
            this.statusGridView.Location = new System.Drawing.Point(871, 68);
            this.statusGridView.Name = "statusGridView";
            this.statusGridView.Size = new System.Drawing.Size(330, 77);
            this.statusGridView.TabIndex = 19;
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.Width = 21;
            // 
            // DC
            // 
            this.DC.HeaderText = "DC";
            this.DC.Name = "DC";
            this.DC.Width = 28;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.Width = 21;
            // 
            // PDneg
            // 
            this.PDneg.HeaderText = "PDneg";
            this.PDneg.Name = "PDneg";
            this.PDneg.Width = 46;
            // 
            // TOneg
            // 
            this.TOneg.HeaderText = "TOneg";
            this.TOneg.Name = "TOneg";
            this.TOneg.Width = 46;
            // 
            // RP0
            // 
            this.RP0.HeaderText = "RP0";
            this.RP0.Name = "RP0";
            this.RP0.Width = 34;
            // 
            // RP1
            // 
            this.RP1.HeaderText = "RP1";
            this.RP1.Name = "RP1";
            this.RP1.Width = 34;
            // 
            // IRP
            // 
            this.IRP.HeaderText = "IRP";
            this.IRP.Name = "IRP";
            this.IRP.Width = 31;
            // 
            // raGridView1
            // 
            this.raGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.raGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.raGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A0,
            this.A1,
            this.A2,
            this.A3,
            this.A4,
            this.A5,
            this.A6,
            this.A7});
            this.raGridView1.Location = new System.Drawing.Point(871, 151);
            this.raGridView1.Name = "raGridView1";
            this.raGridView1.Size = new System.Drawing.Size(252, 94);
            this.raGridView1.TabIndex = 20;
            // 
            // A0
            // 
            this.A0.HeaderText = "A0";
            this.A0.Name = "A0";
            this.A0.Width = 26;
            // 
            // A1
            // 
            this.A1.HeaderText = "A1";
            this.A1.Name = "A1";
            this.A1.Width = 26;
            // 
            // A2
            // 
            this.A2.HeaderText = "A2";
            this.A2.Name = "A2";
            this.A2.Width = 26;
            // 
            // A3
            // 
            this.A3.HeaderText = "A3";
            this.A3.Name = "A3";
            this.A3.Width = 26;
            // 
            // A4
            // 
            this.A4.HeaderText = "A4";
            this.A4.Name = "A4";
            this.A4.Width = 26;
            // 
            // A5
            // 
            this.A5.HeaderText = "A5";
            this.A5.Name = "A5";
            this.A5.Width = 26;
            // 
            // A6
            // 
            this.A6.HeaderText = "A6";
            this.A6.Name = "A6";
            this.A6.Width = 26;
            // 
            // A7
            // 
            this.A7.HeaderText = "A7";
            this.A7.Name = "A7";
            this.A7.Width = 26;
            // 
            // rbGridView1
            // 
            this.rbGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.rbGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rbGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn8,
            this.dataGridViewButtonColumn7,
            this.dataGridViewButtonColumn6,
            this.dataGridViewButtonColumn5,
            this.dataGridViewButtonColumn4,
            this.dataGridViewButtonColumn3,
            this.dataGridViewButtonColumn2,
            this.dataGridViewButtonColumn1});
            this.rbGridView1.Location = new System.Drawing.Point(871, 251);
            this.rbGridView1.Name = "rbGridView1";
            this.rbGridView1.Size = new System.Drawing.Size(252, 103);
            this.rbGridView1.TabIndex = 21;
            // 
            // dataGridViewButtonColumn8
            // 
            this.dataGridViewButtonColumn8.HeaderText = "B0";
            this.dataGridViewButtonColumn8.Name = "dataGridViewButtonColumn8";
            this.dataGridViewButtonColumn8.Width = 26;
            // 
            // dataGridViewButtonColumn7
            // 
            this.dataGridViewButtonColumn7.HeaderText = "B1";
            this.dataGridViewButtonColumn7.Name = "dataGridViewButtonColumn7";
            this.dataGridViewButtonColumn7.Width = 26;
            // 
            // dataGridViewButtonColumn6
            // 
            this.dataGridViewButtonColumn6.HeaderText = "B2";
            this.dataGridViewButtonColumn6.Name = "dataGridViewButtonColumn6";
            this.dataGridViewButtonColumn6.Width = 26;
            // 
            // dataGridViewButtonColumn5
            // 
            this.dataGridViewButtonColumn5.HeaderText = "B3";
            this.dataGridViewButtonColumn5.Name = "dataGridViewButtonColumn5";
            this.dataGridViewButtonColumn5.Width = 26;
            // 
            // dataGridViewButtonColumn4
            // 
            this.dataGridViewButtonColumn4.HeaderText = "B4";
            this.dataGridViewButtonColumn4.Name = "dataGridViewButtonColumn4";
            this.dataGridViewButtonColumn4.Width = 26;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "B5";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Width = 26;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "B6";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Width = 26;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "B7";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Width = 26;
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(1078, 28);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(76, 20);
            this.tbFrequency.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1161, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "cps";
            // 
            // timerRun
            // 
            this.timerRun.Tick += new System.EventHandler(this.timerRun_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 563);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFrequency);
            this.Controls.Add(this.rbGridView1);
            this.Controls.Add(this.raGridView1);
            this.Controls.Add(this.statusGridView);
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
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbGridView1)).EndInit();
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
        public System.Windows.Forms.DataGridView statusGridView;
        public System.Windows.Forms.DataGridView raGridView1;
        public System.Windows.Forms.DataGridView rbGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn C;
        private System.Windows.Forms.DataGridViewButtonColumn DC;
        private System.Windows.Forms.DataGridViewButtonColumn Z;
        private System.Windows.Forms.DataGridViewButtonColumn PDneg;
        private System.Windows.Forms.DataGridViewButtonColumn TOneg;
        private System.Windows.Forms.DataGridViewButtonColumn RP0;
        private System.Windows.Forms.DataGridViewButtonColumn RP1;
        private System.Windows.Forms.DataGridViewButtonColumn IRP;
        private System.Windows.Forms.DataGridViewButtonColumn A0;
        private System.Windows.Forms.DataGridViewButtonColumn A1;
        private System.Windows.Forms.DataGridViewButtonColumn A2;
        private System.Windows.Forms.DataGridViewButtonColumn A3;
        private System.Windows.Forms.DataGridViewButtonColumn A4;
        private System.Windows.Forms.DataGridViewButtonColumn A5;
        private System.Windows.Forms.DataGridViewButtonColumn A6;
        private System.Windows.Forms.DataGridViewButtonColumn A7;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerRun;
    }
}

