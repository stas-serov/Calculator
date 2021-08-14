using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Калькулятор;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {

        Form1 form = new Form1();
        [TestMethod]
        public void pos_add_pos()
        {
            string operation = "+";
            double a = 10;
            double b = 10;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(20, actual);
        }
        [TestMethod]
        public void pos_add_neg()
        {
            string operation = "+";
            double a = 10;
            double b = -10;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(0, actual);
        }
        [TestMethod]
        public void neg_add_pos()
        {
            string operation = "+";
            double a = -10;
            double b = 30;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(20, actual);
        }
        [TestMethod]
        public void neg_add_neg()
        {
            string operation = "+";
            double a = -10;
            double b = -30;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-40, actual);
        }
        [TestMethod]
        public void pos_sub_pos()
        {
            string operation = "-";
            double a = 30;
            double b = 20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(10, actual);
        }
        [TestMethod]
        public void pos_sub_neg()
        {
            string operation = "-";
            double a = 30;
            double b = -20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(50, actual);
        }
        [TestMethod]
        public void neg_sub_pos()
        {
            string operation = "-";
            double a = -30;
            double b = 20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-50, actual);
        }
        [TestMethod]
        public void neg_sub_neg()
        {
            string operation = "-";
            double a = -30;
            double b = -20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-10, actual);
        }
        [TestMethod]
        public void pos_mult_pos()
        {
            string operation = "*";
            double a = 30;
            double b = 20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(600, actual);
        }
        [TestMethod]
        public void pos_mult_neg()
        {
            string operation = "*";
            double a = 30;
            double b = -20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-600, actual);
        }
        [TestMethod]
        public void neg_mult_pos()
        {
            string operation = "*";
            double a = -30;
            double b = 20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-600, actual);
        }
        [TestMethod]
        public void neg_mult_neg()
        {
            string operation = "*";
            double a = -30;
            double b = -20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(600, actual);
        }
        [TestMethod]
        public void pos_div_pos()
        {
            string operation = "/";
            double a = 400;
            double b = 20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(20, actual);
        }
        [TestMethod]
        public void pos_div_neg()
        {
            string operation = "/";
            double a = 400;
            double b = -20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-20, actual);
        }
        [TestMethod]
        public void neg_div_pos()
        {
            string operation = "/";
            double a = -400;
            double b = 20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(-20, actual);
        }
        [TestMethod]
        public void neg_div_neg()
        {
            string operation = "/";
            double a = -400;
            double b = -20;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(20, actual);
        }
        [TestMethod]
        public void pos_div_zero()
        {
            string operation = "/";
            double a = 400;
            double b = 0;
            double actual = form.ravno(operation, a, b);
            Assert.AreEqual(Convert.ToDouble(null), actual);
        }
        [TestMethod]
        public void sqrt_pos()
        {
            double a = 121;
            double actual = form.SQRT(a);
            Assert.AreEqual(11, actual);
        }
        [TestMethod]
        public void sqrt_neg()
        {
            double a = -121;
            double actual = form.SQRT(a);
            Assert.AreEqual(Convert.ToDouble(null), actual);
        }
        [TestMethod]
        public void sqrt_zero()
        {
            double a = 0;
            double actual = form.SQRT(a);
            Assert.AreEqual(0, actual);
        }
        [TestMethod]
        public void pow_pos()
        {
            double a = 25;
            double actual = form.pow(a);
            Assert.AreEqual(625, actual);
        }
        [TestMethod]
        public void pow_neg()
        {
            double a = -25;
            double actual = form.pow(a);
            Assert.AreEqual(625, actual);
        }
        [TestMethod]
        public void one_dev_by_pos()
        {
            double a = 5;
            double actual = form.one_dev_by_num(a);
            Assert.AreEqual(0.2, actual);
        }
        [TestMethod]
        public void one_dev_by_neg()
        {
            double a = -5;
            double actual = form.one_dev_by_num(a);
            Assert.AreEqual(-0.2, actual);
        }
        [TestMethod]
        public void factorial_pos()
        {
            double a = 6;
            double actual = form.factorial(a);
            Assert.AreEqual(720, actual);
        }
        [TestMethod]
        public void factorial_neg()
        {
            double a = -5;
            double actual = form.factorial(a);
            Assert.AreEqual(-120, actual);
        }
        [TestMethod]
        public void sin_pos()
        {
            double a = 90;
            double actual = form.SIN(a);
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void sin_neg()
        {
            double a = -90;
            double actual = form.SIN(a);
            Assert.AreEqual(-1, actual);
        }
        [TestMethod]
        public void cos_pos()
        {
            double a = 180;
            double actual = form.COS(a);
            Assert.AreEqual(-1, actual);
        }
        [TestMethod]
        public void cos_neg()
        {
            double a = -180;
            double actual = form.COS(a);
            Assert.AreEqual(-1, actual);
        }
    }
}
