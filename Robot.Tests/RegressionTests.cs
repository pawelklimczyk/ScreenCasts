// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="RegressionTests.cs" project="Robot.Tests" date="2013-11-25 22:59">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace Robot.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using NUnit.Framework;

    [TestFixture]
    public class RegressionTests
    {
        [Test]
        [Sequential]
        public void Tests([Values(@"1
1 1
FRF", @"1
1 1
RFFLFRB", @"1
-1 -1
BRB", @"3
1 1
2 2
3 3
FRFFLFFRF", @"1
1 1
FRFBF")] string consoleInput, [Values("1\r\n", "1\r\n", "1\r\n", "3\r\n", "1\r\n")] string expectedValue)
        {
            //arrange
            StringBuilder builder = new StringBuilder();
            TextWriter writer = new StringWriter(builder);
            TextReader reader = new StringReader(consoleInput);

            Console.SetIn(reader);
            Console.SetOut(writer);

            //act
            Program.Main(null);

            //assert
            Assert.That(builder.ToString(), Is.EqualTo(expectedValue));
        }
    }
}