using System;
using System.Security.Principal;
using NUnit.Framework;
using stringcalculator;

namespace StringCalculatorNunitTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator calculator;
        
        [SetUp]
        public void Setup()
        {
            // ARRANGE
            calculator = new StringCalculator(1000);
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.AreEqual(0, calculator.calculator);
        }

        [Test]
        public void Add_SingleNumber_ReturnsValue()
        {
            //ARRANGE
            var calculator = new StringCalculator();

            //ACT
            var calculator1 = calculator.Add("1");
            
            //ASSERT
            Assert.AreEqual(1, calculator.calculator);
        }

        [Test]
        public void Add_TwoNumbersCommaDelimited_ReturnsSum()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("1,2");

            Assert.AreEqual(3, calculator.calculator);
        }

        [Test]
        public void Add_TwoNumbersNewlineDelimited_ReturnsSum()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("1\n2");

            Assert.AreEqual(3, calculator.calculator);
        }

        [Test]
        public void Add_ThreeNumbersDelimitedEitherWay_ReturnsSum()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("1,2\n3");

            Assert.AreEqual(6, calculator.calculator);
        }

        [Test]
        public void Add_NegativeNumbers_ThrowsException()
        {
            var calculator = new StringCalculator();

            Assert.Throws<ArgumentException>(() => calculator.Add("1,-2,3,-4"));
        }

        [Test]
        public void Add_NumbersGreaterThan1000_AreIgnored()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("1,1000,1001");

            Assert.AreEqual(1001, calculator.calculator);
        }

        [Test]
        public void Add_SingleCharDelimiterDefinedOnFirstLine_ReturnsSum()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, calculator.calculator);
        }

        [Test]
        public void Add_MultiCharDelimiterDefinedOnFirstLine_ReturnsSum()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("//[***]\n1***2***3");

            Assert.AreEqual(6, calculator.calculator);
        }

        [Test]
        public void Add_ManyDelimitersDefinedOnFirstLine_ReturnsSum()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("//[*][%]\n1*2%3");

            Assert.AreEqual(6, calculator.calculator);
        }
    }
}