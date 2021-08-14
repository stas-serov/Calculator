using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double a, b, res = 0;
        private string operation;
        /// <summary>
        /// Кнопка "="
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void equal_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                b = Convert.ToDouble(textBox1.Text);
                res = ravno(operation, a, b);
                operation = "n";
                textBox1.Text = res.ToString("G4");
            }
        }
        /// <summary>
        /// Кнопка "C"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        /// <summary>
        /// Кнопка "+"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void add_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                operation = "+";
            }
            else MessageBox.Show("Введите первое число!", "Ошибка");
        }
        /// <summary>
        /// Ввод символа с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.KeyChar = (char)Keys.None;
        }
        /// <summary>
        /// Кнопка "-"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sub_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox1.Text != "-"))
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                operation = "-";
            }
            else if((textBox1.Text == "")) textBox1.Text += '-';
            else MessageBox.Show("Неозможно ввести два минуса!", "Ошибка");
            
        }
        /// <summary>
        /// Кнопка "/"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void devide_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                operation = "/";
            }
            else MessageBox.Show("Введите первое число!", "Сообщение");
        }
        /// <summary>
        /// Кнопка ввода цифр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void digit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += (sender as Button).Text;
            max_min();
            past_point();
        }
        /// <summary>
        /// Кнопка ввода нуля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void zero_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text != "0")
            {
                textBox1.Text = textBox1.Text + "0";
                max_min();
                past_point();
            }
            else
                textBox1.Text = "0";
        }
        /// <summary>
        /// Кнопка "*"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void multiply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                operation = "*";
            }
            else MessageBox.Show("Введите первое число!", "Ошибка");
        }
        /// <summary>
        /// Кнопка "√x"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sqrt_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            SQRT(a);
        }
        /// <summary>
        /// Кнопка "x*x"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pow_2_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            pow(a);
        }
        /// <summary>
        /// Кнопка "±"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void reverse_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) MessageBox.Show("Введите число!", "Ошибка");
            else
            {
                a = Convert.ToDouble(textBox1.Text);
                a *= -1;
                if (a < -4000000)
                {
                    a = -4000000;
                    MessageBox.Show("Минимальное число - 4 000 000!", "Ошибка");
                }
                textBox1.Text = Convert.ToString(a);
            }
        }
        /// <summary>
        /// Кнопка ","
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void point_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(','))
            {
                MessageBox.Show("Разделитель целой и дробной части уже введен!", "Ошибка");
            }
            else if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "0,";
            }
            else textBox1.Text += (sender as Button).Text;
        }
        /// <summary>
        /// Кнопка "1/x"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void one_devide_by_num_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                if (a == 0)
                {
                    res = Convert.ToDouble(null);
                    MessageBox.Show("Деление на ноль!", "Ошибка");
                    textBox1.Clear();
                }
                else
                {
                    res = one_dev_by_num(a);
                    textBox1.Text = res.ToString("G4");
                }
            }
            else
            {
                res = Convert.ToDouble(null);
                MessageBox.Show("Введите число!", "Ошибка");
            }
        }
        /// <summary>
        /// Метод для нахождения "!x"
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public double factorial(double num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                if (num < 0) return num * factorial(num + 1);
                else  return num * factorial(num - 1);
            }
        }
        /// <summary>
        /// Кнопка "sin(x)"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                res = SIN(Convert.ToDouble(textBox1.Text));
                textBox1.Text = res.ToString("G4");
            }
            else
            {
                res = Convert.ToDouble(null);
                MessageBox.Show("Введите число!", "Ошибка");
            }
        }
        /// <summary>
        /// Кнопка "cos(x)"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cos_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                res = COS(Convert.ToDouble(textBox1.Text));
                textBox1.Text = res.ToString("G4");
            }
            else
            {
                res = Convert.ToDouble(null);
                MessageBox.Show("Введите число!", "Ошибка");
            }
        }
        /// <summary>
        /// Кнопка "!x"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void fact_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains(","))
            {
                MessageBox.Show("Введите целое число!", "Ошибка");
            }
            else if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                res = factorial(a);
                textBox1.Text = res.ToString("G4");
            }
            else MessageBox.Show("Введите число!", "Ошибка");
        }
        /// <summary>
        /// Метод для редактирования числа, если оно выходит за границы
        /// </summary>
        public void max_min()
        {
            double num = Convert.ToDouble(textBox1.Text);
            if (num > 6000000 || num < -4000000)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
        /// <summary>
        /// Метод для редактирования числа, если дробная часть включает более 4 символов
        /// </summary>
        public void past_point()
        {
            if (textBox1.Text.Contains(','))
            {
                int point_position = textBox1.Text.IndexOf(',');
                int past_point = point_position + 5;
                if (textBox1.Text.Length > past_point)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
            }
        }
        /// <summary>
        /// Кнопка "Del"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void delete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }
        /// <summary>
        /// Метод для вычислений "+", "-", "*", "/"
        /// </summary>
        /// <param name="op"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double ravno(string op, double x, double y)
        {
            switch (op)
            {
                case "+":
                    res = x + y;
                    break;
                case "-":
                    res = x - y;
                    break;
                case "*":
                    res = x * y;
                    break;
                case "/":
                    if (y == 0)
                    {
                        res = Convert.ToDouble(null);
                        MessageBox.Show("Деление на ноль!", "Ошибка");
                        textBox1.Clear();
                    }
                    else res = x / y;
                    break;
                case "n":
                    MessageBox.Show("Введите операцию!", "Ошибка");
                    break;
            }
            return res;
        }
        /// <summary>
        /// Метод для вычислений "1/x"
        /// </summary>
        /// <returns></returns>
        public double one_dev_by_num(double x)
        {
            res = 1 / x;
            return res;
        }
        /// <summary>
        /// Метод для вычислений "√x"
        /// </summary>
        /// <returns></returns>
        public double SQRT(double x)
        {
            if (Convert.ToString(x) == "")
            {
                res = Convert.ToDouble(null);
                MessageBox.Show("Введите число!", "Ошибка");
            }
            else if (x < 0)
            {
                res = Convert.ToDouble(null);
                MessageBox.Show("Невозможно вычислить квадратный корень из отрицательного числа!", "Ошибка");
                textBox1.Clear();
            }
            else if (Convert.ToString(x) != "")
            {
                res = Math.Sqrt(x);
                textBox1.Text = res.ToString("G4");
            }
            return res;
        }
        /// <summary>
        /// Метод для вычислений "x*x"
        /// </summary>
        /// <returns></returns>
        public double pow(double x)
        {
            if (Convert.ToString(x) != "")
            {
                res = x * x;
                textBox1.Text = res.ToString("G4");
            }
            else
            {
                res = Convert.ToDouble(null);
                MessageBox.Show("Введите число!", "Ошибка");
            }
            return res;
        }
        /// <summary>
        /// Метод для вычислений "sin(x)"
        /// </summary>
        /// <returns></returns>
        public double SIN (double x)
        {
            res = Math.Sin((x * Math.PI) / 180);
            return res;
        }
        /// <summary>
        /// Метод для вычислений "cos(x)"
        /// </summary>
        /// <returns></returns>
        public double COS (double x)
        {
            res = Math.Cos((x * Math.PI) / 180);
            return res;
        }
    }
}
