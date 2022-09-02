using System;
using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserGenericsExampleTests
{
    /// <summary>
    /// An example of the same idea using Generics
    /// </summary>
    /// <typeparam name="T"><see cref="IStringParser"/></typeparam>
    public abstract class GenericParserTests<T>
        where T : IStringParser
    {
        protected abstract string GetInputHeaderSingleDigit();

        protected T GetParser(string input)
        {
            return (T)Activator.CreateInstance(typeof(T), input);
        }

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = GetInputHeaderSingleDigit();
            T parser = GetParser(input);

            bool result = parser.HasCorrectHeader();

            Assert.That(result, Is.True);
        }
    }
}