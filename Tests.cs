using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MindboxTest
{
    [TestFixture]
    internal class Tests
    {
        private AreaCalculator areaCalculator;

        [SetUp]
        public void SetUp()
        {
            areaCalculator = new AreaCalculator();
        }

        [TestCase(new double[] { 3, 4, 5, 6 })]
        [TestCase(new double[] { 12, 15, 20, 89.67 })]
        public void TriangleTest(double[] testCase)
        {
            var answer = testCase[3];
            var actual = areaCalculator.CalcTriangle(out double result, testCase[0], testCase[1], testCase[2]);
            Assert.AreEqual(answer, result, 0.01);
        }

        [TestCase(new double[] {double.PositiveInfinity, double.PositiveInfinity})]
        [TestCase(new double[] { 5, 78.54 })]
        public void CircleTest(double[] testCase)
        {
            var answer = testCase[1];
            var actual = areaCalculator.CalcCircle(out double result, testCase[0]);
            Assert.AreEqual(answer, result, 0.01);
        }

        [TestCase(new double[] { -10, 12, 14 })]
        [TestCase(new double[] { 1, 10, 12 })]
        public void NonExistingTriangleTest(double[] testCase)
        {
            Assert.IsFalse(areaCalculator.CalcTriangle(out double result, testCase[0], testCase[1], testCase[2]));
        }

        [TestCase(-1)]
        [TestCase(double.NegativeZero)]
        [TestCase(double.NegativeInfinity)]
        public void NegativeRadiusTest(double radius)
        {
            Assert.IsFalse(areaCalculator.CalcCircle(out double result, radius));
        }

        [TestCase(new double[] { 8, 6, 10 })]
        [TestCase(new double[] { 10, 8, 6 })]
        [TestCase(new double[] { 0.006, 0.008, 0.01})]
        public void RightTriangleTest(double[] testCase)
        {
            var actual = areaCalculator.CalcTriangle(
                out double result, out bool isRight, testCase[0], testCase[1], testCase[2]);
            Assert.IsTrue(isRight);
        }
    }
}
