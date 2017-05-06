using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            raGridView1.Rows.Add();
            rbGridView1.Rows.Add();
        }

        SourceManager sourceManager = new SourceManager();
        Executor executor = new Executor();
        

        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*|lst files (*.LST)|*.LST";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                List<string> rows = new List<string>();
                while (!sr.EndOfStream)
                {
                    rows.Add(sr.ReadLine());
                }
                sourceManager.ResetSource();
                sourceManager.FillSource(rows);
                sr.Close();
                executor.SetIntArg(sourceManager.GetSingleArg1(4));
                printSource(sourceManager.GetArgs1(), sourceManager.GetSourceComplete());
            }
        }

        private void dokuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btOneStep_Click(object sender, EventArgs e)
        {
            //executor.Execute(0x0733);
            executor.Execute(sourceManager.GetSingleArg1(executor.GetPc()));
            
        }

        private void btRun_Click(object sender, EventArgs e)
        {

        }

        void printSource(List<int> arg1, List<string> sourceComplete)
        {
            argumentListBox1.Items.Clear();
            completeListBox1.Items.Clear();
            foreach (int arg in arg1)
            {
                argumentListBox1.Items.Add(arg.ToString("X4"));
            }

            foreach (string line in sourceComplete)
            {
                completeListBox1.Items.Add(line);
            }
        }
    }
}
