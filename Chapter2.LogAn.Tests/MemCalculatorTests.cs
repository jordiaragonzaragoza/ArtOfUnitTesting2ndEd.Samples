﻿using NUnit.Framework;

namespace Chapter2.LogAn.Tests
{
    [TestFixture]
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calc = MakeCalc();

            int lastSum = calc.Sum();

            Assert.That(lastSum, Is.EqualTo(0));
        }

        [Test]
        public void Add_WhenCalled_ChangesSum()
        {
            MemCalculator calc = MakeCalc();

            calc.Add(1);
            int sum = calc.Sum();

            Assert.That(sum, Is.EqualTo(1));
        }

        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}
