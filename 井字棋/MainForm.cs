using System;
using System.Drawing;
using System.Windows.Forms;
namespace 井字棋
{
    public partial class MainForm : Form
    {
        Button[] Cell = new Button[9];
        bool Flag = true;
        int Count = 0;
        int[] Table = { 0, 4, 8, 2, 4, 6, 0, 1, 2, 3, 4, 5,
                        6, 7, 8, 0, 3, 6, 1, 4, 7, 2, 5, 8 };
        int[] Value = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                Cell[i] = new Button();
                Cell[i].Tag = i;
                Cell[i].Location = new Point(80 * (i % 3), 80 * (i / 3));
                Cell[i].Size = new Size(80, 80);
                Cell[i].Font = new Font("Arial", 36, Cell[i].Font.Style);
                Cell[i].Click += new EventHandler(Cell_Click);
                Cell[i].MouseLeave += new EventHandler(MainForm_Shown);
                Controls.Add(Cell[i]);
            }
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            label1.Focus();
        }
        private void Cell_Click(object sender, EventArgs e)
        {
            int i = (int)((Button)sender).Tag;
            if (Value[i]==0)
            {
                Cell[i].Text = Flag ? "O" : "X";
                Value[i] = Flag ? 1 : -1;
                Flag = !Flag;
                Check();
            }
        }
        void Check()
        {
            for (int i = 0; i < 8; i++)
            {
                int Base = Value[Table[i * 3]];
                Base += Value[Table[i * 3 + 1]];
                Base += Value[Table[i * 3 + 2]];
                if (Base == 3 || Base == -3)
                {
                    MessageBox.Show(Base == 3 ? "Win" : "Lost");
                    Application.Restart();
                }
            }
            if (Count++ == 8)
            {
                MessageBox.Show("Tie");
                Application.Restart();
            }
        }
    }
}