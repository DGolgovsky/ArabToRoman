using System;
using System.Windows.Forms;

namespace ArabicToRoman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int[] Arabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] Roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int Number = 0, index = 0;
            try { Number = Convert.ToInt32(textBox1.Text); }
            catch { }
            string s = "";
            while (Number > 0)
            {
                if (Arabic[index] <= Number)
                {
                    Number = Number - Arabic[index];
                    s = s + Roman[index];
                }
                else index++;
            }
            textBox2.Text = s;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string Roman = textBox2.Text;            
            int Arabic = 0;
            for (int i = 0; i < Roman.Length; i++)
            {
                switch (Roman[i])
                {

                    case 'M':
                        Arabic += 1000;
                        break;
                    case 'D':
                        Arabic += 500;
                        break;
                    case 'C':
                        if (i + 1 < Roman.Length && (Roman[i + 1] == 'D' || Roman[i + 1] == 'M'))
                            Arabic -= 100;
                        else
                            Arabic += 100;
                        break;
                    case 'L':
                        Arabic += 50;
                        break;
                    case 'X':
                        if (i + 1 < Roman.Length && (Roman[i + 1] == 'L' || Roman[i + 1] == 'C' || Roman[i + 1] == 'M'))
                            Arabic -= 10;
                        else
                            Arabic += 10;
                        break;
                    case 'V':
                        Arabic += 5;
                        break;
                    case 'I':
                        if (i + 1 < Roman.Length && (Roman[i + 1] == 'V' || Roman[i + 1] == 'X' || Roman[i + 1] == 'C'))
                            Arabic -= 1;
                        else Arabic += 1;
                        break;
                }
            }
            if (textBox2.Text == "") textBox1.Text = "";
            else textBox1.Text = Arabic.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Converter deployment by student KACY-101 (3)\nD.Golgovsky", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
