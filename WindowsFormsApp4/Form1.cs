using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            
        }

        NewProgram program = new NewProgram();

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button_square_Click(object sender, EventArgs e)
        {
            program.taskTriangle(textBox1, (int)numericUpDown1.Value);
        }

        private void Button_hypotenuse_Click(object sender, EventArgs e)
        {
            program.taskRTriangle(textBox2, (int)numericUpDown2.Value);
        }

        private void Button_clean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        

        

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        

        private void Button_exit_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string save = saveFileDialog1.FileName;
            program.SaveFile(save, (int)numericUpDown1.Value);

            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            string SaveRT = saveFileDialog2.FileName;
            program.SaveFileRT(SaveRT, (int)numericUpDown2.Value);

            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                program.LoadFile(openFileDialog1.FileName, (int)numericUpDown1.Value, textBox1);

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
                program.LoadFileRT(openFileDialog2.FileName, (int)numericUpDown2.Value, textBox2);

        }

        
    }
}
