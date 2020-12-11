using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private TextBox[][] rows;
        private List<List<TextBox>> columns;
        private List<List<TextBox>> boxes;

        private void FillArray()
        {
            rows = new TextBox[9][];

            rows[0] = new TextBox[9];
            rows[0][0] = textBox1;
            rows[0][1] = textBox2;
            rows[0][2] = textBox3;
            rows[0][3] = textBox4;
            rows[0][4] = textBox5;
            rows[0][5] = textBox6;
            rows[0][6] = textBox7;
            rows[0][7] = textBox8;
            rows[0][8] = textBox9;

            rows[1] = new TextBox[9];
            rows[1][0] = textBox10;
            rows[1][1] = textBox11;
            rows[1][2] = textBox12;
            rows[1][3] = textBox13;
            rows[1][4] = textBox14;
            rows[1][5] = textBox15;
            rows[1][6] = textBox16;
            rows[1][7] = textBox17;
            rows[1][8] = textBox18;

            rows[2] = new TextBox[9];
            rows[2][0] = textBox19;
            rows[2][1] = textBox20;
            rows[2][2] = textBox21;
            rows[2][3] = textBox22;
            rows[2][4] = textBox23;
            rows[2][5] = textBox24;
            rows[2][6] = textBox25;
            rows[2][7] = textBox26;
            rows[2][8] = textBox27;

            rows[3] = new TextBox[9];
            rows[3][0] = textBox28;
            rows[3][1] = textBox29;
            rows[3][2] = textBox30;
            rows[3][3] = textBox31;
            rows[3][4] = textBox32;
            rows[3][5] = textBox33;
            rows[3][6] = textBox34;
            rows[3][7] = textBox35;
            rows[3][8] = textBox36;

            rows[4] = new TextBox[9];
            rows[4][0] = textBox37;
            rows[4][1] = textBox38;
            rows[4][2] = textBox39;
            rows[4][3] = textBox40;
            rows[4][4] = textBox41;
            rows[4][5] = textBox42;
            rows[4][6] = textBox43;
            rows[4][7] = textBox44;
            rows[4][8] = textBox45;

            rows[5] = new TextBox[9];
            rows[5][0] = textBox46;
            rows[5][1] = textBox47;
            rows[5][2] = textBox48;
            rows[5][3] = textBox49;
            rows[5][4] = textBox50;
            rows[5][5] = textBox51;
            rows[5][6] = textBox52;
            rows[5][7] = textBox53;
            rows[5][8] = textBox54;

            rows[6] = new TextBox[9];
            rows[6][0] = textBox55;
            rows[6][1] = textBox56;
            rows[6][2] = textBox57;
            rows[6][3] = textBox58;
            rows[6][4] = textBox59;
            rows[6][5] = textBox60;
            rows[6][6] = textBox61;
            rows[6][7] = textBox62;
            rows[6][8] = textBox63;

            rows[7] = new TextBox[9];
            rows[7][0] = textBox64;
            rows[7][1] = textBox65;
            rows[7][2] = textBox66;
            rows[7][3] = textBox67;
            rows[7][4] = textBox68;
            rows[7][5] = textBox69;
            rows[7][6] = textBox70;
            rows[7][7] = textBox71;
            rows[7][8] = textBox72;

            rows[8] = new TextBox[9];
            rows[8][0] = textBox73;
            rows[8][1] = textBox74;
            rows[8][2] = textBox75;
            rows[8][3] = textBox76;
            rows[8][4] = textBox77;
            rows[8][5] = textBox78;
            rows[8][6] = textBox79;
            rows[8][7] = textBox80;
            rows[8][8] = textBox81;

            columns = new List<List<TextBox>>();
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());
            columns.Add(new List<TextBox>());

            for (int i=0;i<9;i++)
            {
                for(int j=0;j<9;j++)
                {
                    columns[j].Add(rows[i][j]);
                }
            }

            boxes = new List<List<TextBox>>();
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());
            boxes.Add(new List<TextBox>());

            int f = 0, s = 1, t = 2;

            for(int i=0;i<9;i++)
            {
                if(i==3||i==6)
                {
                    f+=3; s+=3; t+=3;
                }

                boxes[f].Add(rows[i][0]);
                boxes[f].Add(rows[i][1]);
                boxes[f].Add(rows[i][2]);

                boxes[s].Add(rows[i][3]);
                boxes[s].Add(rows[i][4]);
                boxes[s].Add(rows[i][5]);

                boxes[t].Add(rows[i][6]);
                boxes[t].Add(rows[i][7]);
                boxes[t].Add(rows[i][8]);
            }
        } //Gets The Text Boxes

        private bool SudokuIsTrue()
        {
            bool flag = true;
            List<int> nums = new List<int>();
            
            for(int i=0;i<9;i++)
            {
                nums.Clear();
                for(int j=0;j<9;j++)
                {
                    if (rows[i][j].Text == "")
                    {
                        nums.Add(0);
                    }
                    else
                    {
                        nums.Add(int.Parse(rows[i][j].Text));
                    }   
                }

                if(nums.Where(x=>x!=0).ToList().Count()!=nums.Where(x => x != 0).ToList().Distinct().Count())
                {
                    flag = false;
                    return flag;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                nums.Clear();
                for (int j = 0; j < 9; j++)
                {
                    if (columns[i][j].Text == "")
                    {
                        nums.Add(0);
                    }
                    else
                    {
                        nums.Add(int.Parse(columns[i][j].Text));
                    }
                }

                if (nums.Where(x => x != 0).ToList().Count() != nums.Where(x => x != 0).ToList().Distinct().Count())
                {
                    flag = false;
                    return flag;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                nums.Clear();
                for (int j = 0; j < 9; j++)
                {
                    if (boxes[i][j].Text == "")
                    {
                        nums.Add(0);
                    }
                    else
                    {
                        nums.Add(int.Parse(boxes[i][j].Text));
                    }
                }

                if (nums.Where(x => x != 0).ToList().Count() != nums.Where(x => x != 0).ToList().Distinct().Count())
                {
                    flag = false;
                    return flag;
                }
            }

            return flag;
        }

        private void ColorLabel(bool flag)
        {
            if(flag==true)
            {
                label1.BackColor = Color.Green;
            }
            else
            {
                label1.BackColor = Color.Red;
            }
        }

        private bool SudokuHasEmpty()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (rows[i][j].Text == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Solve(int ipos, int jpos)
        {
            if (!SudokuIsTrue())
            {
                return;
            }
            if (!SudokuHasEmpty())
            {
                ShowBoxes();
                //return;
                //throw new Exception();
                //stop recursion
            }
            if (rows[ipos][jpos].Text == "")
            {
                for (int k = 1; k <= 9; k++)
                {
                    rows[ipos][jpos].Text = k.ToString();

                    if (jpos == 8)
                    {
                        Solve(ipos + 1, 0);
                    }
                    else
                    {
                        Solve(ipos, jpos + 1);
                    }
                }
            }
            else
            {
                if (jpos == 8)
                {
                    Solve(ipos + 1, 0);
                }
                else
                {
                    Solve(ipos, jpos + 1);
                }
            }
        }

        private void ShowBoxes()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    rows[i][j].Show();
                }
            }
        }

        private void HideBoxes()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    rows[i][j].Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FillArray();

           for(int i=0;i<9;i++)
           {
                for (int j = 0; j < 9; j++)
                {
                    rows[i][j].Text = "";
                }
           }

           label1.BackColor = Color.White;
        } //Clear

        private void button2_Click(object sender, EventArgs e)
        {
            FillArray();

            if(!SudokuIsTrue())
            {
                ColorLabel(false);
                return;
            }

            HideBoxes();

            try
            {
                Solve(0, 0);
            }
            catch
            {
                
                return;
            }
            ShowBoxes();
            ColorLabel(false);
        } //Solve

        private void button4_Click(object sender, EventArgs e)
        {
            FillArray();
            
            if(SudokuIsTrue())
            {
                ColorLabel(true);
            }
            else
            {
                ColorLabel(false);
            }
        } //Check

        private void button3_Click(object sender, EventArgs e)
        {

        } //New
    }
}
