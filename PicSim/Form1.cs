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
            registerGridView1.Rows.Add(254);
            tbFrequency.Text = "1000";
            completeListBox1.MouseDoubleClick += new MouseEventHandler(completeListBox1_DoubleClick);

            completeListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            completeListBox1.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
            Controls.Add(completeListBox1);

            raGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(raGridView1_listener);
            rbGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(rbGridView1_listener);
        }

        

        Timer rTimer = new Timer();
        List<bool> breakpoints = new List<bool>();

        SourceManager sourceManager = new SourceManager();
        Executor executor = new Executor();

        bool breakpointHit = false;

        bool firstRun = true;

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
                executor.Reset();
                sourceManager.ResetSource();
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                List<string> rows = new List<string>();
                while (!sr.EndOfStream)
                {
                    rows.Add(sr.ReadLine());
                }
                
                sourceManager.FillSource(rows);
                sr.Close();
                executor.SetIntArg(sourceManager.GetSingleArg1(4));
                printSource(sourceManager.GetArgs1(), sourceManager.GetSourceComplete());
                
                argumentListBox1.SelectedIndex = 0;
                completeListBox1.SelectedIndex = 0;
                foreach (string item in sourceManager.GetSourceComplete())
                {
                    breakpoints.Add(false);
                }
                firstRun = false;
            }
        }

        private void dokuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Doku abrufen
            
            MessageBox.Show("Existiert noch nicht");
        }

        private void btOneStep_Click(object sender, EventArgs e)
        {
            timerExtClock.Enabled = true;
            step();
            timerExtClock.Enabled = false;

        }

        private void btRun_Click(object sender, EventArgs e)
        {
            
            if (timerRun.Enabled == false)
            {
                double frequency = double.Parse(tbFrequency.Text);

                frequency = (1 / frequency) * 1000;

                //rTimer.Interval=frequency;

                timerRun.Interval = (int)frequency;
                timerRun.Enabled = true;

                int externalClock = int.Parse(tbExtClock.Text);
                timerExtClock.Interval = externalClock;
                timerExtClock.Enabled = true;

                btRun.Text = "Halt stop!";
            }
            else
            {
                timerRun.Enabled = false;
                timerExtClock.Enabled = false;
                btRun.Text = "Run";
            }
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

        void printInfo()
        {
            int s = executor.GetStatus();
            //statusGridView[0, 0].Value = "test";
            System.Collections.BitArray b = new System.Collections.BitArray(new int[] { s });
            
            for (int i = 0; i <= 7; i++)
            {
                if (b[i] == false) statusGridView[i, 0].Value = 0;
                if (b[i] == true) statusGridView[i, 0].Value = 1;
            }

            s = executor.GetRegisterA();
            b = new System.Collections.BitArray(new int[] { s });

            for (int i = 0; i <= 7; i++)
            {
                if (b[i] == false) raGridView1[i, 0].Value = 0;
                if (b[i] == true) raGridView1[i, 0].Value = 1;
            }

            s = executor.GetTrisA();
            b = new System.Collections.BitArray(new int[] { s });

            for (int i = 0; i <= 7; i++)
            {
                if (b[i] == false) raGridView1[i, 1].Value = 0;
                if (b[i] == true) raGridView1[i, 1].Value = 1;
            }

            s = executor.GetRegisterB();
            b = new System.Collections.BitArray(new int[] { s });

            for (int i = 0; i <= 7; i++)
            {
                if (b[i] == false) rbGridView1[i, 0].Value = 0;
                if (b[i] == true) rbGridView1[i, 0].Value = 1;
            }

            s = executor.GetTrisB();
            b = new System.Collections.BitArray(new int[] { s });

            for (int i = 0; i <= 7; i++)
            {
                if (b[i] == false) rbGridView1[i, 1].Value = 0;
                if (b[i] == true) rbGridView1[i, 1].Value = 1;
            }

            int[] R = executor.GetFullRegister();
            int ii = 0;

            foreach (int reg in R)
            {
                registerGridView1.Rows[ii].Cells[0].Value = ii;
                registerGridView1.Rows[ii].Cells[1].Value = Convert.ToString(reg, 2);
                ii++;
            }

            int[] stack = executor.GetStack();
            stackGridView1.Rows.Clear();
            stackGridView1.Refresh();
            ii = 0;

            foreach (int item in stack)
            {
                stackGridView1.Rows.Add();
                stackGridView1.Rows[ii].Cells[0].Value = ii;
                stackGridView1.Rows[ii].Cells[1].Value = Convert.ToString(item, 16);
                ii++;
            }
        }

        private void timerRun_Tick(object sender, EventArgs e)
        {
            completeListBox1.SelectedIndex = sourceManager.getIndexInCode(executor.GetPc());
            if (breakpoints[completeListBox1.SelectedIndex] & !breakpointHit)
            {
                timerRun.Enabled = false;
                breakpointHit = true;
                btRun.Text = "Run";
            }
            else
            {
                step();
                breakpointHit = false;
            }
            
        }

        private void step()
        {
            
            executor.Execute(sourceManager.GetSingleArg1(executor.GetPc()));
            
            printInfo();
            argumentListBox1.SelectedIndex = executor.GetPc();
            completeListBox1.SelectedIndex = sourceManager.getIndexInCode(executor.GetPc());

            tbLaufzeit.Text = ((4000.0 / double.Parse(tbQuartzFrequenz.Text)) * System.Convert.ToDouble(executor.GetLaufzeitzähler())).ToString();
            
        }

        private void completeListBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.completeListBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                if (breakpoints[index] == false)
                {
                    breakpoints[index] = true;
                    Console.WriteLine("activated breakpoint at index: " + index);
                    completeListBox1.Refresh();
                }
                else
                {
                    breakpoints[index] = false;
                    Console.WriteLine("deactivated breakpoint at index: " + index);
                    completeListBox1.Refresh();
                }
            }
        }

        private void ListBox1_DrawItem(object sender,
    System.Windows.Forms.DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

           
            if (!firstRun)
            {
                if (breakpoints[e.Index])
                {
                    myBrush = Brushes.Red;
                }
                else
                {
                    myBrush = Brushes.Black;
                }
            } else
            {
                myBrush = Brushes.Black;
            }
            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(completeListBox1.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void rbGridView1_listener(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.RowIndex == 0)
                {
                    executor.SetRegisterB(e.ColumnIndex);
                }
                printInfo();
            }
        }

        private void raGridView1_listener(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.RowIndex == 0)
                {
                    executor.SetRegisterA(e.ColumnIndex);
                }
                printInfo();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executor.Reset();
            printInfo();
        }

        private void timerExtClock_Tick(object sender, EventArgs e)
        {
            //executor.SetRegisterA(4);

            int regA = executor.GetRegisterA();
            if ((regA & 0b1_0000) != 0b1_0000)
            {
                //Console.WriteLine("ExtClock");
                executor.SetRegisterA(4);
            }
        }

        private void btRS232_Click(object sender, EventArgs e)
        {
            executor.RS232();
            printInfo();
        }
    }
}
