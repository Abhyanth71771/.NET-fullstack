using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]
    internal class FizzBuzzTester
    {
        [TestCase(15, "FizzBuzz")]
        [TestCase(12, "Fizz")]
        [TestCase(20, "Buzz")]
        [TestCase(22, "Fizz")]
        [TestCase(22, "")]
        public void FizzbuzzTest(int num,string ans)
        {
            string result = FizzBuzz.Ask(num);
            Assert.That(result, Is.EqualTo(ans));

        }

    }
}
