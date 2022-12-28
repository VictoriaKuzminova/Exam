using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {

        bool flag = false;
        double x, y;
        bool select;
        public Form1()
        {
            InitializeComponent();
        }
        private void gr2(double x, double y)
        {
            if ((x * x + y * y <= 25) || (x <= 0) || ((y >= x + 2) && (y <= 0)))
            {
                if ((x * x + y * y < 25) || (x < 0) || ((y > x + 2) && (y < 0)))
                {
                    MessageBox.Show("Принадлежит");
                    toolStripStatusLabel1.Text = "Точка принадлежит";
                    return;
                }
                else
                {
                    MessageBox.Show("На границе");
                    toolStripStatusLabel1.Text = "На границе";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Не принадлежит");
                toolStripStatusLabel1.Text = "Точка не принадлежит";
                return;
            }
                
        }

        private void gr1(double x, double y)
        {
            if (Math.Abs(x) + Math.Abs(y) <= 1)
            {
                if (Math.Abs(x) + Math.Abs(y) < 1)
                {
                    MessageBox.Show("Принадлежит");
                    toolStripStatusLabel1.Text = "Точка принадлежит";
                    return;
                }
                else
                {
                    MessageBox.Show("На границе");
                    toolStripStatusLabel1.Text = "Точка на границе";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Не принадлежит");
                toolStripStatusLabel1.Text = "Точка не принадлежит";
                return;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "TextFiles(*.html)|*.html|AllFiles(*.*)|*.*";
            dialog.ShowDialog();
            if (!flag)
            {
                this.Height += 100;
                flag = true;
            }
            string[] repSplit = dialog.FileName.Split('\\');
            string curFile = repSplit[repSplit.Length - 1];
            webBrowser1.Navigate(dialog.FileName);

            if (curFile == "Страница1.html")
            {
                webBrowser1.Navigate(dialog.FileName);
                select = true;
            }
            else if (curFile == "Страница2.html")
            {
                webBrowser1.Navigate(dialog.FileName);
                select = false;
            }
            else
            {
                MessageBox.Show($"Нет решения для {curFile}. Попробуйте выбрать файлы Страница1.html и Страница2.html");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кузьминова Виктория Викторовна" + "\n" + "Студентка группы ПКсп-120" + "\n" +"Вариант 8");
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x_textBox.Text == ""|| y_textBox.Text == "")
            {
                MessageBox.Show("Введены не все данные");
                return;
            }
            else
            {
                try
                {
                    x = double.Parse(x_textBox.Text);
                }
                catch
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }
                try
                {
                    y= double.Parse(y_textBox.Text);
                }
                catch
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }
                if (!select)
                {
                    gr2(x, y);
                }
                else
                {
                    gr1(x, y);
                }
            }
        }
    }
}
